using GitHubActivityCLI.Interfaces;
using GitHubActivityCLI.Utilities;

namespace GitHubActivityCLI.Repositories
{
    internal class GitHubWatchingRepository : IGitHubWatchingRepository
    {
        private static readonly HttpClient Client = new();

        public GitHubWatchingRepository()
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

        public async Task ListWatchers(string owner, string repository)
        {
            var responseBody = await FetchDataAsync(GitHubWatchingApiLinks.ListWatchers(owner, repository), HttpMethod.Get);
            Console.WriteLine(responseBody);
        }

        public async Task GetRepositorySubscription(string owner, string repository)
        {
            var responseBody = await FetchDataAsync(GitHubWatchingApiLinks.GetRepositorySubscription(owner, repository), HttpMethod.Get);
            Console.WriteLine(responseBody);
        }

        public async Task SetRepositorySubscription(string owner, string repository)
        {
            var content = new StringContent("{\"subscribed\": true, \"ignored\": false}");
            await FetchDataAsync(GitHubWatchingApiLinks.SetRepositorySubscription(owner, repository), HttpMethod.Put, content);
            Console.WriteLine($"Subscribed to repository {owner}/{repository}.");
        }

        public async Task DeleteRepositorySubscription(string owner, string repository)
        {
            await FetchDataAsync(GitHubWatchingApiLinks.DeleteRepositorySubscription(owner, repository), HttpMethod.Delete);
            Console.WriteLine($"Unsubscribed from repository {owner}/{repository}.");
        }

        public async Task ListRepositoriesWatchedByUser()
        {
            var responseBody = await FetchDataAsync(GitHubWatchingApiLinks.ListWatchedRepositories(), HttpMethod.Get);
            Console.WriteLine(responseBody);
        }

        public static async Task ListRepositoriesWatchedByUser(string username)
        {
            var responseBody = await FetchDataAsync(GitHubWatchingApiLinks.ListRepositoriesWatchedByUser(username), HttpMethod.Get);
            Console.WriteLine(responseBody);
        }
    }
}
