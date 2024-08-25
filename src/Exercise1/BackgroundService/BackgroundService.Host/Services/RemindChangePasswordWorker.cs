using BackgroundService.EntityFrameworkCore.EntityFrameworkCore;
using BackgroundService.Host.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace BackgroundService.Host.Services;

public class RemindChangePasswordWorker(BackgroundServiceDbContext dbContext, IEmailService emailService) : IRemindChangePasswordWorker
{
    public async Task DoWorkAsync()
    {
        var sixMonthAgo = DateTime.Now.AddMonths(-6);
        var users = await dbContext.Users.Where(x => x.LastUpdatePwd < sixMonthAgo).ToListAsync();
        foreach (var user in users)
        {
            user.Status = "REQUIRE_CHANGE_PWD";
            await emailService.SendMailLocalAsync("Test@gmail.com", "Test2@gmail.com", "TestSubject", "TestBody");
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
            await Task.Delay(60000); // for testing
        }

    }
}
