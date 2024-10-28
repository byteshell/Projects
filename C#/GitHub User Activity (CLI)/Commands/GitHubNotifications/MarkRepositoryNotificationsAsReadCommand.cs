using GitHubActivityCLI.Repositories;
using GitHubActivityCLI.Interfaces;

namespace GitHubActivityCLI.Commands.GitHubNotifications
{
    internal class MarkRepositoryNotificationsAsReadCommand(GitHubNotificationsRepository repository) : ICommand
    {
        private readonly GitHubNotificationsRepository _repository = repository;

        public async Task ExecuteAsync(string[] arguments)
        {
            if (arguments.Length < 2)
            {
                Console.WriteLine("Owner and repository name are required.");
                return;
            }

            await _repository.MarkRepositoryNotificationsAsRead(arguments[0], arguments[1]);
        }
    }

}
