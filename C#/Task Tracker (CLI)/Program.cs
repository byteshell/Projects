using System;
using TaskTrackerCLI.Commands;
using TaskTrackerCLI.Interfaces;
using TaskTrackerCLI.Repositories;

namespace TaskTrackerCLI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var taskRepository = new TaskRepository();

            if (args.Length == 0)
            {
                Console.WriteLine("No command provided. Use 'add', 'show', 'edit' or 'delete'.");

                return;
            }

            var commandName = args[0].ToLower();

            ICommand command = commandName switch
            {
                "add" => new AddTaskCommand(),
                "delete" => new DeleteTaskCommand(),
                "update" => new UpdateTaskCommand(),
                "list-done" => new ListDoneTasksCommand(),
                "list-not-done" => new ListNotDoneTasksCommand(),
                "list-in-progress" => new ListInProgressTasksCommand(),
                "mark-in-progress" => new MarkInProgressCommand(),
                "mark-done" => new MarkDoneCommand(),
                _ => null
            };

            if (command == null)
            {
                Console.WriteLine($"Unknown command: {commandName}");
                return;
            }

            command.Execute(args, taskRepository);
        }
    }
}
