namespace Problems;

public class LongestPalindrome
{
    // 5.Given a string s, return the longest palindromic substring in s.
    
    // Steps:
    // 1.Generate subsequences.
    // 2.Find palindromes.
    // 3.Find the palindrome with the longest length.
    
    // Conclusion:
    // Use string.Concat for IEnumerable<char> to string conversion
    // Ask questions: e.g: how should be the output in case of no palindromes? empty string, null, the actual string?
    // Time Limit Exceeded on Leetcode :(
    public string FindLongestPalindrome(string s)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(s);
        if (s.Length < 2)
        {
            return s;
        }

        var result = Enumerable.Range(0, s.Length)
            .SelectMany(index => Enumerable.Range(1, s.Length - index)
                .Select(length => s.Skip(index).Take(length)))
            .Where(p => p.SequenceEqual(p.Reverse())).MaxBy(l => l.Count());

        return result == null ? s : string.Concat(result);
    }

    [Fact]
    public void Test_GenerateSubsequence_InputIsNull()
    {
        string s = null;
        Assert.Throws<ArgumentNullException>(() => FindLongestPalindrome(s));
    }

    [Fact]
    public void Test_GenerateSubsequence_InputHasOneElem()
    {
        Assert.Equal("a", FindLongestPalindrome("a"));
    }

    [Fact]
    public void Test_GenerateSubsequence_InputHasFewElems()
    {
        Assert.Equal("bb", FindLongestPalindrome("cbbd"));
    }
    
    [Fact]
    public void Test_GenerateSubsequence_InputHasFewElemsButNoPalindromes()
    {
        Assert.Equal("a", FindLongestPalindrome("ac"));
    }
}