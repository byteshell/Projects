namespace GitHubActivityCLI.Interfaces
{
    internal interface IGitHubNotificationsRepository
    {
        Task ListNotifications();
        Task MarkNotificationsAsRead();
        Task GetThread(string threadId);
        Task MarkThreadAsRead(string threadId);
        Task MarkThreadAsDone(string threadId);
        Task SetThreadSubscription(string threadId);
        Task DeleteThreadSubscription(string threadId);
        Task ListRepositoryNotifications(string owner, string repository);
        Task MarkRepositoryNotificationsAsRead(string owner, string repository);
    }
}
