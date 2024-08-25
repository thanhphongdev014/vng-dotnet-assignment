using Services.Product.Service.DTOs;

namespace Services.Product.Service.Abstracts;

public interface IProductService
{
    Task<ProductDto> GetAsync(Guid id);
    Task<List<ProductDto>> GetAllAsync();
    Task<Guid> CreateAsync(CreateProductDto input);
    Task UpdateAsync(Guid id, UpdateProductDto input);
    Task DeleteAsync(Guid id);
}
