using GithubAPIStats.Controllers;
using GithubAPIStats.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestProject
{
    public class FileStatisticsControllerTests
    {
        private readonly FileStatisticsController _controller;

        private readonly Mock<IStatisticsService> _statisticsService;

        private readonly string owner = "owner";
        private readonly string path = "path";

        public FileStatisticsControllerTests()
        {
            _statisticsService = new Mock<IStatisticsService>();
            _controller = new FileStatisticsController(_statisticsService.Object);
        }

        [Fact]
        public async Task Get_FileStatistics_Ok()
        {
            _statisticsService
                .Setup(x => x.GetRepositoryStatistics(owner, path))
                .ReturnsAsync(new Dictionary<char, long> { { 'a', 3 } });

            var result = await _controller.GetAsync(owner, path);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Get_FileStatistics_Throws_InvalidOperationException()
        {
            _statisticsService
                .Setup(x => x.GetRepositoryStatistics(owner, path))
                .ThrowsAsync(new InvalidOperationException());

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await _controller.GetAsync(owner, path));
        }
    }
}
