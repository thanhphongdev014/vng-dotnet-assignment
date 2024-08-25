using Services.Cart.Service.DTOs;
using Services.Product.Service.DTOs;

namespace Services.Cart.Service.Abstracts;

public interface ICartService
{
    Task<List<CartDto>> GetAllAsync();
    Task AddProductToCartAsync(AddProductToCartDto input);
    Task RemoveProductFromCartAsync(RemoveProductFromCartDto input);
}
