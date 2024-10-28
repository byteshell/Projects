using GitHubActivityCLI.Interfaces;
using GitHubActivityCLI.Repositories;

namespace GitHubActivityCLI.Commands.GitHubStarring
{
    internal class ListUserStarredRepositoriesCommand(GitHubStarringRepository repository) : ICommand
    {
        private readonly GitHubStarringRepository _repository = repository;

        public async Task ExecuteAsync(string[] arguments)
        {
            await _repository.ListUserStarredRepositories();
        }
    }

}
