using GithubAPIStats;
using GithubAPIStats.Services;
using GithubAPIStats.Services.Models;
using Moq;

namespace TestProject
{
    public class StatisticsServiceTests
    {
        private readonly IStatisticsService _statisticsService;

        private readonly Mock<IExternalService> _externalService;

        private readonly string owner = "owner";
        private readonly string path = "path";
        private readonly RepositoryTree tree = new([new("aaaa.js"), new("sdfsdfsdf.ps"), new("aaaa.sdf"), new("aaaa.txt")]);
        public StatisticsServiceTests()
        {
            _externalService = new Mock<IExternalService>();
            _statisticsService = new StatisticsService(_externalService.Object);
        }

        [Fact]
        public async Task GetRepositoryStatisticsTest()
        {
            _externalService.Setup(x => x.GetRepositoryTreeAsync(owner, path)).ReturnsAsync(tree);
            _externalService.Setup(x => x.GetFilesContentsAsync(owner, path, new List<string> { "aaaa.js" })).ReturnsAsync(["aaaabbbbcccc"]);

            var result = await _statisticsService.GetRepositoryStatistics(owner, path);
            Assert.Equal(result, new Dictionary<char, long> { { 'a', 4 }, { 'b', 4 }, { 'c', 4 } });
        }

    }
}
