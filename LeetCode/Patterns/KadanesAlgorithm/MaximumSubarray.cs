namespace Problems.Patterns.KadanesAlgorithm;

public class MaximumSubarray
{
    // 53. Maximum Subarray
    // Given an integer array nums, find the subarray with the largest sum, and return its sum.
    public int MaxSubArray(int[] nums)
    {
        ArgumentNullException.ThrowIfNull(nums);
        int maxSum = nums[0];
        int currentMax = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            currentMax = Math.Max(nums[i], currentMax + nums[i]);
            maxSum = Math.Max(maxSum, currentMax);
        }
        return maxSum;
    }

    [Fact]
    public void MaxSubArray_HasSeveralNumbers_ShouldReturnExpected()
    {
        Assert.Equal(6, MaxSubArray(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
    }
}