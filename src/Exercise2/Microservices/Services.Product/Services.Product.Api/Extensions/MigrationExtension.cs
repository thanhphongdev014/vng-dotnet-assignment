using Microsoft.EntityFrameworkCore;
using Services.Product.EntityFrameworkCore.EntityFrameworkCore;

namespace Product.Host.Extensions;

public static class MigrationExtension
{
    public static async void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}
