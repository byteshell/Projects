using GitHubActivityCLI.Interfaces;
using GitHubActivityCLI.Repositories;

namespace GitHubActivityCLI.Commands.GitHubEvents
{
    internal class ListOrganizationEventsCommand(GitHubEventsRepository repository) : ICommand
    {
        private readonly GitHubEventsRepository _repository = repository;

        public async Task ExecuteAsync(string[] arguments)
        {
            if (arguments.Length < 1)
            {
                throw new ArgumentException("Organization must be provided.");
            }
                
            var organization = arguments[0];

            await _repository.ListOrganizationEvents(organization);
        }
    }

}
