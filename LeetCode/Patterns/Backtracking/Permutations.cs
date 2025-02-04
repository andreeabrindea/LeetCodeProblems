namespace Problems.Patterns.Backtracking;

public class Permutations
{
    // 46. Permutations
    // Given an array nums of distinct integers, return all the possible permutations
    public IList<IList<int>> Permute(int[] nums) {
        List<IList<int>> result = new();
        GeneratePermutations(nums, 0, result);
        return result;
    }

    private void GeneratePermutations(int[] nums, int startIndex, List<IList<int>> result)
    {
        if (startIndex == nums.Length)
        {
            result.Add(new List<int>(nums));
        }

        for (int i = startIndex; i < nums.Length; i++)
        {
            (nums[i], nums[startIndex]) = (nums[startIndex], nums[i]);
            GeneratePermutations(nums, startIndex + 1, result);
            (nums[i], nums[startIndex]) = (nums[startIndex], nums[i]);
        }
    }

    [Fact]
    public void Permute_SeveralElements_ShouldReturnExpected()
    {
        Assert.Equal(new List<IList<int>>() 
        { new List<int>{ 1, 2, 3}, new List<int>{ 1, 3, 2 }, new List<int> { 2, 1, 3}, new  List<int>{ 2, 3, 1},
            new List<int>{ 3, 2, 1}, new  List<int>{ 3, 1, 2}}, Permute(new []{ 1, 2, 3 }));
    }
}