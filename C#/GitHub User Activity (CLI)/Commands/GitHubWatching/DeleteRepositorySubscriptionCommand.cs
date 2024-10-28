using GitHubActivityCLI.Interfaces;
using GitHubActivityCLI.Repositories;

namespace GitHubActivityCLI.Commands.GitHubWatching
{
    internal class DeleteRepositorySubscriptionCommand(GitHubWatchingRepository repository) : ICommand
    {
        private readonly GitHubWatchingRepository _repository = repository;

        public async Task ExecuteAsync(string[] arguments)
        {
            if (arguments.Length < 2)
            {
                Console.WriteLine("Usage: DeleteRepositorySubscription <owner> <repository>");
                return;
            }

            var owner = arguments[0];
            var repository = arguments[1];

            await _repository.DeleteRepositorySubscription(owner, repository);
        }
    }
}
