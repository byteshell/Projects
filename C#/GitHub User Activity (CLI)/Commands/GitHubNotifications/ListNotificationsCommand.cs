using GitHubActivityCLI.Repositories;
using GitHubActivityCLI.Interfaces;

namespace GitHubActivityCLI.Commands.GitHubNotifications
{
    internal class ListNotificationsCommand(GitHubNotificationsRepository repository) : ICommand
    {
        private readonly GitHubNotificationsRepository _repository = repository;

        public async Task ExecuteAsync(string[] arguments)
        {
            await _repository.ListNotifications();
        }
    }
}
