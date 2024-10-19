using System;
using TaskTrackerCLI.Interfaces;
using TaskTrackerCLI.Models;
using TaskTrackerCLI.Repositories;

namespace TaskTrackerCLI.Commands
{
    internal class ListNotDoneTasksCommand : ICommand
    {
        public void Execute(string[] arguments, TaskRepository taskRepository)
        {
            if (arguments.Length > 1)
            {
                var tasks = taskRepository.GetTasksByStatus(TaskStatus.NotStarted);

                Console.WriteLine("Tasks which are not done:");

                if (tasks.Count == 0)
                {
                    Console.WriteLine("No not done tasks available.");
                }
                else
                {
                    foreach (var task in tasks)
                    {
                        Console.WriteLine($"ID: {task.Id}, Name: {task.Name}, Description: {task.Description}, Status: {task.Status}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Usage: task-cli list-not-done");
            }
        }
    }
}
