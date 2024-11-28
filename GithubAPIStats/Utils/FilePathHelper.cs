using System.Text.RegularExpressions;

namespace GithubAPIStats.Utils
{
    public static class FilePathHelper
    {
        public static List<string> GetFilePathsWithExtenstions(List<string> tree)
        {
            var regex = new Regex("(ts|js)$");

            if (tree == null) return [];
            return tree.Where(x => regex.IsMatch(x)).ToList();
        }
    }
}
