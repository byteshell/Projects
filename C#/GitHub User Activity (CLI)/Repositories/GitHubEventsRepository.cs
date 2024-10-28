using GitHubActivityCLI.Interfaces;
using GitHubActivityCLI.Utilities;

namespace GitHubActivityCLI.Repositories
{
    internal class GitHubEventsRepository : IGitHubEventsRepository
    {
        private static readonly HttpClient Client = new();

        public GitHubEventsRepository()
        {
            Client.DefaultRequestHeaders.Add("User-Agent", "CSharp-HttpClient");
        }

        private static async Task<string> FetchDataAsync(string url)
        {
            try
            {
                var response = await Client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine("Request error: " + exception.Message);
                throw;
            }
        }

        public async Task ListPublicEvents()
        {
            var responseBody = await FetchDataAsync(GitHubEventsApiLinks.PublicEvents);
            Console.WriteLine(responseBody);
        }

        public async Task ListPublicEventsRepositoriesNetwork(string owner, string repository)
        {
            var responseBody = await FetchDataAsync(GitHubEventsApiLinks.ListPublicEventsRepositoriesNetwork(owner, repository));
            Console.WriteLine(responseBody);
        }

        public async Task ListOrganizationEvents(string organization)
        {
            var responseBody = await FetchDataAsync(GitHubEventsApiLinks.ListOrganizationEvents(organization));
            Console.WriteLine(responseBody);
        }

        public async Task ListRepositoryEvents(string owner, string repository)
        {
            var responseBody = await FetchDataAsync(GitHubEventsApiLinks.ListRepositoryEvents(owner, repository));
            Console.WriteLine(responseBody);
        }

        public async Task ListUserEvents(string username)
        {
            var responseBody = await FetchDataAsync(GitHubEventsApiLinks.ListUserEvents(username));
            Console.WriteLine(responseBody);
        }

        public async Task ListUserOrganizationEvents(string username, string organization)
        {
            var responseBody = await FetchDataAsync(GitHubEventsApiLinks.ListUserOrganizationEvents(username, organization));
            Console.WriteLine(responseBody);
        }

        public async Task ListUserPublicEvents(string username)
        {
            var responseBody = await FetchDataAsync(GitHubEventsApiLinks.ListUserPublicEvents(username));
            Console.WriteLine(responseBody);
        }

        public async Task ListUserReceivedEvents(string username)
        {
            var responseBody = await FetchDataAsync(GitHubEventsApiLinks.ListUserReceivedEvents(username));
            Console.WriteLine(responseBody);
        }

        public async Task ListUserReceivedPublicEvents(string username)
        {
            var responseBody = await FetchDataAsync(GitHubEventsApiLinks.ListUserReceivedPublicEvents(username));
            Console.WriteLine(responseBody);
        }
    }
}
