using GithubAPIStats.Config;
using GithubAPIStats.Services.Models;
using Microsoft.Extensions.Options;

namespace GithubAPIStats.Services
{
    public class ExternalService(
        IOptions<ExternalServiceSettings> externalServiceSettings,
        IHttpClientFactory httpClientFactory,
        ILogger<ExternalService> logger)
        : IExternalService
    {

        private readonly ExternalServiceSettings _externalServiceSettings = externalServiceSettings.Value;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly ILogger<ExternalService> _logger = logger;

        public async Task<RepositoryTree?> GetRepositoryTreeAsync(string owner, string repo)
        {
            using HttpClient client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_externalServiceSettings.BaseUrl);
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");


            var response = await client.GetAsync
                ($"{owner}/{repo}/git/trees/main?recursive=true");

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException();

            return await response.Content.ReadFromJsonAsync<RepositoryTree>();
        }

        public async Task<List<string>?> GetFilesContentsAsync(string owner, string repo, List<string> paths)
        {
            using HttpClient client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_externalServiceSettings.BaseUrl);
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            client.DefaultRequestHeaders.Accept.TryParseAdd("application/vnd.github.raw+json");

            var tasks = paths.Select(p => client.GetStringAsync($"{owner}/{repo}/contents/{p}"));
            var fileContents = await Task.WhenAll(tasks);

            return [.. fileContents];
        }
    }
}
