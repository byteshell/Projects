using GitHubActivityCLI.Repositories;
using GitHubActivityCLI.Interfaces;

namespace GitHubActivityCLI.Commands.GitHubEvents
{
    internal class ListUserEventsCommand(GitHubEventsRepository repository) : ICommand
    {
        private readonly GitHubEventsRepository _repository = repository;

        public async Task ExecuteAsync(string[] arguments)
        {
            if (arguments.Length < 1)
            {
                throw new ArgumentException("Username must be provided.");
            }
                
            var username = arguments[0];

            await _repository.ListUserEvents(username);
        }
    }
}
