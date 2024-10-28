using GitHubActivityCLI.Interfaces;
using GitHubActivityCLI.Repositories;

namespace GitHubActivityCLI.Commands.GitHubWatching
{
    internal class ListRepositoriesWatchedByUserCommand(GitHubWatchingRepository repository) : ICommand
    {
        private readonly GitHubWatchingRepository _repository = repository;

        public async Task ExecuteAsync(string[] arguments)
        {
            await _repository.ListRepositoriesWatchedByUser();
        }
    }
}
