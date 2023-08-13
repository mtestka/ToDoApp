using System;
namespace ToDoApp.Entities.Models
{
	public class Notification
	{
        public int Id { get; set; }
        public string Message => ToDoTask?.Name;
        public ToDoTask ToDoTask { get; set; }
        public DateTime Timestamp { get; set; }
	}
}

