using Product.Host.Extensions;
using Serilog;
using Serilog.Events;
using Services.Product.Api.Middlewares;

namespace Services.Product.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .WriteTo.Async(c => c.File($"Logs/logs-.log", rollingInterval: RollingInterval.Day))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();

        // Add services to the container.
        builder.Host.UseSerilog();

        builder.Services.AddExceptionHandler<GlobalExceptionHandler>(); 

        builder.Services.AddProblemDetails(); 

        builder.Services.AddAuthorization();

        builder.Services.AddCustomAutoMapper();

        builder.Services.AddProductServices(builder.Configuration);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseExceptionHandler();

        app.UseSwagger();

        app.UseSwaggerUI();

        app.UseExceptionHandler();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.ApplyMigrations();

        app.Run();
    }
}
