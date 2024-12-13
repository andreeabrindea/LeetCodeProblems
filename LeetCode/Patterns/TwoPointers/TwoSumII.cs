namespace Problems.Patterns.TwoPointers;

public class TwoSumII
{
    // 167. Two Sum II - Input Array Is Sorted
    // Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order,
    // find two numbers such that they add up to a specific target number. Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.
    // Return the indices of the two numbers, index1 and index2, added by one as an integer array [index1, index2] of length 2.

    public int[] TwoSum(int[] numbers, int target)
    {
        if (numbers.Length < 2)
        {
            return new[] { 0, 0 };
        }

        int left = 0;
        int right = numbers.Length - 1;
        while (left < right)
        {
            int sum = numbers[left] + numbers[right];
            if (sum == target)
            {
                return new []{ left + 1, right + 1};
            }
            if (sum > target)
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        return new[] { 0, 0 };
    }
    
    [Fact]
    public void TwoSum_HasOneElement_ShouldReturnExpected()
    {
        Assert.Equal(new int[] {0, 0}, TwoSum(new []{ 1 }, 6));
    }

    [Fact]
    public void TwoSum_Has2ElementsDoesNotAddToTarget_ShouldReturnExpected()
    {
        Assert.Equal(new [] {0, 0}, TwoSum(new []{ 1, 2}, 6));
    }

    [Fact]
    public void TwoSum_HasSeveralElementsAddUpToTarget_ShouldReturnExpected()
    {
        Assert.Equal(new [] { 1, 2}, TwoSum(new []{ 2, 7, 11, 15}, 9));
    }

    [Fact]
    public void TwoSum_HasSeveralElementsThatDoNotAddToTarget_ShouldReturnExpected()
    {
        Assert.Equal(new [] { 0, 0 }, TwoSum(new []{ 1, 2, 3, 4}, 8));
    }
}