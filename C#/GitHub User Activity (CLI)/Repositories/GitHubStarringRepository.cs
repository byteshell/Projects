using GitHubActivityCLI.Interfaces;
using GitHubActivityCLI.Utilities;

namespace GitHubActivityCLI.Repositories
{
    internal class GitHubStarringRepository : IGitHubStarringRepository
    {
        private static readonly HttpClient Client = new();

        public GitHubStarringRepository()
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

        public async Task ListStargazers(string owner, string repository)
        {
            var responseBody = await FetchDataAsync(GitHubStarringApiLinks.ListStargazers(owner, repository), HttpMethod.Get);
            Console.WriteLine(responseBody);
        }

        public async Task ListUserStarredRepositories()
        {
            var responseBody = await FetchDataAsync(GitHubStarringApiLinks.ListRepositoriesStarred(), HttpMethod.Get);
            Console.WriteLine(responseBody);
        }

        public async Task CheckIfRepositoryIsStarredByUser(string owner, string repository)
        {
            try
            {
                await FetchDataAsync(GitHubStarringApiLinks.CheckIfUserStarredRepository(owner, repository), HttpMethod.Get);
                Console.WriteLine($"The repository {owner}/{repository} is starred by the authenticated user.");
            }
            catch (HttpRequestException)
            {
                Console.WriteLine($"The repository {owner}/{repository} is not starred by the authenticated user.");
            }
        }

        public async Task StarRepository(string owner, string repository)
        {
            await FetchDataAsync(GitHubStarringApiLinks.StarARepositoryForAuthenticatedUser(owner, repository), HttpMethod.Put);
            Console.WriteLine($"Repository {owner}/{repository} has been starred.");
        }

        public async Task UnstarRepository(string owner, string repository)
        {
            await FetchDataAsync(GitHubStarringApiLinks.UnstarARepositoryForAuthenticatedUser(owner, repository), HttpMethod.Delete);
            Console.WriteLine($"Repository {owner}/{repository} has been unstarred.");
        }

        public async Task ListRepositoriesStarredByUser(string username)
        {
            var responseBody = await FetchDataAsync(GitHubStarringApiLinks.ListUserStarredRepositories(username), HttpMethod.Get);
            Console.WriteLine(responseBody);
        }
    }
}