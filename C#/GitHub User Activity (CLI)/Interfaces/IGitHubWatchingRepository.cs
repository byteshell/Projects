namespace GitHubActivityCLI.Interfaces
{
    internal interface IGitHubWatchingRepository
    {
        Task ListWatchers(string owner, string repository);
        Task GetRepositorySubscription(string owner, string repository);
        Task SetRepositorySubscription(string owner, string repository);
        Task DeleteRepositorySubscription(string owner, string repository);
        Task ListRepositoriesWatchedByUser();
    }
}
