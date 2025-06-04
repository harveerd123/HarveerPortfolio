using HarveerPortfolio.Models;
using System.Net.Http.Json;

namespace HarveerPortfolio.Services
{
    public class GitHubService
    {
        private readonly HttpClient _httpClient;

        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //_httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("request");
        }

        public async Task<List<GitHubRepo>> GetRepositoriesAsync(string username)
        {
            return await _httpClient.GetFromJsonAsync<List<GitHubRepo>>($"https://api.github.com/users/{username}/repos");
        }
    }
}
