namespace Problems.Patterns.Dictionary;

public class ContainsDuplicateII
{
    //219. Contains Duplicate II
    // Given an integer array nums and an integer k,
    // return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.

    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        Dictionary<int, int> elementsIndices = new();
        for (int i = 0; i < nums.Length; i++)
        {
            if (elementsIndices.ContainsKey(nums[i]))
            {
                if (Math.Abs(elementsIndices[nums[i]] - i) <= k)
                {
                    return true;
                }
            }

            elementsIndices[nums[i]] = i;
        }

        return false;
    }

    [Fact]
    public void ContainsNearbyDuplicate_HasNoDuplicate_ShouldReturnFalse()
    {
        Assert.False(ContainsNearbyDuplicate(new[] {1, 2, 3}, 3));
    }

    [Fact]
    public void ContainsNearbyDuplicate_HasDuplicatesButDoesNotRespectKCondition_ShouldReturnFalse()
    {
        Assert.False(ContainsNearbyDuplicate(new[] {1, 2, 3, 1}, 1));
    }
}