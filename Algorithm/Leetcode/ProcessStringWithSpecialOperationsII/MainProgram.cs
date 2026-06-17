namespace Leetcode.ProcessStringWithSpecialOperationsII;

//  Process String with Special Operations II
//  Hard
//  You are given a string s consisting of lowercase English letters and the special characters: '*', '#', and '%'.
//  You are also given an integer k.
//  Build a new string result by processing s according to the following rules from left to right:
//      If the letter is a lowercase English letter append it to result.
//      A '*' removes the last character from result, if it exists.
//      A '#' duplicates the current result and appends it to itself.
//      A '%' reverses the current result.
//  Return the kth character of the final string result.
//  If k is out of the bounds of result, return '.'.
//
//  Example 1:
//  Input: s = "a#b%*", k = 1
//  Output: "a"
//
//  Example 2:
//  Input: s = "cd%#*#", k = 3
//  Output: "d"
//
//  Example 3:
//  Input: s = "z*#", k = 0
//  Output: "."
//
//  Constraints:
//      1 <= s.length <= 10^5
//      s consists of only lowercase English letters and special characters '*', '#', and '%'.
//      0 <= k <= 10^15
//      The length of result after processing s will not exceed 10^15.

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution2();
        string s = "a#b%*";
        long k = 1;
        Console.WriteLine(sol.ProcessStr(s, k));
        //  Output: "a"

        s = "cd%#*#";
        k = 3;
        Console.WriteLine(sol.ProcessStr(s, k));
        //  Output: "d"

        s = "z*#";
        k = 0;
        Console.WriteLine(sol.ProcessStr(s, k));
        //  Output: "."

        s = "jio#*g";
        k = 1;
        Console.WriteLine(sol.ProcessStr(s, k));
        //  Output: "i"
    }
}