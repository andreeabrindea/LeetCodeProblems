using BenchmarkDotNet.Attributes;

namespace LeetCodeProblems;

public class StringToInteger
{
    //8. String to Integer (atoi)
    // Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer.
    // The algorithm for myAtoi(string s) is as follows:
    
    // Whitespace: Ignore any leading whitespace (" ").
    // Signedness: Determine the sign by checking if the next character is '-' or '+', assuming positivity if neither present.
    // Conversion: Read the integer by skipping leading zeros until a non-digit character is encountered or the end of the string is reached. If no digits were read, then the result is 0.
    // Rounding: If the integer is out of the 32-bit signed integer range [-231, 231 - 1], then round the integer to remain in the range. Specifically, integers less than -231 should be rounded to -231, and integers greater than 231 - 1 should be rounded to 231 - 1.
    // 
    // Return the integer as the final result.
    
    //Steps:
    //1. make it work for a single digit.
    //2. make it work for multiple digits.
    //3. make it work for negative sign.
    //4. take care of overflows.
    
    // Conclusion:
    // use for loop instead of LINQ's Aggregate, so you have more control.
    public int MyAtoi()
    {
        string s = "9128347233";
        s = s.Trim();   
        int sign = 1;
        int startIndex = 0;
        if ("+-".Any(sign => s[0] == sign))
        {
            sign = s[0] == '-' ? -1 : 1;
            startIndex = 1;
        }
        
        long result = 0;
        for (int i = startIndex; i < s.Length; i++)
        {
            if (!char.IsDigit(s[i]))
            {
                break;
            }
            result = result * 10 + (s[i] - '0');
            if (result * sign < Int32.MinValue)
            {
                return Int32.MinValue;
            }
        
            if (result * sign > Int32.MaxValue)
            {
                return Int32.MaxValue;
            }
        }

        return (int)result * sign;
    }
    
    
    //Code that uses LINQ:
    public int MyAtoiLINQ()
    {
        //fails MyAtoi_InputOverflowsPt2_ShouldReturnIntMax() test
        string s = "9128347233";
        s = s.Trim();   
        int sign = 1;
        if ("+-".Any(sign => s[0] == sign))
        {
            sign = s[0] == '-' ? -1 : 1;
            s = s[1..];
        }
        
        var result = 
            s.TakeWhile(char.IsDigit)
                .Aggregate(0L, (accumulate, character) => accumulate * 10 + (character - '0'));

        if (result * sign > Int32.MaxValue)
        {
            return Int32.MaxValue;
        }
        
        if (result * sign < Int32.MinValue)
        {
            return Int32.MinValue;
        }
        return (int)result * sign;
    }
}