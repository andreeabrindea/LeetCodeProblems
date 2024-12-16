using BenchmarkDotNet.Running;
using LeetCodeProblems;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<StringToInteger>();

    }
}