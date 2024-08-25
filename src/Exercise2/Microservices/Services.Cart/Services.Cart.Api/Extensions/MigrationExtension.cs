using Microsoft.EntityFrameworkCore;
using Services.Cart.EntityFrameworkCore.EntityFrameworkCore;

namespace Product.Host.Extensions;

public static class MigrationExtension
{
    public static async void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<CartDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}
