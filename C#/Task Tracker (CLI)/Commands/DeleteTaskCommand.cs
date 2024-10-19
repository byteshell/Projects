using System;
using TaskTrackerCLI.Repositories;
using ICommand = TaskTrackerCLI.Interfaces.ICommand;

namespace TaskTrackerCLI.Commands
{
    internal class DeleteTaskCommand : ICommand
    {
        public void Execute(string[] arguments, TaskRepository taskRepository)
        {
            if (arguments.Length > 1 && arguments[0].ToLower() == "delete")
            {
                if (int.TryParse(arguments[1], out var taskId))
                {
                    taskRepository.DeleteTask(taskId);
                }
            }
            else
            {
                Console.WriteLine("Usage: task-cli delete <task_id>");
            }
        }
    }
}
