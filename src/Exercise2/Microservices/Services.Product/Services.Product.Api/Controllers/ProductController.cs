using Microsoft.AspNetCore.Mvc;
using Services.Product.Service.Abstracts;
using Services.Product.Service.DTOs;

namespace Services.Product.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetProduct(Guid id)
    {
        var product = await productService.GetAsync(id);
        return Ok(product);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllProducts()
    {
        var product = await productService.GetAllAsync();
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduct(CreateProductDto input)
    {
        var id = await productService.CreateAsync(input);
        var location = Url.Action(nameof(GetProduct), new { id }) ?? $"{id}";
        return Created(location, new { Id = id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDto input)
    {
        await productService.UpdateAsync(id, input);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteProduct(Guid id)
    {
        await productService.DeleteAsync(id);
        return Ok();
    }
}
