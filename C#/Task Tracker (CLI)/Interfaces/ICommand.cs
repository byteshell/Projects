using TaskTrackerCLI.Repositories;

namespace TaskTrackerCLI.Interfaces
{
    internal interface ICommand
    {
        void Execute(string[] arguments, TaskRepository taskRepository);
    }
}
