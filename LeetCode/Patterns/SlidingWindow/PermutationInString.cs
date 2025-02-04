namespace Problems;

public class PermutationInString
{
    // 567. Permutation in String
    // Given two strings s1 and s2, return true if s2 contains a
    // permutation
    // of s1, or false otherwise.
    // In other words, return true if one of s1's permutations is the substring of s2.

    
    // Steps:
    // similar to 438. Find All Anagrams in a String
    public bool CheckInclusion(string s1, string s2)
    {
        if (s2.Length < s1.Length)
        {
            return false;
        }
        
        int[] s1Frequencies = new int[26];
        Array.Fill(s1Frequencies, 0);
        int[] s2Frequencies = new int[26];
        Array.Fill(s2Frequencies, 0);

        foreach (var c in s1)
        {
            s1Frequencies[c - 'a']++;
        }

        for (int i = 0; i < s1.Length; i++)
        {
            s2Frequencies[s2[i] - 'a']++;
        }

        if (IsAnagram(s1Frequencies, s2Frequencies))
        {
            return true;
        }

        for (int i = s1.Length; i < s2.Length; i++)
        {
            s2Frequencies[s2[i] - 'a']++;
            s2Frequencies[s2[i - s1.Length] - 'a']--;
            if (IsAnagram(s1Frequencies, s2Frequencies))
            {
                return true;
            }
        }

        return false;
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
    public void CheckInclusion_ThereIsOnePermutation_ShouldReturnTrue()
    {
        Assert.True(CheckInclusion("ab", "eidbaooo"));
    }

    [Fact]
    public void CheckInclusion_ThereIsNoPermutation_ShouldReturnFalse()
    {
        Assert.False(CheckInclusion("ab", "cdefghijklmno"));
    }
}