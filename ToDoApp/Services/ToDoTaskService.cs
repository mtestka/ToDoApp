using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Controllers;
using ToDoApp.Data;
using ToDoApp.Entities.Models;
using ToDoApp.ExceptionsTD;
using ToDoApp.Services.Notifications;

namespace ToDoApp.Services
{
	public class ToDoTaskService:IToDoTaskService
	{
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ToDoTaskService> _logger;
        private readonly INotificationService _notificationService;

        public ToDoTaskService(ApplicationDbContext dbContext, ILogger<ToDoTaskService> logger, INotificationService notificationService)
		{
            _dbContext = dbContext;
            _logger = logger;
            _notificationService = notificationService;
        }

        /// <summary>
        /// Add new ToDoTask to ToDo list
        /// </summary>
        /// <param name="task">Task to be added to ToDo list</param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task Add(ToDoTask task)
        {
            _logger.LogInformation("Adding new task to 'To Do' list.");

            if (task == null)
                throw new NotFoundException("ToDoTask is null");

            task.CreatedAt = DateTime.UtcNow;

            _dbContext.ToDoTasks.Add(task);

            await _notificationService.Add(task);

            await _dbContext.SaveChangesAsync();
        }
        /// <summary>
        /// Get all ToDoTasks
        /// </summary>
        /// <returns>List containing all of ToDoTasks</returns>
        public async Task<IEnumerable<ToDoTask>> GetAsync()
        {
            return await _dbContext.ToDoTasks.ToListAsync();
        }
        /// <summary>
        /// Get single ToDoTask by ID
        /// </summary>
        /// <param name="id">ID of ToDoTask to return</param>
        /// <returns>ToDoTask</returns>
        public async Task<ToDoTask> GetAsync(int id)
        {
            await EnsureTaskExists(id);

            return await _dbContext.ToDoTasks.FirstAsync(a => a.Id == id);
        }
        /// <summary>
        /// Remove ToDoTask by ID
        /// </summary>
        /// <param name="id">ID of ToDoTask to remove</param>
        /// <returns></returns>
        public async Task Remove(int id)
        {
            await EnsureTaskExists(id);

            var task = await _dbContext.ToDoTasks.FirstAsync(a => a.Id == id);

            _dbContext.Remove(task);

            await _dbContext.SaveChangesAsync();
        }
        /// <summary>
        /// Update ToDoTask
        /// </summary>
        /// <param name="task">New version of ToDoTask (Has to contain ID)</param>
        /// <returns></returns>
        public async Task Update(ToDoTask task)
        {
            await EnsureTaskExists(task.Id);

            task.UpdatedAt = DateTime.UtcNow;

            _dbContext.ToDoTasks.Update(task);

            await _dbContext.SaveChangesAsync();
        }
        /// <summary>
        /// Method to check if ToDoTask with given ID exists
        /// </summary>
        /// <param name="id">ID of ToDoTask</param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task EnsureTaskExists(int id)
        {
            var exists = await _dbContext.ToDoTasks.AnyAsync(a => a.Id == id);
            if (!exists)
                throw new NotFoundException("Task with given ID doesn't exist.");
        }
    }
}

