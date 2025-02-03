namespace Problems.Patterns.Strings;

public class ReverseWordsInAString
{
    // 151. Reverse Words in a String
    // Given an input string s, reverse the order of the words.
    // A word is defined as a sequence of non-space characters.
    // The words in s will be separated by at least one space.
    // Return a string of the words in reverse order concatenated by a single space.
    // Note that s may contain leading or trailing spaces or multiple spaces between two words. The returned string should only have a single space separating the words. Do not include any extra spaces.
    public string ReverseWords(string s)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(s);
        string reversed = "";
        string[] words = s.Split(' ');
        for (int i = words.Length - 1; i >= 0; i--)
        {
            if (words[i] != string.Empty)
            {
                reversed += words[i] + " ";
            }
        }

        return reversed.TrimEnd();
    }

    [Fact]
    public void ReverseWords_OneWord_ShouldRemainUnchanged()
    {
        Assert.Equal("abc", ReverseWords("abc"));
    }

    [Fact]
    public void ReverseWords_SeveralWords_ShouldReturnExpected()
    {
        Assert.Equal("blue is sky the", ReverseWords("the sky is blue"));
    }

    [Fact]
    public void ReverseWords_InputHasSeveralWhiteSpaces_ShouldReturnExpected()
    {
        Assert.Equal("world hello", ReverseWords("  hello world  "));
    }
}