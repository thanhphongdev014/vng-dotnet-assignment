using BackgroundService.EntityFrameworkCore.Models;
using BackgroundService.EntityFrameworkCore.SeedData;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BackgroundService.EntityFrameworkCore.EntityFrameworkCore;

public class BackgroundServiceDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public BackgroundServiceDbContext(DbContextOptions<BackgroundServiceDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.SeedUserData();
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
            x => x.Namespace != null && x.Namespace.StartsWith("BackgroundService.EntityFrameworkCore.MappingConfigurations"));
    }
}
