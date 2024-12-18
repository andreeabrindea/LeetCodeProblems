namespace Problems;

public class MaximumAverageSubarrayI
{
    //643. Maximum Average Subarray I
    // You are given an integer array nums consisting of n elements, and an integer k.
    // Find a contiguous subarray whose length is equal to k that has the maximum average value and return this value. Any answer with a calculation error less than 10-5 will be accepted.
    
    // Steps: 
    // 1. Find the sum from the start to k.
    // 2. Loop through elements, subtract the first element (i) and add the next one, form the next k set of elements, (i + k) <-- Sliding Window
    // 3. Find the maximum between each sum at each iteration.
    
    public double FindMaxAverage(int[] nums, int k)
    {
        if (nums.Length < k)
        {
            return 0;
        }

        double sum = nums[..k].Sum();
        double maxSum = sum;
        for (int i = 0; i < nums.Length - k; i++)
        {
            sum -= nums[i];
            sum += nums[i + k];
            maxSum = Math.Max(maxSum, sum);
        }

        return maxSum / k;
    }

    [Fact]
    public void FindMaxAverage_HasLessThanKElements_ShouldReturn0()
    {
        Assert.Equal(0, FindMaxAverage(new[] { 1, 2, 3}, 4));
    }

    [Fact]
    public void FindMaxAverage_HasMoreThanKElements_ShouldReturnExpected()
    {
        Assert.Equal(3, FindMaxAverage(new[] { 1, 2, 3, 4}, 3));
    }

    [Fact]
    public void FindMaxAverage_HasSeveralElements_ShouldReturnExpected()
    {
        Assert.Equal(12.75000,FindMaxAverage(new[] {1,12,-5,-6,50,3}, 4));
    }
    
}