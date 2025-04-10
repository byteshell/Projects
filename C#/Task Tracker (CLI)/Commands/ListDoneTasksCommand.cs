﻿using System;
using TaskTrackerCLI.Interfaces;
using TaskTrackerCLI.Repositories;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Commands
{
    internal class ListDoneTasksCommand : ICommand
    {
        public void Execute(string[] arguments, TaskRepository taskRepository)
        {
            if (arguments.Length > 1)
            {
                var tasks = taskRepository.GetTasksByStatus(TaskStatus.Done);

                Console.WriteLine("Tasks which are done:");

                if (tasks.Count == 0)
                {
                    Console.WriteLine("No done tasks available.");
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
                Console.WriteLine("Usage: task-cli list-done");
            }
        }
    }
}
