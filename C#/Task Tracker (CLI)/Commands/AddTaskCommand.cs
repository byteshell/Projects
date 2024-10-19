using System;
using TaskTrackerCLI.Interfaces;
using TaskTrackerCLI.Repositories;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Commands
{
    internal class AddTaskCommand : ICommand
    {
        public void Execute(string[] arguments, TaskRepository taskRepository)
        {
            if (arguments.Length > 2)
            {
                var taskName = arguments[1];
                var taskDescription = arguments[2];

                var allTasks = taskRepository.GetAllTasks();

                var newId = allTasks.Count > 0 ? allTasks[allTasks.Count - 1].Id + 1 : 1;

                var newTask = new Task(newId, taskName, taskDescription, TaskStatus.NotStarted);

                taskRepository.AddTask(newTask);

                Console.WriteLine($"Task '{taskName}' added successfully with new {newId}");
            }
            else
            {
                Console.WriteLine("Usage: task-cli add <task_name> <task_description>");
            }
        }
    }
}
