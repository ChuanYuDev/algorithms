namespace Leetcode.RotatedDigits;

//  Rotated Digits
//  Medium
//  An integer x is a good if after rotating each digit individually by 180 degrees, we get a valid number that is different from x.
//  Each digit must be rotated - we cannot choose to leave it alone.
//
//  A number is valid if each digit remains a digit after rotation.
//  For example:
//      0, 1, and 8 rotate to themselves,
//      2 and 5 rotate to each other (in this case they are rotated in a different direction, in other words, 2 or 5 gets mirrored),
//      6 and 9 rotate to each other, and
//      the rest of the numbers do not rotate to any other number and become invalid.
//
//  Given an integer n, return the number of good integers in the range [1, n].
//
//  Example 1:
//  Input: n = 10
//  Output: 4
//
//  Example 2:
//  Input: n = 1
//  Output: 0
//
//  Example 3:
//  Input: n = 2
//  Output: 1
//
//  Constraints:
//      1 <= n <= 10^4

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution2();
        int n = 10;
        Console.WriteLine(sol.RotatedDigits(n));
        //  Output: 4

        n = 1;
        Console.WriteLine(sol.RotatedDigits(n));
        //  Output: 0

        n = 2;
        Console.WriteLine(sol.RotatedDigits(n));
        //  Output: 1

        n = 20;
        Console.WriteLine(sol.RotatedDigits(n));
        //  Output: 1

        n = 857;
        Console.WriteLine(sol.RotatedDigits(n));
        //  Output: 247
    }
}