namespace Problems;

public class GroupAnagrams
{
    // 49. Group Anagrams
    // Given an array of strings strs, group the anagrams together. You can return the answer in any order.
    public IList<IList<string>> GroupTheAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> groups = new();
        foreach (var word in strs)
        {
            string key = new string(word.OrderBy(c => c).ToArray());
            if (!groups.ContainsKey(key))
            {
                groups[key] = new List<string>();
            }
            
            groups[key].Add(word);
        }
        return groups.Values.ToList<IList<string>>();
    }


    [Fact]
    public void GroupTheAnagrams_IsEmpty_ShouldReturnEmpty()
    {
        Assert.Equal(new List<List<string>>(), GroupTheAnagrams(new string[]{}));
    }

    [Fact]
    public void GroupTheAnagrams_HasOneString_ShouldReturnListOfListOfElement()
    {
        Assert.Equal(new List<List<string>>() { new() { "a" } }, GroupTheAnagrams(new[]{"a"}));
    }

    [Fact]
    public void GroupTheAnagrams_HasSeveralStrings_ShouldReturnExpected()
    {
        string[] strs = { "eat", "tea", "tan", "ate", "nat", "bat" };
        Assert.Equal(new List<List<string>>() { new() {"eat", "tea", "ate"}, new() { "tan", "nat"}, new() { "bat" }}, GroupTheAnagrams(strs));
    }
}