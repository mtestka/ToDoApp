using System;
namespace ToDoApp.Entities.Models
{
	public class Notification
	{
        public int Id { get; set; }
        public string Message => "New notification";
        public ToDoTask ToDoTask { get; set; }
        public DateTime Timestamp { get; set; }
	}
}

