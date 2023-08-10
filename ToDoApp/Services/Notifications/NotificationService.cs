using System;
using System.Threading.Tasks;
using ToDoApp.Data;
using ToDoApp.Entities.Models;
using ToDoApp.ExceptionsTD;

namespace ToDoApp.Services.Notifications
{
	public class NotificationService:INotificationService
	{
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ToDoTaskService> _logger;

        public NotificationService(ApplicationDbContext dbContext, ILogger<ToDoTaskService> logger)
		{
            _dbContext = dbContext;
            _logger = logger;
		}
        /// <summary>
        /// Add new notification to database, based on ToDoTask connected with it
        /// </summary>
        /// <param name="task">ToDoTask serving as a base for notification</param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task Add(ToDoTask task)
        {
            _logger.LogInformation("Adding new notification to database.");

            if (task == null)
                throw new NotFoundException("ToDo task is null");

            Notification notification = new Notification()
            {
                ToDoTask = task,
                Timestamp = task.EventTime
            };

            _dbContext.Notifications.Add(notification);

            await _dbContext.SaveChangesAsync();
        }
    }
}

