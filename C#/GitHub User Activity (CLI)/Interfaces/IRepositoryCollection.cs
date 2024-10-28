namespace GitHubActivityCLI.Interfaces
{
    internal interface IRepositoryCollection
    {
        IGitHubEventsRepository EventsRepository { get; set; }
        IGitHubFeedsRepository FeedsRepository { get; set; }
        IGitHubNotificationsRepository NotificationsRepository { get; set; }
        IGitHubStarringRepository StarringRepository { get; set; }
        IGitHubWatchingRepository WatchingRepository { get; set; }
    }
}
