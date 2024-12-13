namespace Problems.Patterns.PrefixSum;

public class ContinuousSubarraySum
{
    // // 523. Continuous Subarray Sum
    // Given an integer array nums and an integer k, return true if nums has a good subarray or false otherwise. A good subarray is a subarray where:
    // - its length is at least two, and
    // - the sum of the elements of the subarray is a multiple of k.

    
    // Conclusion:
    // Use partial sum % k
    // instead of counting, store the position in dictionary
    // put the "result" 0 at index -1, so you do not mess up the indexes.
    public bool CheckSubarraySum(int[] nums, int k)
    {
        if (nums.Length < 2)
        {
            return false;
        }

        if (nums.Length == 2)
        {
            return nums.Sum() % k == 0;
        }

        int currentSum = 0;
        Dictionary<int, int> partialSumRemainder = new Dictionary<int, int>();
        partialSumRemainder[0] = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            currentSum += nums[i];
            int remainder = currentSum % k;
            if (partialSumRemainder.ContainsKey(remainder))
            {
                if (i - partialSumRemainder[remainder] > 1)
                {
                    return true;
                }
            }
            else
            {
                partialSumRemainder[remainder] = i;
            }

        }
        return false;
    }

    [Fact]
    public void CheckSubarraySum_OneElement_ReturnFalse()
    {
        Assert.False(CheckSubarraySum(new []{ 1 }, 5));
    }

    [Fact]
    public void CheckSubarraySum_FewElementsDoesNotSumUpK_ReturnFalse()
    {
        Assert.False(CheckSubarraySum(new []{ 2, 3}, 9));
    }

    [Fact]
    public void CheckSubarraySum_SeveralElementsDoesSumUpK_ReturnTrue()
    {
        Assert.True(CheckSubarraySum(new []{ 1, 4, 2, 3}, 5));
    }

    [Fact]
    public void CheckSubarraySum_SeveralZeros_ShouldReturnTrue()
    {
        Assert.True(CheckSubarraySum(new []{ 5, 0, 0, 0}, 3));

    }

    [Fact]
    public void CheckSubarraySum_2Elements1Zero_ShouldReturnFalse()
    {
        Assert.False(CheckSubarraySum(new[] {2, 0}, 3));
    }
    
    [Fact]
    public void CheckSubarraySum_3Elements1Zero_ShouldReturnFalse()
    {
        Assert.False(CheckSubarraySum(new[] {2, 0, 5}, 3));
    }
}