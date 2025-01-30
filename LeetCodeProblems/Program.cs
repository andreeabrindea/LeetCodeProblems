using BenchmarkDotNet.Running;
using LeetCodeProblems;

public class Program
{
    public static void Main(string[] args)
    {
        //var summary = BenchmarkRunner.Run<LengthOfLongestSubstring>();
        int[] nums = { 1, 2, 3, 4 };
        var result =  Enumerable.Range(0, nums.Length)
            .SelectMany(index => Enumerable.Range(0, nums.Length - index + 1)
                .Select(length => nums.Skip(index).Take(length).ToList() as IList<int>).Distinct()).ToList();
        foreach (var r in result)
        {
            foreach (var a in r)
            {
                Console.WriteLine(a);
            }
        }
    }
    
}