namespace Problems.Patterns.Strings;

public class IsSubsequence
{
    // 392. Is Subsequence
    // Given two strings s and t, return true if s is a subsequence of t, or false otherwise.
    // A subsequence of a string is a new string that is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters.
    // (i.e., "ace" is a subsequence of "abcde" while "aec" is not).
    public bool IsSubsequenceProblem(string s, string t)
    {
        if (t.Length < s.Length)
        {
            return false;
        }

        int indexT = 0;
        int indexS = 0;
        while (indexT < t.Length)
        {
            if (s[indexS] == t[indexT])
            {
                indexS++;
            }

            indexT++;
        }
        return indexS == s.Length;
    }

    [Fact]
    public void IsSubsequenceProblem_InputIsEmpty_ShouldReturnTrue()
    {
        Assert.True(IsSubsequenceProblem(string.Empty, string.Empty));
    }
    
    [Fact]
    public void IsSubsequenceProblem_SisNotIncludedInT_ShouldReturnFalse()
    {
        Assert.False(IsSubsequenceProblem("axyz", "adecb"));
    }

    [Fact]
    public void IsSubsequenceProblem_SisIncludedInT_ShouldReturnTrue()
    {
        Assert.True(IsSubsequenceProblem("abc", "adbec"));
    }

    [Fact]
    public void IsSubsequenceProblem_SisIncludedInTButTheOrderIsWrong_ShouldReturnFalse()
    {
        Assert.False(IsSubsequenceProblem("abc", "adecb"));
    }
}