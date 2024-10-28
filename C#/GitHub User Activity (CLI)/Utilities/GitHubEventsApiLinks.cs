namespace GitHubActivityCLI.Utilities
{
    public static class GitHubEventsApiLinks
    {
        private const string BaseUrl = "https://api.github.com/";

        public static string PublicEvents => BaseUrl + "events";

        public static string ListPublicEventsRepositoriesNetwork(string owner, string repo)
            => BaseUrl + $"networks/{owner}/{repo}/events";

        public static string ListOrganizationEvents(string organization)
            => BaseUrl + $"orgs/{organization}/events";

        public static string ListRepositoryEvents(string owner, string repository)
            => BaseUrl + $"repos/{owner}/{repository}/events";

        public static string ListUserEvents(string username) 
            => BaseUrl + $"users/{username}/events";

        public static string ListUserOrganizationEvents(string username, string organization)
            => BaseUrl + $"users/{username}/events/orgs/{organization}";

        public static string ListUserPublicEvents(string username) 
            => BaseUrl + $"users/{username}/events/public";

        public static string ListUserReceivedEvents(string username)
            => BaseUrl + $"users/{username}/received_events";

        public static string ListUserReceivedPublicEvents(string username)
            => BaseUrl + $"/users/{username}/received_events/public";
    }
}
