namespace GithubAPIStats.Services
{
    public interface IStatisticsService
    {
        public Task<Dictionary<char, long>> GetRepositoryStatistics(string owner, string repo);
    }
}
