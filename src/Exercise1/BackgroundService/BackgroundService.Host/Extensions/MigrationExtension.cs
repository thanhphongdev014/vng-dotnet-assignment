using BackgroundService.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackgroundService.Host.Extensions;

public static class MigrationExtension
{
    public static async void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<BackgroundServiceDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}
