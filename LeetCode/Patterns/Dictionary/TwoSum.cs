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
        return nums;
    }

    [Fact]
    public void TwoSum_OneElement_ShouldReturnExpected()
    {
        
    }
    // [Fact]
    // public void TwoSum_SeveralElements_ShouldReturnExpected()
    // {
    //     Assert.Equal(new[] {0, 2}, TwoSum(new[] {3, 2, 3}, 6));
    // }
}