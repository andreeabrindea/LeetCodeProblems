namespace HackerRank.Patterns.Dictionary;

public class LongestConsecutiveSequence
{
    // 128. Longest Consecutive Sequence
    // Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
    // You must write an algorithm that runs in O(n) time.
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> numsSet = new(nums);
        int currentStreak = 0;
        int longestStreak = 0;
        foreach (int num in numsSet)
        {
            if (!numsSet.Contains(num - 1))
            {
                int currentNum = num;
                currentStreak = 1;
                while (numsSet.Contains(currentNum + 1))
                {
                    currentStreak++;
                    currentNum++;
                }
            }

            longestStreak = Math.Max(longestStreak, currentStreak);
        }

        return longestStreak;
    }

    [Fact]
    public void LongestConsecutive_ThereIsNoConsecutiveSequence_ShouldReturn1()
    {
        Assert.Equal(1, LongestConsecutive(new []{ 1, 3, 6, 9}));
    }

    [Fact]
    public void LongestConsecutive_ThereIsAConsecutiveSequence_ShouldReturnExpected()
    {
        Assert.Equal(2, LongestConsecutive(new []{1, 2, 6, 9}));
    }

    [Fact]
    public void LongestConsecutive_ThereAreSeveralConsecutiveSequences_ShouldReturnExpected()
    {
        Assert.Equal(6, LongestConsecutive(new []{3, 5, 6, 12, 2, 1, 4, 13, 11}));
    }
}