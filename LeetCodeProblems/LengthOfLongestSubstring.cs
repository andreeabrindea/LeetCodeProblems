using BenchmarkDotNet.Attributes;

namespace LeetCodeProblems;

public class LengthOfLongestSubstring
{
    //Given a string s, find the length of the longest substring without repeating characters.
    [Benchmark]
    public int FindLengthOfLongestSubstring()
    {
        string s = "abcabcbb";
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
    
    [Benchmark]
    public int FindLengthOfLongestSubstringLINQ()
    {
        string s = "abcabcbb";

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
}