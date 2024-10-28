using GitHubActivityCLI.Interfaces;
using GitHubActivityCLI.Repositories;

namespace GitHubActivityCLI.Commands.GitHubWatching
{
    internal class GetRepositorySubscriptionCommand(GitHubWatchingRepository repository) : ICommand
    {
        private readonly GitHubWatchingRepository _repository = repository;

        public async Task ExecuteAsync(string[] arguments)
        {
            if (arguments.Length < 2)
            {
                Console.WriteLine("Usage: GetRepositorySubscription <owner> <repository>");
                return;
            }

            var owner = arguments[0];
            var repository = arguments[1];

            await _repository.GetRepositorySubscription(owner, repository);
        }
    }
}
