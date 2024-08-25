using BackgroundService.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BackgroundService.EntityFrameworkCore.SeedData;

internal static class UserDataSeed
{
    public static void SeedUserData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = Guid.NewGuid(),
                    Email = "test1@gmail.com",
                    Status = "Default",
                    LastUpdatePwd = DateTime.Now.AddMonths(-7),
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Email = "test2@gmail.com",
                    Status = "Default",
                    LastUpdatePwd = DateTime.Now.AddMonths(-8),
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Email = "test3@gmail.com",
                    Status = "Default",
                    LastUpdatePwd = DateTime.Now.AddMonths(-9),
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Email = "test4@gmail.com",
                    Status = "Default",
                    LastUpdatePwd = DateTime.Now.AddMonths(-10),
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Email = "test5@gmail.com",
                    Status = "Default",
                    LastUpdatePwd = DateTime.Now.AddMonths(-11),
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Email = "test6@gmail.com",
                    Status = "Default",
                    LastUpdatePwd = DateTime.Now.AddMonths(-12),
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Email = "test7@gmail.com",
                    Status = "Default",
                    LastUpdatePwd = DateTime.Now.AddMonths(-13),
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Email = "test8@gmail.com",
                    Status = "Default",
                    LastUpdatePwd = DateTime.Now.AddMonths(-14),
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Email = "test9@gmail.com",
                    Status = "Default",
                    LastUpdatePwd = DateTime.Now.AddMonths(-15),
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Email = "test10@gmail.com",
                    Status = "Default",
                    LastUpdatePwd = DateTime.Now.AddMonths(-16),
                }
            );
    }
}
