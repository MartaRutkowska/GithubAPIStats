using Microsoft.AspNetCore.Mvc;

namespace GithubAPIStats.Controllers
{
    [ApiController]
    [Route("statistics")]
    public class FileStatisticsController(IStatisticsService statisticsService) : ControllerBase
    {
        private readonly IStatisticsService _statisticsService = statisticsService;

        /// <summary>
        /// Returns occurences of letterns in descending order across all file found in a chosen repository.
        /// </summary>
        /// <param owner="owner">Repository owner</param>
        /// <param repository="repository">Repository name</param>
        [HttpGet]
        public async Task<IActionResult> GetAsync(string owner, string repository)
        {
            var statistics = await _statisticsService.GetRepositoryStatistics(owner, repository);
            return Ok(statistics);
        }
    }
}
