using Grpc.Core;
using Services.Product.Service.Abstracts;

namespace Services.Product.Grpc.Services
{
    public class ProductRPCService(ILogger<ProductRPCService> logger, IProductService productService) : ProductRPC.ProductRPCBase
    {
        public override async Task<ProductReply> GetProductById(GetProductByIdRequest request, ServerCallContext context)
        {
            try
            {
                var product = await productService.GetAsync(new Guid(request.Id));
                return new ProductReply
                {
                    Id = product.Id.ToString(),
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return new ProductReply();
            }
        }
    }
}
