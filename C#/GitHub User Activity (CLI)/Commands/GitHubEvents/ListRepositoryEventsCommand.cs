using GitHubActivityCLI.Interfaces;
using GitHubActivityCLI.Repositories;

namespace GitHubActivityCLI.Commands.GitHubEvents
{
    internal class ListRepositoryEventsCommand(GitHubEventsRepository repository) : ICommand
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

            await _repository.ListRepositoryEvents(owner, repository);
        }
    }
}
