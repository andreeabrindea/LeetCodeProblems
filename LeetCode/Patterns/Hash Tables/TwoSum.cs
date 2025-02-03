namespace Problems.Patterns.TwoPointers;
//  1. Two Sum
// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

// Conclusion:
// - It cannot be sorted using TWO POINTERS pattern. Use Dictionary for O(n) complexity instead of nested loops.
// - TryGetValue is more efficient than ContainsKey and seenNumbers[complement]
public class TwoSumProblem
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> seenNumbers = new();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (seenNumbers.TryGetValue(complement, out var indexOfComplement))
            {
                return new[] { indexOfComplement, i };
            }

            seenNumbers.TryAdd(nums[i], i);
        }
        
        return new []{ -1, -1 };
    }

    [Fact]
    public void TwoSum_OneElement_ShouldReturnExpected()
    {
        Assert.Equal(new[] {-1, -1}, TwoSum(new []{ 1, 3 }, 2));
    }
    
    [Fact]
    public void TwoSum_SeveralElements_ShouldReturnExpected()
    {
        Assert.Equal(new[] {0, 2}, TwoSum(new[] {3, 2, 3}, 6));
    }
}