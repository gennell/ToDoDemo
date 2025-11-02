using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ToDoList.Application.Services;

public class ToDoNotificationService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<ToDoNotificationService> _logger;

    public ToDoNotificationService(IServiceProvider serviceProvider, ILogger<ToDoNotificationService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("ToDo Notification Service is starting.");

        using var timer = new PeriodicTimer(TimeSpan.FromHours(1)); // Check every hour

        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            try
            {
                await CheckAndSendNotificationsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking and sending notifications.");
            }
        }
    }

    private async Task CheckAndSendNotificationsAsync()
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<IAppDbContext>();
        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

        var tomorrow = DateTime.UtcNow.Date.AddDays(1);
        var tomorrowEnd = tomorrow.AddDays(1).AddTicks(-1);

        var upcomingToDos = await dbContext.ToDoItems
            .Where(t => t.ToDoDate >= tomorrow && t.ToDoDate <= tomorrowEnd
                     && t.Status != ToDoStatus.Completed && t.NotifySended == false)
            .ToListAsync();

        if (!upcomingToDos.Any())
        {
            _logger.LogInformation("No upcoming ToDo items found for notification.");
            return;
        }
        foreach (var toDoItem in upcomingToDos)
        {
            try
            {
                var subject = $"Przypomnienie: Zadanie '{toDoItem.Title}' na jutro";
                var body = $@"
                    <h2>Przypomnienie o zbliżającym się terminie zadania</h2>
                    <p><strong>Tytuł:</strong> {toDoItem.Title}</p>
                    <p><strong>Termin:</strong> {toDoItem.ToDoDate:yyyy-MM-dd}</p>
                    {(string.IsNullOrEmpty(toDoItem.Description) ? "" : $"<p><strong>Opis:</strong> {toDoItem.Description}</p>")}
                    <p><strong>Status:</strong> {toDoItem.Status}</p>
                    <br>
                    <p>Powodzenia z wykonaniem zadania!</p>
                ";

                await emailService.SendNotificationEmailAsync(toDoItem.AssignedEmail, subject, body);

                toDoItem.Update(title: toDoItem.Title,
                                description: toDoItem.Description,
                                toDoDate: toDoItem.ToDoDate,
                                status: toDoItem.Status,
                                assignedEmail: toDoItem.AssignedEmail,
                                notifySended: true);
                dbContext.ToDoItems.Update(toDoItem);
                await dbContext.SaveChangesAsync();
                _logger.LogInformation("Notification sent for ToDo item '{Title}' to {Email}", toDoItem.Title, toDoItem.AssignedEmail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send notification for ToDo item '{Title}' to {Email}", toDoItem.Title, toDoItem.AssignedEmail);
            }
        }
    }
}
