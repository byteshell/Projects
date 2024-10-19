using System;

namespace TaskTrackerCLI.Models
{
    public enum TaskStatus
    {
        NotStarted,
        InProgress,
        Done
    }

    internal class Task(int id, string name, string description, TaskStatus status)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public TaskStatus Status { get; set; } = status;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
