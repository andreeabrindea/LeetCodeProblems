namespace Problems;

public class SubarraySum
{
    
    //53.Given an array arr[], the task is to find the subarray that has the maximum sum and return its sum.
    
    //Steps:
    // 1. Generate subsequences
    // 2. Sum elements from each subsequence
    // 3. Take the subsequence with the biggest sum.
    
    //Conclusions:
    //Time Limit Exceeded on LeetCode
    //Use Kadane's Algorithm for efficiency: calculate the maximum sum of subarray ending at current element
    public static int MaximumSubarraySum(int[] arr)
    {
        ArgumentNullException.ThrowIfNull(arr);
        return GenerateSequences(arr).Select(s => s.Sum()).Max();
    }

    public static IEnumerable<IEnumerable<T>> GenerateSequences<T>(T[] arr) where T : struct
    {
        return Enumerable.Range(0, arr.Length)
            .SelectMany(index => Enumerable.Range(1, arr.Length - index)
                .Select(length => arr.Skip(index).Take(length)));
    }
    
    [Fact]
    public void TestGenerateSequences_InputIsNull()
    {
        int[] arr = null;
        Assert.Throws<ArgumentNullException>(() => MaximumSubarraySum(arr));
    }

    [Fact]
    public void TestGenerateSequences_InputHasOneElement()
    {
        int[] arr = new[] { 1 };
        Assert.Equal(new [] { new[]{1} },  GenerateSequences(arr));
    }
    
    [Fact]
    public void TestGenerateSequences_InputHasSeveralElements()
    {
        int[] arr = new[] { 1, 2, 3 };
        Assert.Equal(new [] { new[]{1}, new[]{1, 2}, new[]{1, 2, 3}, new[]{2}, new[]{2, 3}, new[]{3} },  GenerateSequences(arr));
    }

    [Fact]
    public void TestMaximumSubarraySum_InputHasOnlyPositiveNumbers()
    {
        int[] arr = new[] { 1, 2, 3 };
        Assert.Equal(6,  MaximumSubarraySum(arr));
    }

    [Fact]
    public void TestMaximumSubarraySum_InputHasSeveralElements()
    {
        int[] arr = new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        Assert.Equal(7,  MaximumSubarraySum(arr));
    }
    
}