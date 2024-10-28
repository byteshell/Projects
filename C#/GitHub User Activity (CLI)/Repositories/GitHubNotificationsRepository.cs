using GitHubActivityCLI.Interfaces;
using GitHubActivityCLI.Utilities;

namespace GitHubActivityCLI.Repositories
{
    internal class GitHubNotificationsRepository : IGitHubNotificationsRepository
    {
        private static readonly HttpClient Client = new();

        public GitHubNotificationsRepository()
        {
            Client.DefaultRequestHeaders.Add("User-Agent", "CSharp-HttpClient");
        }

        private static async Task<string> FetchDataAsync(string url, HttpMethod method, HttpContent? content = null)
        {
            var request = new HttpRequestMessage(method, url) { Content = content };
            try
            {
                var response = await Client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine("Request error: " + exception.Message);
                throw;
            }
        }

        public async Task ListNotifications()
        {
            var responseBody = await FetchDataAsync(GitHubNotificationsApiLinks.GetFeeds, HttpMethod.Get);
            Console.WriteLine(responseBody);
        }

        public async Task MarkNotificationsAsRead()
        {
            await FetchDataAsync(GitHubNotificationsApiLinks.MarkNotificationsAsRead, HttpMethod.Put);
            Console.WriteLine("All notifications marked as read.");
        }

        public async Task GetThread(string threadId)
        {
            var responseBody = await FetchDataAsync(GitHubNotificationsApiLinks.GetThread(int.Parse(threadId)), HttpMethod.Get);
            Console.WriteLine(responseBody);
        }

        public async Task MarkThreadAsRead(string threadId)
        {
            await FetchDataAsync(GitHubNotificationsApiLinks.MarkThreadAsRead(int.Parse(threadId)), HttpMethod.Patch);
            Console.WriteLine($"Thread {threadId} marked as read.");
        }

        public async Task MarkThreadAsDone(string threadId)
        {
            await FetchDataAsync(GitHubNotificationsApiLinks.MarkThreadAsDone(int.Parse(threadId)), HttpMethod.Patch);
            Console.WriteLine($"Thread {threadId} marked as done.");
        }

        public async Task SetThreadSubscription(string threadId)
        {
            var content = new StringContent("{\"subscribed\": true, \"ignored\": false}");
            await FetchDataAsync(GitHubNotificationsApiLinks.SetThreadSubscription(int.Parse(threadId)), HttpMethod.Put, content);
            Console.WriteLine($"Subscribed to thread {threadId}.");
        }

        public async Task DeleteThreadSubscription(string threadId)
        {
            await FetchDataAsync(GitHubNotificationsApiLinks.DeleteThreadSubscription(int.Parse(threadId)), HttpMethod.Delete);
            Console.WriteLine($"Subscription deleted for thread {threadId}.");
        }

        public async Task ListRepositoryNotifications(string owner, string repository)
        {
            var responseBody = await FetchDataAsync(GitHubNotificationsApiLinks.ListRepositoryNotifications(owner, repository), HttpMethod.Get);
            Console.WriteLine(responseBody);
        }

        public async Task MarkRepositoryNotificationsAsRead(string owner, string repository)
        {
            await FetchDataAsync(GitHubNotificationsApiLinks.MarkRepositoryNotificationsAsRead(owner, repository), HttpMethod.Put);
            Console.WriteLine($"All notifications marked as read for repository {owner}/{repository}.");
        }
    }
}