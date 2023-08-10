using System;
using ToDoApp.Entities.Models;

namespace ToDoApp.Services
{
	public interface IToDoTaskService
	{
		Task<IEnumerable<ToDoTask>> GetAsync();
		Task<ToDoTask> GetAsync(int id);
		Task Add(ToDoTask task);
		Task Update(ToDoTask task);
		Task Remove(int id);
		Task EnsureTaskExists(int id);
	}
}

