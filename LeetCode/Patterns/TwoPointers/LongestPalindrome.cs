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
    // LINQ is not designed for tasks that involve updating variables
    
    
    public string FindLongestPalindrome(string s)
    {
        ArgumentException.ThrowIfNullOrEmpty(s);
        if (s.Length < 2)
        {
            return s;
        }

        int maximumLength = 1;
        int start = 0;
        
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j < s.Length; j++)
            {
                if (IsPalindrome(s, i, j) && (j - i + 1 > maximumLength))
                {
                    maximumLength = j - i + 1;
                    start = i;
                }
            }
        }

        return s.Substring(start, maximumLength);
    }

    private bool IsPalindrome(string s, int start, int end)
    {
        int left = start;
        int right = end;
        while (left < right)
        {
            if (s[left] != s[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }
    public string FindLongestPalindromePoorPerformance(string s)
    {
        ArgumentException.ThrowIfNullOrEmpty(s);
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