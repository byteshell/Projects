using GitHubActivityCLI.Interfaces;
using GitHubActivityCLI.Repositories;

namespace GitHubActivityCLI.Commands.GitHubStarring
{
    internal class CheckIfRepositoryIsStarredByUserCommand(GitHubStarringRepository repository) : ICommand
    {
        private readonly GitHubStarringRepository _repository = repository;

        public async Task ExecuteAsync(string[] arguments)
        {
            if (arguments.Length < 2)
            {
                Console.WriteLine("Owner and repository name are required.");
                return;
            }

            await _repository.CheckIfRepositoryIsStarredByUser(arguments[0], arguments[1]);
        }
    }

}
