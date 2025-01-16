namespace Problems;

public class LengthOfLongestSubstring
{
    //Given a string s, find the length of the longest substring without repeating characters.
    
    //Steps:
    // 1. Generate sequences
    // 2. Exclude duplicates
    // 3. Take the sequence with maximum length
    
    //Conclusions:
    // Time Limit Exceeded with LINQ method
    // There is a difference between subsequence and substring. E.q s = "pwwkew" , "wke" is a substring, "pwke" is a subsequence and not a substring.
    
    public int FindLengthOfLongestSubstring(string s)
    {
        int max = 0;
        for (int i = 0 ; i < s.Length; i++)
        {
            bool[] visitedElems = new bool[256];
            for (int j = i; j < s.Length; j++)
            {
                if (visitedElems[s[j]])
                {
                    break;
                }
                max = Math.Max(max, j - i + 1);
                visitedElems[s[j]] = true;
            }

        }

        return max;
    }
    
    //LINQ Method
    public int FindLengthOfLongestSubstringLINQ(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }
        return GenerateSequences(s).Where(p => p.Count() == p.Distinct().Count()).MaxBy(s => s.Count()).Count();
    }

    public IEnumerable<IEnumerable<char>> GenerateSequences(string s)
    {
        return Enumerable.Range(0, s.Length)
            .SelectMany(index => Enumerable.Range(1, s.Length - index).Select(length => s.Skip(index).Take(length)));
    }

    [Fact]
    public void LengthOfLongestSubstring_InputIsEmpty()
    {
        string s = string.Empty;
        Assert.Equal(0, FindLengthOfLongestSubstring(s));
    }
    
    [Fact]
    public void LengthOfLongestSubstring_InputHasOneElement()
    {
        string s = "a";
        Assert.Equal(1, FindLengthOfLongestSubstring(s));
    }

    [Fact]
    public void LengthOfLongestSubstring_InputHasOneDuplicate()
    {
        string s = "abb";
        Assert.Equal(2, FindLengthOfLongestSubstring(s));
    }
    
    [Fact]
    public void LengthOfLongestSubstring_InputHasSeveralDuplicates()
    {
        string s = "abcabcbb";
        Assert.Equal(3, FindLengthOfLongestSubstring(s));
    }

}