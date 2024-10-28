using GitHubActivityCLI.Interfaces;
using GitHubActivityCLI.Repositories;

namespace GitHubActivityCLI.Commands.GitHubEvents
{
    internal class ListUserOrganizationEventsCommand(GitHubEventsRepository repository) : ICommand
    {
        private readonly GitHubEventsRepository _repository = repository;

        public async Task ExecuteAsync(string[] arguments)
        {
            if (arguments.Length < 2)
            {
                throw new ArgumentException("Username and organization must be provided.");
            }
                
            var username = arguments[0];
            var organization = arguments[1];

            await _repository.ListUserOrganizationEvents(username, organization);
        }
    }
}
