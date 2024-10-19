using System.Collections.Generic;
using System.Reflection;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Interfaces
{
    internal interface ITaskRepository
    {
        List<Task> GetAllTasks();
        void AddTask(Task task);
        void SaveTasks(List<Task> tasks);
        void EditTask(Task task);
        Task GetById(int id);
        void DeleteTask(int id);
        List<Task> GetTasksByStatus(TaskStatus status);
    }
}
