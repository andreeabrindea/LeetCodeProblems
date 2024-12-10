namespace Problems;

public class LongestCommonPrefix
{
    // 14. Write a function to find the longest common prefix string amongst an array of strings.
    
    // Steps:
    // 1. If there is just one element, return it.
    // 2. Order the strings in whatever order.
    // 3. Find the common prefix between the first & last element.
    
    
    //Conclusion:
    // while loop can be replaced with: Enumerable.Range(0, length).TakeWhile(i => condition)
    // count the iterations :Enumerable.Range(0, length).TakeWhile(i => condition).Count()
    
    public string FindLongestCommonPrefix(string[] s)
    {
        ArgumentNullException.ThrowIfNull(s);
        if (s.Length == 1)
        {
            return s[0];
        }
        s.Order();
        int length = Math.Min(s[0].Length, s[^1].Length);
        int maximum = Enumerable.Range(0, length).TakeWhile(i => s[0][i] == s[^1][i]).Count();
        return maximum > 0 ? s[0][..maximum] : "";
    }
    

    [Fact]
    public void TestFindLongestCommonPrefix_InputIsNull()
    {
        string[] s = null;
        Assert.Throws<ArgumentNullException>(() => FindLongestCommonPrefix(s));
    }

    [Fact]
    public void TestFindLongestCommonPrefix_InputIsHasOneItem()
    {
        string[] s = { "hello" };
        Assert.Equal("hello", FindLongestCommonPrefix(s));
    }

    [Fact]
    public void TestFindLongestCommonPrefix_InputHasNoCommonPrefix()
    {
        string[] s = { "hello", "there" };
        Assert.Equal("", FindLongestCommonPrefix(s));
    }

    [Fact]
    public void TestFindLongestCommonPrefix_InputHasSeveralItemsWithSamePrefix()
    {
        string[] s = { "flower","flow","flight"};
        Assert.Equal("fl", FindLongestCommonPrefix(s));

    }
}