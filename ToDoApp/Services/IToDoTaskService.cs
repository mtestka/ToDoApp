using System;
using ToDoApp.Entities.Models;

namespace ToDoApp.Services
{
	public interface IToDoTaskService
	{
		Task<IEnumerable<ToDoTask>> GetAsync(DateTime? date);
		Task<ToDoTask> GetAsync(int id);
		Task Add(ToDoTask task);
		Task Update(ToDoTask task);
		Task Remove(int id);
        Task CheckTask(int id);
        Task UncheckTask(int id);
        Task EnsureTaskExists(int id);
	}
}

