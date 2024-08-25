namespace BackgroundService.Host.Abstracts;

public interface IEmailService
{
    Task SendMailLocalAsync(string from, string to, string subject, string body);
}
