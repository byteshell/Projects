namespace GitHubActivityCLI.Interfaces
{
    internal interface ICommand
    {
        Task ExecuteAsync(string[] arguments);
    }
}