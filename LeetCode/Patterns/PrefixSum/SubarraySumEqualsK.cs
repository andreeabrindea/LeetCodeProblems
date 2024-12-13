namespace Problems.Patterns.PrefixSum;

public class SubarraySumEqualsK
{
    // 560. Given an array of integers nums and an integer k, return the total number of subarrays whose sum equals to k.
    
    public int SubarraySum(int[] nums, int k)
    {
        if (nums.Length == 1)
        {
            return nums[0] == k ? 1 : 0;
        }

        Dictionary<int, int> prefixSum = new Dictionary<int, int>();
        prefixSum[0] = 1;
        int currentSum = 0;
        int count = 0;
        foreach (var number in nums)
        {
            currentSum += number;
            if (prefixSum.ContainsKey(currentSum - k))
            {
                count += prefixSum[currentSum - k];
            }

            if (prefixSum.ContainsKey(currentSum))
            {
                prefixSum[currentSum]++;
            }
            else
            {
                prefixSum[currentSum] = 1;
            }
        }
        return count;
    }

    [Fact]
    public void SubarraySum_HasOneElement_ShouldReturnExpected()
    {
        Assert.Equal(0, SubarraySum(new []{ 4 }, 7));
    }

    [Fact]
    public void SubarraySum_HasOneElementEqualToK()
    {
        Assert.Equal(1, SubarraySum(new []{ 2 }, 2));
    }

    [Fact]
    public void SubarraySum_HasSeveralElementsAddsUpToK()
    {
        Assert.Equal(2, SubarraySum(new []{1, 1, 3, 1, 2}, 4));
    }

    [Fact]
    public void SubarraySum_HasSeveralElementsDoNotAddUpToK()
    {
        Assert.Equal(0, SubarraySum(new []{1, 1, 3, 1, 2}, 9));
    }
}