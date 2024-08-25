using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Services.Cart.EntityFrameworkCore.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class CartDbContextFactory : IDesignTimeDbContextFactory<CartDbContext>
{

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory())).AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }

    CartDbContext IDesignTimeDbContextFactory<CartDbContext>.CreateDbContext(string[] args)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<CartDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("Services.Cart.EntityFrameworkCore"));

        return new CartDbContext(builder.Options);
    }
}
