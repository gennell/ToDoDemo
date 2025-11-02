using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Services;
using ToDoList.Infrastructure.Data;
using ToDoList.Infrastructure.Email;

namespace ToDoList.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAppDbContext, AppDbContext>();

            // Email configuration
            var emailSettings = configuration.GetSection("EmailSettings").Get<EmailSettings>();
            services.AddSingleton(emailSettings!);
            services.AddScoped<IEmailService, EmailService>();

            // Background service
            services.AddHostedService<ToDoNotificationService>();

            return services;
        }
    }
}