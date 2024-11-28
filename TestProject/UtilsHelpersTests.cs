using GithubAPIStats;
using GithubAPIStats.Utils;
using System.Security.Cryptography.X509Certificates;

namespace TestProject
{
    public class UtilsHelpersTests()
    {
        [Theory]
        [InlineData("aaaabbbbcccc")]
        [InlineData("aaAAbbBBccCC")]
        [InlineData("--aaAA&&bb$%+BBcc==CC")]
        public void LettersCountTest(string text)
        {
            var lettersDict = new Dictionary<char, long>();
            CharCountHelper.CountLetters(text, lettersDict);
            Assert.Equal(lettersDict, new Dictionary<char, long> { { 'a', 4 }, { 'b', 4 }, { 'c', 4 } });
        }

        [Fact]
        public void GetFilePathsWithExtenstionsTest()
        {
            List<string> files = [ "aaa.txt", "b.js", "c.js", "sdkjfhsdf.o", "sfuye.ts" ];
            Assert.Equal(FilePathHelper.GetFilePathsWithExtenstions(files), ["b.js", "c.js", "sfuye.ts"]);
        }

    }
}