using System;
using TaskTrackerCLI.Repositories;
using ICommand = TaskTrackerCLI.Interfaces.ICommand;

namespace TaskTrackerCLI.Commands
{
    internal class ListTasksCommand : ICommand
    {
        public void Execute(string[] arguments, TaskRepository taskRepository)
        {
            if (arguments.Length > 0 && arguments[0].ToLower() == "list")
            {
                var tasks = taskRepository.GetAllTasks();

                if (tasks.Count == 0)
                {
                    Console.WriteLine("No tasks available.");
                }
                else
                {
                    Console.WriteLine("Tasks:");

                    foreach (var task in tasks)
                    {
                        Console.WriteLine($"ID: {task.Id}, Name: {task.Name}, Description: {task.Description}, Status: {task.Status}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Usage: task-cli list");
            }
        }
    }
}
