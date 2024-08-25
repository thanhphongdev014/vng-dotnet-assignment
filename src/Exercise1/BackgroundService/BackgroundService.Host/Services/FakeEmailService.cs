using BackgroundService.Host.Abstracts;

namespace BackgroundService.Host.Services;

public class FakeEmailService(ILogger<FakeEmailService> logger) : IEmailService
{
    public async Task SendMailLocalAsync(string from, string to, string subject, string body)
    {
        logger.LogInformation($"... Sending email from {from} to {to}, Subject: {subject}, Body: {body}");
        await Task.Delay(2000);
        logger.LogInformation($"Email Sent");
    }
}
