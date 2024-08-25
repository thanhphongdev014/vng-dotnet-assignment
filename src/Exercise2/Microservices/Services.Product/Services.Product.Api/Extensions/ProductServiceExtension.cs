using Microsoft.EntityFrameworkCore;
using Services.Product.EntityFrameworkCore.EntityFrameworkCore;
using Services.Product.Service.Abstracts;
using Services.Product.Service.Services;

namespace Product.Host.Extensions;

public static class ProductExtension
{
    public static void AddProductServices(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddDbContext<ProductDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Default")
                , x => x.MigrationsAssembly("Services.Product.EntityFrameworkCore"));
        });
        services.AddScoped<IProductService, ProductService>();
    }
}
