using BackgroundService.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackgroundService.Host.Endpoints;

public static class BackgroundServiceEndpoints
{
    public static void MapBackgroundServiceEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/users", async (
            BackgroundServiceDbContext dbContext, CancellationToken token) =>
        {
            var users = await dbContext.Users.ToListAsync();
            return Results.Ok(users);
        });
    }
}
