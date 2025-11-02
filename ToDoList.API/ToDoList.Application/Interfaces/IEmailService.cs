namespace ToDoList.Application.Interfaces;

public interface IEmailService
{
    Task SendNotificationEmailAsync(string toEmail, string subject, string body);
}
