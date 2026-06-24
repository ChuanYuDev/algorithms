namespace Leetcode.TotalWavinessOfNumbersInRangeII;
//  Total Waviness of Numbers in Range II
//  Hard
//  Problem description is the same as Total Waviness of Numbers in Range I, except for constraints
//
//  You are given two integers num1 and num2 representing an inclusive range [num1, num2].
//
//  The waviness of a number is defined as the total count of its peaks and valleys:
//      A digit is a peak if it is strictly greater than both of its immediate neighbors.
//      A digit is a valley if it is strictly less than both of its immediate neighbors.
//      The first and last digits of a number cannot be peaks or valleys.
//      Any number with fewer than 3 digits has a waviness of 0.
//
//  Return the total sum of waviness for all numbers in the range [num1, num2].
//
//  Example 1:
//  Input: num1 = 120, num2 = 130
//  Output: 3
//
//  Example 2:
//  Input: num1 = 198, num2 = 202
//  Output: 3
//
//  Example 3:
//  Input: num1 = 4848, num2 = 4848
//  Output: 2
//
//  Constraints:
//      1 <= num1 <= num2 <= 10^15

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution3();
        long num1 = 120, num2 = 130;
        Console.WriteLine(sol.TotalWaviness(num1, num2));
        //  Output: 3

        num1 = 198;
        num2 = 202;
        Console.WriteLine(sol.TotalWaviness(num1, num2));
        //  Output: 3

        num1 = 4848;
        num2 = 4848;
        Console.WriteLine(sol.TotalWaviness(num1, num2));
        //  Output: 2

        num1 = 8900;
        num2 = 9532;
        Console.WriteLine(sol.TotalWaviness(num1, num2));
        //  Output: 794

        num1 = 2549294942;
        num2 = 5067104447;
        Console.WriteLine(sol.TotalWaviness(num1, num2));
        //  Output: 11661365485
    }
}