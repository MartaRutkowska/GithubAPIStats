namespace GithubAPIStats.Utils
{
    public static class CharCountHelper
    {
        public static void CountLetters(string text, Dictionary<char, long> lettersDict)
        {
            foreach (char c in text)
            {
                var letter = char.ToLowerInvariant(c);
                if (char.IsLetter(letter) && !lettersDict.TryAdd(letter, 1))
                {
                    lettersDict[letter] += 1;
                }
            }
        }
    }
}
