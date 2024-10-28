namespace GitHubActivityCLI.Utilities
{
    public static class GitHubNotificationsApiLinks
    {
        private const string BaseUrl = "https://api.github.com/";

        public static string GetFeeds => BaseUrl + "notifications";

        public static string MarkNotificationsAsRead
            => BaseUrl + "notifications";

        public static string GetThread(int threadId) 
            => BaseUrl + $"notifications/threads/{threadId}";

        public static string MarkThreadAsRead(int threadId)
            => BaseUrl + $"notifications/threads/{threadId}";

        public static string MarkThreadAsDone(int threadId)
            => BaseUrl + $"notifications/threads/{threadId}";

        public static string GetThreadSubscription(int threadId)
            => BaseUrl + $"notifications/threads/{threadId}/subscription";

        public static string SetThreadSubscription(int threadId)
            => BaseUrl + $"notifications/threads/{threadId}/subscription";

        public static string DeleteThreadSubscription(int threadId)
            => BaseUrl + $"notifications/threads/{threadId}/subscription";

        public static string ListRepositoryNotifications(string owner, string repository)
            => BaseUrl + $"repos/{owner}/{repository}/notifications";

        public static string MarkRepositoryNotificationsAsRead(string owner, string repository)
            => BaseUrl + $"repos/{owner}/{repository}/notifications";
    }
}