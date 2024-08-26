using Microsoft.AspNetCore.Mvc;
using Services.Cart.Service.Abstracts;
using Services.Product.Service.DTOs;

namespace Services.Cart.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController(ICartService cartService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAllCart()
    {
        var carts = await cartService.GetAllAsync();
        return Ok(carts);
    }

    [HttpPost]
    public async Task<ActionResult> AddProductToCart(AddProductToCartDto input)
    {
        await cartService.AddProductToCartAsync(input);
        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveProductFromCart(RemoveProductFromCartDto input)
    {
        await cartService.RemoveProductFromCartAsync(input);
        return Ok();
    }
}
