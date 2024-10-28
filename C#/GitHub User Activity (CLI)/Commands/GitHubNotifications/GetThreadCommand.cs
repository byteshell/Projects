using GitHubActivityCLI.Repositories;
using GitHubActivityCLI.Interfaces;

namespace GitHubActivityCLI.Commands.GitHubNotifications
{
    internal class GetThreadCommand(GitHubNotificationsRepository repository) : ICommand
    {
        private readonly GitHubNotificationsRepository _repository = repository;

        public async Task ExecuteAsync(string[] arguments)
        {
            if (arguments.Length == 0)
            {
                Console.WriteLine("Thread ID is required.");
                return;
            }

            await _repository.GetThread(arguments[0]);
        }
    }
}
