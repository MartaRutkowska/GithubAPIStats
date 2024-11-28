using Microsoft.AspNetCore.Mvc;

namespace GithubAPIStats.Controllers
{
    [ApiController]
    [Route("statistics")]
    public class FileStatisticsController(IStatisticsService statisticsService) : ControllerBase
    {       
        private readonly IStatisticsService _statisticsService = statisticsService;

        [HttpGet]
        public async Task<Dictionary<char, long>> GetAsync(string owner, string repo)
        {
            return await _statisticsService.GetRepositoryStatistics(owner, repo);
        }
    }
}
