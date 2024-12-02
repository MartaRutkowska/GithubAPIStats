using GithubAPIStats.Utils;

namespace GithubAPIStats.Services
{
    public class StatisticsService(IExternalService externalService) : IStatisticsService
    {
        private readonly IExternalService _externalService = externalService;

        public async Task<Dictionary<char, long>> GetRepositoryStatistics(string owner, string repo)
        {
            var repoFilePaths = await GetFilePaths(owner, repo);
            var fileContents = await GetFileContents(owner, repo, repoFilePaths);

            if (fileContents == null) return [];

            var lettersDictionary = new Dictionary<char, long>();
            foreach (var text in fileContents)
            {
                CharCountHelper.CountLetters(text, lettersDictionary);
            }

            return lettersDictionary.OrderByDescending(x => x.Value).ToDictionary();
        }

        private async Task<List<string>> GetFilePaths(string owner, string repo)
        {
            var repoTree = await _externalService.GetRepositoryTreeAsync(owner, repo);

            if (repoTree == null || repoTree.Tree == null) return [];
            return FilePathHelper.GetFilePathsWithExtenstions(repoTree.Tree.Select(x => x.Path).ToList());
        }

        private async Task<List<string>?> GetFileContents(string owner, string repo, List<string> paths)
        {
            return await _externalService.GetFilesContentsAsync(owner, repo, paths);
        }
    }
}
