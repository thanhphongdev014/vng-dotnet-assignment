using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace BackgroundService.Host.Hangfire;

public class HangFireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize([NotNull] DashboardContext context)
    {
        return true;
    }
}
