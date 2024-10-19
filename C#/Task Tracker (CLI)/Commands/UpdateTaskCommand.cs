using System;
using TaskTrackerCLI.Models;
using TaskTrackerCLI.Repositories;
using ICommand = TaskTrackerCLI.Interfaces.ICommand;

namespace TaskTrackerCLI.Commands
{
    internal class UpdateTaskCommand : ICommand
    {
        public void Execute(string[] arguments, TaskRepository taskRepository)
        {
            if (arguments.Length > 4)
            {
                if (int.TryParse(arguments[1], out var taskId))
                {
                    var taskName = arguments[2];
                    var taskDescription = arguments[3];

                    var updatedTask = new Task(taskId, taskName, taskDescription, TaskStatus.NotStarted);

                    taskRepository.EditTask(updatedTask);
                }
                else
                {
                    Console.WriteLine("Invalid input. Ensure that task ID is an integer.");
                }
            }
            else
            {
                Console.WriteLine("Usage: task-cli update <task_id> <task_name> <task_description> <task_status>");
            }
        }
    }
}
