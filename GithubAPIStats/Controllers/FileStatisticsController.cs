using GithubAPIStats.Services;
using Microsoft.AspNetCore.Mvc;

namespace GithubAPIStats.Controllers
{
    [ApiController]
    [Route("statistics")]
    public class FileStatisticsController(IStatisticsService statisticsService) : ControllerBase
    {
        private readonly IStatisticsService _statisticsService = statisticsService;

        /// <summary>
        /// Returns occurences of letterns in descending order across all files found in a chosen repository.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="repository"></param>
        [HttpGet]
        public async Task<IActionResult> GetAsync(string owner, string repository)
        {
            var statistics = await _statisticsService.GetRepositoryStatistics(owner, repository);
            return Ok(statistics);
        }
    }
}
