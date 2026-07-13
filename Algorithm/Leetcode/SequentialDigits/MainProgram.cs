using Helper;

namespace Leetcode.SequentialDigits;

//  Sequential Digits
//  Medium
//  An integer has sequential digits if and only if each digit in the number is one more than the previous digit.
//
//  Return a sorted list of all the integers in the range [low, high] inclusive that have sequential digits.
//
//  Example 1:
//  Input: low = 100, high = 300
//  Output: [123,234]
//
//  Example 2:
//  Input: low = 1000, high = 13000
//  Output: [1234,2345,3456,4567,5678,6789,12345]
//
//  Constraints:
//  10 <= low <= high <= 10^9

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution2();
        
        int low = 100, high = 300;
        PrintHelper.PrintEnumerable(sol.SequentialDigits(low, high));
        //  Output: [123,234]

        low = 1000;
        high = 13000;
        PrintHelper.PrintEnumerable(sol.SequentialDigits(low, high));
        //  Output: [1234,2345,3456,4567,5678,6789,12345]
    }
}