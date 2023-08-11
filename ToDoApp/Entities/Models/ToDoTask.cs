using System;
using System.ComponentModel.DataAnnotations;

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
		public string? Description { get; set; }
		public Color Color { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        public DateTime EventDate { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        public DateTime CompletedAt { get; set; }
		public bool IsCompleted => CompletedAt != DateTime.MinValue;
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        public DateTime UpdatedAt { get; set; }
		public bool Notify { get; set; }

		public ToDoTask()
		{
			Color = Color.Default;
		}
	}
}

