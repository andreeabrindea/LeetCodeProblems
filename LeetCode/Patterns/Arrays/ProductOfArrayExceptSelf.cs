namespace Problems.Patterns.Arrays;

public class ProductOfArrayExceptSelf
{
    // 238. Product of Array Except Self
    // Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
    // The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
    // You must write an algorithm that runs in O(n) time and without using the division operation.
    public int[] ProductExceptSelf(int[] nums)
    {
        ArgumentNullException.ThrowIfNull(nums);
        int[] result = new int[nums.Length];
        int prefix = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = prefix;
            prefix *= nums[i];
        }

        int suffix = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            result[i] *= suffix;
            suffix *= nums[i];
        }

        return result;
    }

    [Fact]
    public void ProductExceptSelf_HasOneElement_ShouldReturnAnArrayWithOneElementEqualTo1()
    {
        Assert.Equal(new[] { 1 }, ProductExceptSelf(new[] { 2 }));
    }

    [Fact]
    public void ProductExceptSelf_HasSeveralElements_ShouldReturnExpected()
    { 
        Assert.Equal(new[] { 24,12,8,6 }, ProductExceptSelf(new[] { 1, 2, 3, 4 }));
    }

    [Fact]
    public void ProductExceptSelf_HasZeros_ShouldReturnExpected()
    {
        Assert.Equal(new[] { 0, 2, 0}, ProductExceptSelf(new[] {1, 0, 2}));
    }
}