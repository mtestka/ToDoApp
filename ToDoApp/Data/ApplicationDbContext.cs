using System;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Entities.Models;

namespace ToDoApp.Data
{
	public class ApplicationDbContext:DbContext
	{
		public DbSet<ToDoTask> ToDoTasks { get; set; }
		public DbSet<Notification> Notifications { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
		{

		}
	}
}

