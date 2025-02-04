namespace Problems.Patterns.QuickSort;

public class SortColors
{
    // 75. Sort Colors
    // Given an array nums with n objects colored red, white, or blue,
    // sort them in-place so that objects of the same color are adjacent,
    // with the colors in the order red, white, and blue.
    // We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.
    public void SortColorsProblem(int[] nums)
    {
        ArgumentNullException.ThrowIfNull(nums);
        if (nums.Length == 0)
        {
            return;
        }
        QuickSort(nums, 0, nums.Length - 1);
    }

    private void QuickSort(int[] nums, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(nums, left, right);
            QuickSort(nums, left, pivotIndex - 1);
            QuickSort(nums, pivotIndex + 1, right);
        }
    }

    private int Partition(int[] nums, int left, int right)
    {
        int pivot = nums[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (nums[j] <= pivot)
            {
                i++;
                (nums[i], nums[j]) = (nums[j], nums[i]);
            }
        }

        (nums[i + 1], nums[right]) = (nums[right], nums[i + 1]);
        return i + 1;
    }


    [Fact]
    public void SortColors_SeveralElementsUnsorted_ShouldReturnExpected()
    {
        int[] nums = { 2, 1, 0, 1, 2, 0, 0, 2, 1 };
        SortColorsProblem(nums);
        Assert.Equal(new[] { 0, 0, 0, 1, 1, 1, 2, 2, 2}, nums);
    }
}