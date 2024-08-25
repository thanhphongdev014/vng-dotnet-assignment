using Microsoft.EntityFrameworkCore;
using Services.Product.EntityFrameworkCore.EntityFrameworkCore;
using Services.Product.Grpc.Extensions;
using Services.Product.Grpc.Services;
using Services.Product.Service.Abstracts;
using Services.Product.Service.Services;

namespace Services.Product.Grpc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddGrpc();
            builder.Services.AddCustomAutoMapper();
            builder.Services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("Default")
                    , x => x.MigrationsAssembly("Services.Product.EntityFrameworkCore"));
            });
            builder.Services.AddScoped<IProductService, ProductService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<ProductRPCService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}