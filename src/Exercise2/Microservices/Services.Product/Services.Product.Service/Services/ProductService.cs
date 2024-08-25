using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.Product.EntityFrameworkCore.EntityFrameworkCore;
using Services.Product.EntityFrameworkCore.Models;
using Services.Product.Service.Abstracts;
using Services.Product.Service.DTOs;
using Services.Product.Service.Exceptions;

namespace Services.Product.Service.Services;

public class ProductService(ProductDbContext dbContext, IMapper objectMapper) : IProductService
{
    public async Task<ProductDto> GetAsync(Guid id)
    {
        var product = await dbContext.Products.FindAsync(id);
        if (product == null)
        {
            throw EntityNotFoundException.FromId(id);
        }
        return objectMapper.Map<ProductModel, ProductDto>(product);
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var product = await dbContext.Products.ToListAsync();
        return objectMapper.Map<List<ProductModel>, List<ProductDto>>(product);
    }

    public async Task<Guid> CreateAsync(CreateProductDto input)
    {
        var product = new ProductModel()
        {
            Id = Guid.NewGuid(),
            Name = input.Name,
            Price = input.Price,
            Quantity = input.Quantity
        };
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
        return product.Id;
    }

    public async Task UpdateAsync(Guid id, UpdateProductDto input)
    {
        var product = await dbContext.Products.FindAsync(id);
        if (product == null)
        {
            throw EntityNotFoundException.FromId(id);
        }
        product.Name = input.Name;
        product.Price = input.Price;
        product.Quantity = input.Quantity;
        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await dbContext.Products.FindAsync(id);
        if (product == null)
        {
            throw EntityNotFoundException.FromId(id);
        }
        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync();
    }
}
