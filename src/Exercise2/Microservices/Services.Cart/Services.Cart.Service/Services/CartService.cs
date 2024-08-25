using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.Cart.EntityFrameworkCore.EntityFrameworkCore;
using Services.Cart.EntityFrameworkCore.Models;
using Services.Cart.Service.Abstracts;
using Services.Cart.Service.DTOs;
using Services.Product.Service.DTOs;
using Services.Product.Service.Exceptions;

namespace Services.Cart.Service.Services;

public class CartService(CartDbContext dbContext
                        , IMapper objectMapper
                        , IGrpcService grpcService) : ICartService
{
    public async Task<List<CartDto>> GetAllAsync()
    {
        var carts = await dbContext.Carts.ToListAsync();
        return objectMapper.Map<List<CartModel>, List<CartDto>>(carts);
    }

    public async Task AddProductToCartAsync(AddProductToCartDto input)
    {
        var product = await grpcService.GetProductAsync(input.ProductId);
        if (product == null)
        {
            throw EntityNotFoundException.FromId(input.ProductId, "Product");
        }
        if (input.CartId.HasValue)
        {
            var cart = await dbContext.Carts.Include(x => x.ListItems)
                            .FirstOrDefaultAsync(x => x.Id == input.CartId);
            if (cart == null)
            {
                throw EntityNotFoundException.FromId(input.CartId.Value, "Cart");
            }
            var existProduct = cart.ListItems.FirstOrDefault(x => x.ProductId == product.Id);
            if (existProduct != null)
            {
                throw new ProductAlreadyExistException("Product already exist !");
            }
            if (product.Quantity < input.Quantity)
            {
                throw new InvalidProductQuantityException("Product quantity is greater than inventory !");
            }
            var listItem = new ListItem()
            {
                CardId = cart.Id,
                ProductId = input.ProductId,
                Quantity = input.Quantity,
            };
            cart.TotalPrice += product.Price;
            dbContext.Carts.Update(cart);
            dbContext.ListItems.Add(listItem);
        }
        else
        {
            if (input.Quantity > product.Quantity)
            {
                throw new InvalidProductQuantityException("Quantity is greater than inventory !");
            }
            var cart = new CartModel()
            {
                Id = Guid.NewGuid(),
                TotalPrice = product.Price
            };

            var listItem = new ListItem()
            {
                CardId = cart.Id,
                ProductId = input.ProductId,
                Quantity = input.Quantity,
            };

            dbContext.ListItems.Add(listItem);
            dbContext.Carts.Add(cart);
        }
        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveProductFromCartAsync(RemoveProductFromCartDto input)
    {
        var product = await grpcService.GetProductAsync(input.ProductId);
        if (product == null)
        {
            throw EntityNotFoundException.FromId(input.ProductId, "Product");
        }
        var cart = await dbContext.Carts.FindAsync(input.CartId);
        if (cart == null)
        {
            throw EntityNotFoundException.FromId(input.CartId, "Cart");
        }
        var listItem = await dbContext.ListItems
            .FirstOrDefaultAsync(x => x.CardId == cart.Id && product.Id == input.ProductId);
        if (listItem == null)
        {
            throw EntityNotFoundException.FromId(input.ProductId, "ListItem");
        }
        cart.TotalPrice -= product.Price;
        dbContext.ListItems.Remove(listItem);
        dbContext.Carts.Update(cart);
        await dbContext.SaveChangesAsync();
    }
}
