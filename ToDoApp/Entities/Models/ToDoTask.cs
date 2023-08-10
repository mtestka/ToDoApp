using System;
namespace ToDoApp.Entities.Models
{
	public enum Color
	{
		Default,
		Blue,
		Red,
		Green,
		Yellow
	}

	public class ToDoTask
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Color Color { get; set; }
		public DateTime EventTime { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		public ToDoTask()
		{
			Color = Color.Default;
		}
	}
}

