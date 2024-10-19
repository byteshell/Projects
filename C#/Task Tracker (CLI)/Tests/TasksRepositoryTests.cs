using System.IO;
using TaskTrackerCLI.Models;
using TaskTrackerCLI.Repositories;
using Xunit;

namespace TaskTrackerCLI.Tests
{
    public class TaskRepositoryTests
    {
        private const string TestFilePath = "test_tasks.json";
        private readonly TaskRepository _repository;

        public TaskRepositoryTests()
        {
            _repository = new TaskRepository();

            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }

        [Fact]
        public void AddTask_Should_Add_Task()
        {
            var task = new Task(1, "Test Task", "Test Description", TaskStatus.NotStarted);

            _repository.AddTask(task);

            var tasks = _repository.GetAllTasks();

            Assert.Single(tasks);
            Assert.Equal("Test Task", tasks[0].Name);
            Assert.Equal("Test Description", tasks[0].Description);
        }

        [Fact]
        public void DeleteTask_Should_Remove_Task()
        {
            var task = new Task(1, "Test Task", "Test Description", TaskStatus.NotStarted);
            
            _repository.AddTask(task);

            _repository.DeleteTask(1);

            var tasks = _repository.GetAllTasks();

            Assert.Empty(tasks);
        }

        public void Dispose()
        {
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }
    }
}