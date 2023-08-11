using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ToDoApp.Data;
using ToDoApp.Services.Notifications;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Entities.Models;

public class ScheduledNotificationService : BackgroundService
{
    private readonly IServiceProvider _services;
    private readonly ILogger<ScheduledNotificationService> _logger;

    public ScheduledNotificationService(IServiceProvider services, ILogger<ScheduledNotificationService> logger)
    {
        _services = services;
        _logger = logger;
    }

    /// <summary>
    /// Background service that runs infinitly, checking each minute if any datetime of notifications is lower than datetime now (with margin of 15mins),
    /// in case that any notifications with passed query are found, notifications are sent to app user and removed from database.
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("ScheduledNotificationService is running.");

        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var now = DateTime.UtcNow.AddMinutes(15);
                var notificationsToSend = dbContext.Notifications
                    .Where(n => n.Timestamp <= now)
                    .ToList();

                var hubContext = scope.ServiceProvider.GetRequiredService<IHubContext<NotificationHub>>();

                if (notificationsToSend.Count > 0)
                {

                    foreach (var notification in notificationsToSend)
                    {
                        await hubContext.Clients.All.SendAsync("ReceiveNotification", notification);
                        Console.WriteLine("NOtification sent");
                        //dbContext.Notifications.Remove(notification);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }

            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}
