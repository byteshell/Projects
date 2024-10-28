namespace GitHubActivityCLI.Interfaces
{
    internal interface IGitHubEventsRepository
    {
        Task ListPublicEvents();
        Task ListPublicEventsRepositoriesNetwork(string owner, string repository);
        Task ListOrganizationEvents(string organization);
        Task ListRepositoryEvents(string owner, string repository);
        Task ListUserEvents(string username);
        Task ListUserOrganizationEvents(string username, string organization);
        Task ListUserPublicEvents(string username);
        Task ListUserReceivedEvents(string username);
        Task ListUserReceivedPublicEvents(string username);
    }
}
