namespace Problems.Patterns.TwoPointers;

public class ContainerWithMostWater
{
    // 42. Trapping Rain Water
    // Given n non-negative integers representing an elevation map where the width of each bar is 1,
    // compute how much water it can trap after raining.

    public int Trap(int[] height)
    {
        int maximumArea = 0;
        int left = 0;
        int right = height.Length - 1;
        while (left < right)
        {
            int area = (right - left) * Math.Min(height[left], height[right]);
            maximumArea = Math.Max(maximumArea, area);
            if (height[left] > height[right])
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        return maximumArea;
    }

    [Fact]
    public void Trap_InputHasOneElement_ShouldReturn0()
    {
        Assert.Equal(0, Trap(new []{ 1 }));
    }

    [Fact]
    public void Trap_InputHasSeveralHeights_ShouldReturnExpected()
    {
        Assert.Equal(49, Trap(new []{ 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
    }
}