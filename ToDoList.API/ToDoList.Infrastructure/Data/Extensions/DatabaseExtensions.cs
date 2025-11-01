using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoList.Infrastructure.Data.Extensions;

public static class DatabaseExtensions
{
    public static async Task<WebApplication> InitializeDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await context.Database.MigrateAsync();
        return app;
    }

    public static async Task<WebApplication> SeedDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (!context.ToDoItems.Any())
        {
            context.ToDoItems.AddRange(InitializeData.ToDoItems);
            await context.SaveChangesAsync();
        }
        return app;
    }
}
