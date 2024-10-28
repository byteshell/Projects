using GitHubActivityCLI.Interfaces;
using GitHubActivityCLI.Utilities;

namespace GitHubActivityCLI.Repositories
{
    internal class GitHubFeedsRepository : IGitHubFeedsRepository
    {
        private static readonly HttpClient Client = new();

        public GitHubFeedsRepository()
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

        public async Task GetFeeds()
        {
            var responseBody = await FetchDataAsync(GitHubFeedsApiLinks.GetFeeds);
            Console.WriteLine(responseBody);
        }
    }
}