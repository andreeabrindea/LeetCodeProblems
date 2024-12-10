namespace Problems;

public class LengthOfLongestSubstring
{
    //Given a string s, find the length of the longest substring without repeating characters.
    
    //Steps:
    // 1. Generate sequences
    // 2. Exclude duplicates
    // 3. Take the sequence with maximum length
    
    //Conclusions:
    // Time Limit Exceeded
    public int FindLengthOfLongestSubstring(string s)
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