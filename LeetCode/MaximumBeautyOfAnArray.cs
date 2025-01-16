namespace Problems;

public class MaximumBeautyOfAnArray
{
    
    // 2779. Maximum Beauty of an Array After Applying Operation.
    
    // Steps:
    // 1. Find the maximum number of equal elements.
    // 2. Add k to each element?
    // 3. Verify maximum no of equal elements
    public int MaximumBeauty(int[] nums, int k)
    {
        return k;
    }

    private int GetNumberOfEqualElements(int[] nums) => nums.Length - nums.Distinct().Count() + 1;

    [Fact]
    public void MaximumBeauty_InputIsNull()
    {
        int[] nums = null;
        Assert.Throws<ArgumentNullException>(() => MaximumBeauty(nums, 0));
    }

    [Fact]
    public void GetNumberOfEqualElements_InputHasSeveralEqualNumbers()
    {
        Assert.Equal(4, GetNumberOfEqualElements(new []{3, 3, 1, 2, 3, 3}));
    }

    [Fact]
    public void MaximumBeauty_InputHasOneElement()
    {
        Assert.Equal(1, MaximumBeauty(new [] { 1 }, 2));
    }

    [Fact]
    public void MaximumBeauty_InputHasSeveralEqualElements()
    {
        Assert.Equal(3, MaximumBeauty(new [] { 2, 3, 2, 2}, 5));
    }

    [Fact]
    public void MaximumBeauty_InputHasNoEqualElements()
    {
        Assert.Equal(3, MaximumBeauty(new []{4,6,1,2}, 2));
    }
}