using Microsoft.EntityFrameworkCore;
using NuGet.Frameworks;
using ToDoApp.Data;
using ToDoApp.Entities.Models;
using ToDoApp.Services;

namespace ToDoApp.Tests;

public class Tests
{
    private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: "ToDoTest")
        .Options;

    ApplicationDbContext _dbContext;

    [OneTimeSetUp]
    public void Setup()
    {
        _dbContext = new ApplicationDbContext(dbContextOptions);
        _dbContext.Database.EnsureCreated();
        SeedDatabase();
    }

    [OneTimeTearDown]
    public void CleanUp()
    {
        _dbContext.Database.EnsureDeleted();
    }

    void SeedDatabase()
    {
        var todotasks = new List<ToDoTask>
        {
            new ToDoTask()
            {
                Id = 1,
                Name = "Clean house",
                Description = "Clean all rooms in house",
                CreatedAt = DateTime.UtcNow,
                EventDate = new DateTime(2023, 8, 15)
            },
            new ToDoTask()
            {
                Id = 2,
                Name = "Walk a dog",
                Description = "Walk a dog for minimum time of 30 minutes",
                CreatedAt = DateTime.UtcNow,
                CompletedAt = DateTime.UtcNow.AddMinutes(5),
                EventDate = new DateTime(2023, 8, 16)
            },
            new ToDoTask()
            {
                Id = 3,
                Name = "Make breakfast",
                Description = "Make breakfast for all family members",
                CreatedAt = DateTime.UtcNow,
                EventDate = new DateTime(2023, 8, 15)
            }
        };

        _dbContext.AddRange(todotasks);
        _dbContext.SaveChanges();
    }

    [Test]
    public async Task ToDoTaskCheckTest()
    {
        ToDoTaskService tdtService = new ToDoTaskService(_dbContext, null, null);
        await tdtService.CheckTask(1);

        if (_dbContext.ToDoTasks.First(a => a.Id == 1).IsCompleted)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }

    [Test]
    public async Task ToDoTaskUncheckTest()
    {
        ToDoTaskService tdtService = new ToDoTaskService(_dbContext, null, null);
        await tdtService.UncheckTask(2);

        if (_dbContext.ToDoTasks.First(a => a.Id == 2).IsCompleted)
        {
            Assert.Fail();
        }
        else
        {
            Assert.Pass();
        }
    }
}
