using Microsoft.EntityFrameworkCore;
using Services.Cart.EntityFrameworkCore.Models;
using System.Reflection;

namespace Services.Cart.EntityFrameworkCore.EntityFrameworkCore;

public class CartDbContext : DbContext
{
    public DbSet<CartModel> Carts { get; set; }
    public DbSet<ListItem> ListItems { get; set; }
    public CartDbContext(DbContextOptions<CartDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
            x => x.Namespace != null && x.Namespace.StartsWith("Services.Cart.EntityFrameworkCore.MappingConfigurations"));
    }
}
