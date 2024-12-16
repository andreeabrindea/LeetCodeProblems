using BenchmarkDotNet.Attributes;

namespace Problems;
// 7. Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
//Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

// Steps:
// 1. If the number has only one digit, the problem is done :D
// 2. If it has several digits, convert number to string
// 3. Do not forget about sign

// Conclusion:
// Be careful with the bounds :D
// Use int.TryParse instead of int.Parse
public class ReverseInteger
{
    public int Reverse()
    {
        int x = 9994432;
        bool negative = x < 0;
        string numberAsString = x.ToString();
        string newNumber = "";
        int stopIndex = negative ? 1 : 0;
        for (int i = numberAsString.Length - 1; i >= stopIndex; i--)
        {
            newNumber += numberAsString[i];
        }

        int result;
        int.TryParse(newNumber, out result);
        return negative ? -1 * result : result;
    }

    [Fact]
    public void Test_Reverse_InputHasOneDigit()
    {
        Assert.Equal(4, Reverse());
    }

    [Fact]
    public void Test_Reverse_InputHasFewDigits()
    {
        Assert.Equal(32, Reverse());
    }

    [Fact]
    public void Test_Reverse_InputHasNegativeSign()
    {
        Assert.Equal(-17, Reverse());
    }
}