namespace Problems;

public class FindAllAnagrams
{
    // 438. Find All Anagrams in a String
    // Given two strings s and p, return an array of all the start indices of p's
    // in s. You may return the answer in any order.
    
    // Steps:
    // 1. create 2 arrays (for each given string) with the length of the english alphabet & fill them with 0
    // 2. for each letter from the alphabet find its frequency.
    // 3. use sliding window approach to check for anagrams constantly
    
    public IList<int> FindAnagrams(string s, string p)
    {
        List<int> result = new();
        if (s.Length < p.Length)
        {
            return result;
        }

        int[] pFrequencies = new int[26];
        Array.Fill(pFrequencies, 0);
        int[] sFrequencies = new int[26];
        Array.Fill(sFrequencies, 0);

        foreach (var c in p)
        {
            pFrequencies[c - 'a']++;
        }

        for (int i = 0; i < p.Length; i++)
        {
            sFrequencies[s[i] - 'a']++;
        }

        if (IsAnagram(pFrequencies, sFrequencies))
        {
            result.Add(0);
        }

        for (int i = p.Length; i < s.Length; i++)
        {
            sFrequencies[s[i] - 'a']++;
            sFrequencies[s[i - p.Length] - 'a']--;
            if (IsAnagram(pFrequencies, sFrequencies))
            {
                result.Add(i - p.Length + 1);
            }
        }
        
        return result;
    }

    private bool IsAnagram(int[] a, int[] b)
    {
        for (int i = 0; i < 26; i++)
        {
            if (a[i] != b[i])
            {
                return false;
            }
        }

        return true;
    }

    [Fact]
    public void FindAnagrams_pHasMoreElementsThans_ShouldReturnEmptyList()
    {
        Assert.Equal(new List<int>(), FindAnagrams("ab", "abc"));
    }

    [Fact]
    public void FindAnagrams_ThereIsOneAnagramAtStart_ShouldReturnListWithElement0()
    {
        Assert.Equal(new List<int> { 0 }, FindAnagrams("abcdefghijkl", "bca"));
    }

    [Fact]
    public void FindAnagrams_ThereAreSeveralAnagrams_ShouldReturnExpected()
    {
        Assert.Equal(new List<int>{ 1, 5 }, FindAnagrams("sabcibcad", "abc"));
    }
}