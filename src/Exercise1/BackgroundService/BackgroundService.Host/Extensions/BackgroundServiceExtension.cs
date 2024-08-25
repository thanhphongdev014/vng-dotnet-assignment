using BackgroundService.EntityFrameworkCore.EntityFrameworkCore;
using BackgroundService.Host.Abstracts;
using BackgroundService.Host.Services;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Serilog;

namespace BackgroundService.Host.Extensions;

public static class BackgroundServiceExtension
{
    public static void AddBackgroundServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        CreateDbIfNotExist(builder);
        services.AddDbContext<BackgroundServiceDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("Default")
                , x => x.MigrationsAssembly("BackgroundService.EntityFrameworkCore"));
        });
        services.AddHangfireServer();
        services.AddHangfire(config =>
            config.UsePostgreSqlStorage(c =>
                c.UseNpgsqlConnection(builder.Configuration.GetConnectionString("Default"))));
        services.AddScoped<IEmailService, FakeEmailService>();
        services.AddScoped<IRemindChangePasswordWorker>(x =>
        new RemindChangePasswordWorker(x.GetRequiredService<BackgroundServiceDbContext>(), x.GetRequiredService<IEmailService>()));
    }

    private static void CreateDbIfNotExist(WebApplicationBuilder builder)
    {
        try
        {
            var connString = builder.Configuration.GetConnectionString("Default")!;

            var connectionStringBuilder = new NpgsqlConnectionStringBuilder(connString);
            var databaseName = connectionStringBuilder.Database;
            connectionStringBuilder.Database = "postgres";


            using var connection = new NpgsqlConnection(connectionStringBuilder.ToString());
            connection.Open();

            using var checkCommand = new NpgsqlCommand($"SELECT 1 FROM pg_database WHERE datname='{databaseName}'", connection);
            var exists = (int?)checkCommand.ExecuteScalar() == 1;

            if (!exists)
            {
                using var command = new NpgsqlCommand($"CREATE DATABASE \"{databaseName}\";", connection);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Log.Logger.Error(ex.ToString());
        }
    }
}
