using Microsoft.EntityFrameworkCore;
using Services.Product.EntityFrameworkCore.Models;
using System.Reflection;

namespace Services.Product.EntityFrameworkCore.EntityFrameworkCore;

public class ProductDbContext : DbContext
{
    public DbSet<ProductModel> Products { get; set; }
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
            x => x.Namespace != null && x.Namespace.StartsWith("Services.Product.EntityFrameworkCore.MappingConfigurations"));
    }
}
