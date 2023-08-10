using System;
using ToDoApp.Entities.Models;

namespace ToDoApp.Services.Notifications
{
	public interface INotificationService
	{
		Task Add(ToDoTask task);
	}
}

