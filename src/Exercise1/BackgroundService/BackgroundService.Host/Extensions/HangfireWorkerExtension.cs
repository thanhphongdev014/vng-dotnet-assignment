using BackgroundService.Host.Abstracts;
using BackgroundService.Host.Services;
using Hangfire;

namespace BackgroundService.Host.Extensions;

public static class HangfireWorkerExtension
{
    public static void StartWorkerAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var worker = scope.ServiceProvider.GetRequiredService<IRemindChangePasswordWorker>();
        RecurringJob.AddOrUpdate(nameof(RemindChangePasswordWorker),
            () => worker.DoWorkAsync(), "*/1 * * * *", new RecurringJobOptions()
            {
                TimeZone = TimeZoneInfo.Utc
            });
    }
}
