using System;
using TaskTrackerCLI.Interfaces;
using TaskTrackerCLI.Repositories;

namespace TaskTrackerCLI.Commands
{
    internal class MarkDoneCommand : ICommand
    {
        public void Execute(string[] arguments, TaskRepository taskRepository)
        {
            if (arguments.Length > 1 && int.TryParse(arguments[1], out var taskId))
            {
                taskRepository.MarkTaskDone(taskId);
            }
            else
            {
                Console.WriteLine("Usage: task-cli mark-done <task_id>");
            }
        }
    }
}