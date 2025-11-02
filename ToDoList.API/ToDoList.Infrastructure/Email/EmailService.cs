using System.Net;
using System.Net.Mail;
using ToDoList.Application.Interfaces;

namespace ToDoList.Infrastructure.Email;

public class EmailService(EmailSettings _emailSettings) : IEmailService
{
    public async Task SendNotificationEmailAsync(string toEmail, string subject, string body)
    {
        using var smtpClient = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort)
        {
        };

        if (!string.IsNullOrEmpty(_emailSettings.SmtpUsername) && !string.IsNullOrEmpty(_emailSettings.SmtpPassword))
        {
            smtpClient.Credentials = new NetworkCredential(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword);
            smtpClient.EnableSsl = _emailSettings.EnableSsl;
        }

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailSettings.FromEmail, _emailSettings.FromName),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        mailMessage.To.Add(toEmail);

        await smtpClient.SendMailAsync(mailMessage);
    }
}
