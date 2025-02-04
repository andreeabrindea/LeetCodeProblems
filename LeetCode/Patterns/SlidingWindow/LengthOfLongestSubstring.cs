namespace Problems;

public class LengthOfLongestSubstring
{
    // 3. Given a string s, find the length of the longest substring without repeating characters.
    
    // Steps:
    // 1. create a dictionary to store each character and the last seen position
    // 2. use two pointers (one loop) to create a dynamic window 
    // make sure the second pointer moves forward with Math.Max(currentCharacterIndex + 1, j);
    // keep track of maxim length each time
    
    //Conclusions:
    // Time Limit Exceeded with LINQ method
    // There is a difference between subsequence and substring. E.q s = "pwwkew" , "wke" is a substring, "pwke" is a subsequence and not a substring.
    
    public int FindLengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> lastSeenCharacter = new();
        int j = 0;
        int maximLength = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (lastSeenCharacter.TryGetValue(s[i], out int currentCharacterIndex))
            {
                j = Math.Max(currentCharacterIndex + 1, j);
            }

            maximLength = Math.Max(maximLength, i - j + 1);
            lastSeenCharacter[s[i]] = i;
        }

        return maximLength;
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