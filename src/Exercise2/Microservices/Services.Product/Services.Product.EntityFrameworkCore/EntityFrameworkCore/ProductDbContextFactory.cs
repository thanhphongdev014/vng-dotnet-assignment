using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Services.Product.EntityFrameworkCore.EntityFrameworkCore;

namespace Services.Product.EntityFrameworkCore.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ProductDbContextFactory : IDesignTimeDbContextFactory<ProductDbContext>
{

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory())).AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }

    ProductDbContext IDesignTimeDbContextFactory<ProductDbContext>.CreateDbContext(string[] args)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ProductDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("Services.Product.EntityFrameworkCore"));

        return new ProductDbContext(builder.Options);
    }
}
