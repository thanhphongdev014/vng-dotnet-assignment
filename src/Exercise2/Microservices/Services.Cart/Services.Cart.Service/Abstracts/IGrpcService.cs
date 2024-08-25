using Services.Cart.Service.DTOs;

namespace Services.Cart.Service.Abstracts;

public interface IGrpcService
{
    Task<ProductDto> GetProductAsync(Guid id);
}
