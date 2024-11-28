using GithubAPIStats.Services.Models;

namespace GithubAPIStats.Services
{
    public interface IExternalService
    {
        public Task<RepositoryTree?> GetRepositoryTreeAsync(string owner, string repo);

        public Task<List<string>?> GetFilesContentsAsync(string owner, string repo, List<string> paths);
    }
}
