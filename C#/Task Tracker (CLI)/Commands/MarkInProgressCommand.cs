using System;
using TaskTrackerCLI.Interfaces;
using TaskTrackerCLI.Repositories;

namespace TaskTrackerCLI.Commands
{
    internal class MarkInProgressCommand : ICommand
    {
        public void Execute(string[] arguments, TaskRepository taskRepository)
        {
            if (arguments.Length > 1 && int.TryParse(arguments[1], out var taskId))
            {
                taskRepository.MarkTaskInProgress(taskId);
            }
            else
            {
                Console.WriteLine("Usage: task-cli mark-in-progress <task_id>");
            }
        }
    }
}