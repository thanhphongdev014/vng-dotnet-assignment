using Grpc.Net.Client;
using Services.Cart.Service.Abstracts;
using Services.Cart.Service.DTOs;

namespace Services.Cart.Service.Services;

public class GrpcService : IGrpcService
{
    private readonly GrpcChannel _channel;
    private readonly ProductRPC.ProductRPCClient _client;
    public GrpcService()
    {
        _channel = GrpcChannel.ForAddress("http://localhost:5120");
        _client = new ProductRPC.ProductRPCClient(_channel);
    }
    public async Task<ProductDto?> GetProductAsync(Guid id)
    {
        var product = await _client.GetProductByIdAsync(new GetProductByIdRequest()
        {
            Id = id.ToString()
        });
        if (product == null)
        {
            return null;
        }
        return new ProductDto()
        {
            Id = new Guid(product.Id),
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity,
        };
    }
}
