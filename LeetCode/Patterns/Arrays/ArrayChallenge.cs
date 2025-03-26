namespace Problems.Patterns.Arrays;

public class ArrayChallenge
{ 
    // 2025 Technical Interview Question:
    // Have the function ArrayChallenge (arr) take the array of numbers stored in art and return true
    // If any combination of numbers in the array (excluding the largest number) can be added up to equal the largest number in the array,
    // otherwise return the string false. For example: if arr contains 4, 6, 23, 10, 1, 3 the output should return true because 4 + 6 + 10 + 3 = 23.
    // The array will not be empty, will not contain all the same elements, and may contain negative numbers.
    public bool SolveArrayChallenge(int[] array)
    {
        int max = array.Max();
        return GenerateSum(max, array.Where(n => n != max).ToArray());
    }

    private bool GenerateSum(int n, int[] array)
    {
        bool[] sums = new bool[n + 1];
        sums[0] = true;
        foreach (var num in array)
        {
            for (int i = n; i >= num; i--)
            {
                sums[i] = sums[i] | sums[i - num];
            }
        }

        return sums[n];
    }

    [Fact]
    public void SolveArrayChallenge_CanFormSum_ShouldReturnTrue()
    {
        Assert.True(SolveArrayChallenge(new []{ 1, 2, 3}));
    }
    
    [Fact]
    public void SolveArrayChallenge_CannotFormSum_ShouldReturnTrue()
    {
        Assert.False(SolveArrayChallenge(new []{ 1, 2, 6}));
    }
}