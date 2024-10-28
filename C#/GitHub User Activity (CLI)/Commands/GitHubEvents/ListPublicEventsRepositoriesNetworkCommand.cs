using GitHubActivityCLI.Repositories;
using GitHubActivityCLI.Interfaces;

namespace GitHubActivityCLI.Commands.GitHubEvents
{
    internal class ListPublicEventsRepositoriesNetworkCommand(GitHubEventsRepository repository) : ICommand
    {
        private readonly GitHubEventsRepository _repository = repository;

        public async Task ExecuteAsync(string[] arguments)
        {
            if (arguments.Length < 2)
            {
                throw new ArgumentException("Owner and repository must be provided.");
            }
            
            var owner = arguments[0];
            var repository = arguments[1];

            await _repository.ListPublicEventsRepositoriesNetwork(owner, repository);
        }
    }
}
