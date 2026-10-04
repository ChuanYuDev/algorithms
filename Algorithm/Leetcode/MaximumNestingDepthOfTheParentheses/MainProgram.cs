namespace Leetcode.MaximumNestingDepthOfTheParentheses;
/*
Maximum Nesting Depth of the Parentheses
Easy
   
Given a valid parentheses string s, return the nesting depth of s.
    The nesting depth is the maximum number of nested parentheses.

Example 1:
Input: s = "(1+(2*3)+((8)/4))+1"
Output: 3
Explanation: Digit 8 is inside of 3 nested parentheses in the string.

Example 2:
Input: s = "(1)+((2))+(((3)))"
Output: 3
Explanation: Digit 3 is inside of 3 nested parentheses in the string.

Example 3:
Input: s = "()(())((()()))"
Output: 3

Constraints:
    1 <= s.length <= 100
    s consists of digits 0-9 and characters '+', '-', '*', '/', '(', and ')'.
    It is guaranteed that parentheses expression s is a VPS.
*/

/*
stack char
leftNum = 0
maxLeftNum = 0

if left
    push into stack
    leftNum++    
    maxLeftNum = max(maxLeftNum, leftNum)

if right
    stack pop
    leftNum--
    
else continue
*/

public class Solution
{
    public int MaxDepth(string s)
    {
        int leftNum = 0, maxLeftNum = 0;

        foreach (var c in s)
        {
            switch (c)
            {
                case '(':
                    leftNum++;
                    maxLeftNum = Math.Max(maxLeftNum, leftNum);
                    break;
                
                case ')':
                    leftNum--;
                    break;
            }
        }

        return maxLeftNum;
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();

        var s = "(1+(2*3)+((8)/4))+1";
        Console.WriteLine(sol.MaxDepth(s));
        // Output: 3

        s = "(1)+((2))+(((3)))";
        Console.WriteLine(sol.MaxDepth(s));
        // Output: 3

        s = "()(())((()()))";
        Console.WriteLine(sol.MaxDepth(s));
        // Output: 3
    }
}