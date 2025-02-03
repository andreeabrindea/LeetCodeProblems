namespace Problems;

public class IsomorphicStrings
{
    // 205. Isomorphic Strings
    // Given two strings s and t, determine if they are isomorphic.
    // 
    // Two strings s and t are isomorphic if the characters in s can be replaced to get t.
    // All occurrences of a character must be replaced with another character while preserving the order of characters.
    // No two characters may map to the same character, but a character may map to itself.
    public bool IsIsomorphic(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        Dictionary<char, char> sToT = new Dictionary<char, char>();
        Dictionary<char, char> tToS = new Dictionary<char, char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (!sToT.ContainsKey(s[i]) && !tToS.ContainsKey(t[i]))
            {
                sToT[s[i]] = t[i];
                tToS[t[i]] = s[i];
            }
            else if (!sToT.ContainsKey(s[i]) || !tToS.ContainsKey(t[i]) ||
                     sToT[s[i]] != t[i] || tToS[t[i]] != s[i])
            {
                return false;
            }
        }

        return true;
    }

    [Fact]
    public void IsIsomorphic_HaveDifferentNoOfCharacters_ShouldReturnFalse()
    {
        string s = "abc";
        string t = "efghij";
        Assert.False(IsIsomorphic(s, t));
    }

    [Fact]
    public void IsIsomorphic_HaveSameNoOfCharactersButFirstStringHasDuplicates_ShouldReturnFalse()
    {
        string s = "abb";
        string t = "efg";
        Assert.False(IsIsomorphic(s, t));
    }

    [Fact]
    public void IsIsomorphic_HaveSameNoOfCharactersBothHaveDuplicatesButEqualInFrequency_ShouldReturnTrue()
    {
        string s = "abc";
        string t = "efg";
        Assert.True(IsIsomorphic(s, t));
    }

    [Fact]
    public void
        IsIsomorphic_HaveSameNoOfCharactersBothHaveDuplicatesEqualInFrequencyButHaveDifferentPattern_ShouldReturnFalse()
    {
        string s = "bbbaaaba";
        string t = "aaabbbba";
        Assert.False(IsIsomorphic(s, t));}
    }