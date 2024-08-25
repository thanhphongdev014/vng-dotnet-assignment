using BackgroundService.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SISSoft.DigitalHealthSolutions.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class BackgroundServiceDbContextFactory : IDesignTimeDbContextFactory<BackgroundServiceDbContext>
{

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory())).AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }

    BackgroundServiceDbContext IDesignTimeDbContextFactory<BackgroundServiceDbContext>.CreateDbContext(string[] args)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BackgroundServiceDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("BackgroundService.EntityFrameworkCore"));

        return new BackgroundServiceDbContext(builder.Options);
    }
}
