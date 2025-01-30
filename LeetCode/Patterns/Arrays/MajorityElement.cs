namespace Problems.Patterns.Arrays;

public class MajorityElement
{
    // 169. Given an array nums of size n, return the majority element.
    // The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.

    // Approaches:
    // Dictionary: use a dictionary to store each element and its number of appearances.
    // Time Complexity: O(n)
    // Space Complexity: O(n)
    
    // Bayern - Moore Voting Algorithm
    // Time Complexity: O(n)
    // Space Complexity: O(1)
    public int GetMajorityElement(int[] nums)
    {
        ArgumentNullException.ThrowIfNull(nums);
        int count = 0;
        int candidate = 0;
        foreach (int n in nums)
        {
            if (count == 0)
            {
                candidate = n;
            }

            count += (n == candidate) ? 1 : -1;
        }
        return candidate;
    }


    [Fact]
    public void MajorityElement_InputIsNull_ShouldThrowException()
    {
        int[] nums = null;
        Assert.Throws<ArgumentNullException>(() => GetMajorityElement(nums));
    }

    [Fact]
    public void MajorityElement_HasOneElement_ShouldReturnExpected()
    {
        Assert.Equal(1, GetMajorityElement(new[] { 1 }));
    }
    
    [Fact]
    public void MajorityElement_HasSeveralElements_ShouldReturnExpected()
    {
        Assert.Equal(2, GetMajorityElement(new[] { 2,2,1,1,1,2,2 }));
    }
}