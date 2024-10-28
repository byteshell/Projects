using GitHubActivityCLI.Repositories;
using GitHubActivityCLI.Interfaces;

namespace GitHubActivityCLI.Commands.GitHubFeeds
{
    internal class GetFeedsCommand(GitHubFeedsRepository repository) : ICommand
    {
        private readonly GitHubFeedsRepository _repository = repository;

        public async Task ExecuteAsync(string[] arguments)
        {
            await _repository.GetFeeds();
        }
    }
}
