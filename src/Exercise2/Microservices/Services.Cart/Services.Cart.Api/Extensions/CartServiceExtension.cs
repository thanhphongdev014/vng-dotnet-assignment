using Microsoft.EntityFrameworkCore;
using Services.Cart.EntityFrameworkCore.EntityFrameworkCore;
using Services.Cart.Service.Abstracts;
using Services.Cart.Service.Services;

namespace Cart.Host.Extensions;

public static class CartExtension
{
    public static void AddCartServices(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddDbContext<CartDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Default")
                , x => x.MigrationsAssembly("Services.Cart.EntityFrameworkCore"));
        });
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<IGrpcService, GrpcService>();
    }
}
