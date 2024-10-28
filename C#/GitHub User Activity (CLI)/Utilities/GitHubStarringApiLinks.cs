namespace GitHubActivityCLI.Utilities
{
    internal class GitHubStarringApiLinks
    {
        private const string BaseUrl = "https://api.github.com/";

        public static string ListStargazers(string owner, string repository)
            => BaseUrl + $"repos/{owner}/{repository}/stargazers";

        public static string ListRepositoriesStarred()
            => BaseUrl + $"user/starred";

        public static string CheckIfUserStarredRepository(string owner, string repository)
            => BaseUrl + $"user/starred/{owner}/{repository}";

        public static string StarARepositoryForAuthenticatedUser(string owner, string repository)
            => BaseUrl + $"user/starred/{owner}/{repository}";

        public static string UnstarARepositoryForAuthenticatedUser(string owner, string repository)
            => BaseUrl + $"user/starred/{owner}/{repository}";

        public static string ListUserStarredRepositories(string username)
            => BaseUrl + $"users/{username}/starred";
    }
}
