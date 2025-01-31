namespace Problems.Patterns.Arrays;

public class FirstMissingPositive
{
    // 41. First Missing Positive
    // Given an unsorted integer array nums. Return the smallest positive integer that is not present in nums.
    public int GetFirstMissingPositive(int[] nums)
    {
        nums = nums.Where(e => e > 0).ToArray();
        Array.Sort(nums);
        int target = 1;
        foreach (var n in nums)
        {
            if (n == target)
            {
                target++;
            }
        }

        return target;
    }
    // Time Complexity: O(n*log n)

    [Fact]
    public void GetFirstMissingPositive_InputHasOneElementGreaterThan1_ShouldReturn1()
    {
        Assert.Equal(1, GetFirstMissingPositive(new []{ 2 }));
    }

    [Fact]
    public void GetFirstMissingPositive_InputHasSeveralElements_ShouldReturnExpected()
    {
        Assert.Equal(7, GetFirstMissingPositive(new []{ 5, 1, 4, 3, 2, 6, 0}));
    }
}
