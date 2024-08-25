using BackgroundService.Host.Abstracts;
using System.Net.Mail;

namespace BackgroundService.Host.Services;

public class EmailService : IEmailService
{
    public async Task SendMailLocalAsync(string from, string to, string subject, string body)
    {
        using (SmtpClient client = new SmtpClient("localhost"))
        {
            MailMessage message = new MailMessage(
            from: from,
            to: to,
            subject: subject,
            body: body
        );
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.ReplyToList.Add(new MailAddress(from));
            message.Sender = new MailAddress(from);
            await client.SendMailAsync(message);
        }
    }
}
