using System;
using System.Collections.Generic;
using System.IO;
using TaskTrackerCLI.Interfaces;
using Newtonsoft.Json;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Repositories
{
    internal class TaskRepository : ITaskRepository
    {
        private const string FilePath = "tasks.json";
            
        public List<Task> GetAllTasks()
        {
            if (!File.Exists(FilePath))
            {
                return [];
            }

            var json = File.ReadAllText(FilePath);

            return JsonConvert.DeserializeObject<List<Task>>(json) ?? [];
        }

        public void AddTask(Task task)
        {
            var tasks = GetAllTasks(); 

            tasks.Add(task);

            SaveTasks(tasks);
        }

        public void SaveTasks(List<Task> tasks)
        {
            var json = JsonConvert.SerializeObject(tasks, Formatting.Indented);

            File.WriteAllText(FilePath, json);
        }

        public Task GetById(int id)
        {
            var tasks = GetAllTasks();

            return tasks.Find(task => task.Id == id);
        }

        public void EditTask(Task updatedTask)
        {
            var tasks = GetAllTasks();

            var task = tasks.Find(t => t.Id == updatedTask.Id);

            if (task != null)
            {
                task.Name = updatedTask.Name;
                task.Description = updatedTask.Description;
                task.Status = updatedTask.Status;

                SaveTasks(tasks);

                Console.WriteLine($"Task ID {updatedTask.Id} updated successfully.");
            }
            else
            {
                Console.WriteLine($"Task with ID {updatedTask.Id} not found.");
            }
        }

        public void DeleteTask(int id)
        {
            var tasks = GetAllTasks();

            var taskToRemove = tasks.Find(task => task.Id == id);

            if (taskToRemove != null)
            {
                tasks.Remove(taskToRemove);
                
                SaveTasks(tasks);

                Console.WriteLine($"Task ID {id} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Task with ID {id} not found.");
            }
        }

        public List<Task> GetTasksByStatus(TaskStatus status)
        {
            var tasks = GetAllTasks();

            return tasks.FindAll(task => task.Status == status);
        }

        public void MarkTaskInProgress(int id)
        {
            var tasks = GetAllTasks();

            var taskToUpdate = tasks.Find(task => task.Id == id);

            if (taskToUpdate != null)
            {
                taskToUpdate.Status = TaskStatus.InProgress;

                SaveTasks(tasks);

                Console.WriteLine($"Task ID {id} marked as in progress.");
            }
            else
            {
                Console.WriteLine($"Task with ID {id} not found.");
            }
        }

        public void MarkTaskDone(int id)
        {
            var tasks = GetAllTasks();

            var taskToUpdate = tasks.Find(task => task.Id == id);

            if (taskToUpdate != null)
            {
                taskToUpdate.Status = TaskStatus.Done;

                SaveTasks(tasks);

                Console.WriteLine($"Task ID {id} marked as done.");
            }
            else
            {
                Console.WriteLine($"Task with ID {id} not found.");
            }
        }
    }
}
