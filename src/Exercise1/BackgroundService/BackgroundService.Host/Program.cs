using BackgroundService.Host.Endpoints;
using BackgroundService.Host.Extensions;
using BackgroundService.Host.Hangfire;
using Hangfire;
using Serilog;
using Serilog.Events;

namespace BackgroundService;

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
        builder.Services.AddAuthorization();

        builder.Services.AddBackgroundServices(builder);

        builder.Host.UseSerilog();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.ApplyMigrations();

        var dashboardOptions =
            new DashboardOptions
            {
                IgnoreAntiforgeryToken = true,
                Authorization = new[] { new HangFireAuthorizationFilter() }
            };

        app.UseHangfireDashboard("/hangfire", dashboardOptions);

        app.UseSwagger();

        app.UseSwaggerUI();

        app.StartWorkerAsync();

        app.MapBackgroundServiceEndpoints();

        app.Run();
    }


}
