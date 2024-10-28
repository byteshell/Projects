using GitHubActivityCLI.Interfaces;
using GitHubActivityCLI.Repositories;

namespace GitHubActivityCLI.Commands.GitHubStarring
{
    internal class ListRepositoriesStarredByUserCommand(GitHubStarringRepository repository) : ICommand
    {
        private readonly GitHubStarringRepository _repository = repository;

        public async Task ExecuteAsync(string[] arguments)
        {
            var username = arguments.Length > 0 ? arguments[0] : string.Empty;

            await _repository.ListRepositoriesStarredByUser(username);
        }
    }

}
