namespace GitHubActivityCLI.Utilities
{
    internal class GitHubWatchingApiLinks
    {
        private const string BaseUrl = "https://api.github.com/";

        public static string ListWatchers(string owner, string repository)
            => BaseUrl + $"repos/{owner}/{repository}/subscribers";

        public static string GetRepositorySubscription(string owner, string repository)
            => BaseUrl + $"repos/{owner}/{repository}/subscription";

        public static string SetRepositorySubscription(string owner, string repository)
            => BaseUrl + $"repos/{owner}/{repository}/subscription";

        public static string DeleteRepositorySubscription(string owner, string repository)
            => BaseUrl + $"repos/{owner}/{repository}/subscription";

        public static string ListWatchedRepositories()
            => BaseUrl + "user/subscriptions";

        public static string ListRepositoriesWatchedByUser(string username)
            => BaseUrl + $"/users/{username}/subscriptions";
    }
}
