namespace GitHubActivityCLI.Interfaces
{
    internal interface IGitHubStarringRepository
    {
        Task ListStargazers(string owner, string repository);
        Task ListUserStarredRepositories();
        Task CheckIfRepositoryIsStarredByUser(string owner, string repository);
        Task StarRepository(string owner, string repository);
        Task UnstarRepository(string owner, string repository);
        Task ListRepositoriesStarredByUser(string username);
    }
}
