namespace Leetcode.LongestValidParentheses;
/*
Longest Valid Parentheses
Hard

Given a string containing just the characters '(' and ')', return the length of the longest valid (well-formed) parentheses substring.

Example 1:

Input: s = "(()"
Output: 2
Explanation: The longest valid parentheses substring is "()".

Example 2:
Input: s = ")()())"
Output: 4
Explanation: The longest valid parentheses substring is "()()".

Example 3:
Input: s = ""
Output: 0

Constraints:
    0 <= s.length <= 3 * 10^4
    s[i] is '(', or ')'.
*/

/*
())()
) is break
*/

/*
()(()
*/

/*
()((()(())
pp((pppppp
*/

/*
stack index
Scan from left to right
if left
    push into stack

if right
    if stack is empty
        continue
    
    else
        set the matched pair to "p"

Scan again
Calculate longest p 
*/

/*
stack char
len = 0
maxLen = 0

if c is ')' 
    if stack.Count == 0
        maxLen = max(maxLen, len)
        len = 0 
    else
        stack pop
        len++
*/

/* Complexity
Time complexity: O(n)
Space complexity: O(n)
*/

public class Solution
{
    public int LongestValidParentheses(string s)
    {
        var length = s.Length;
        var charArray = s.ToCharArray();
        var indexStack = new Stack<int>();

        for (var i = 0; i <= length - 1; i++)
        {
            switch (charArray[i])
            {
                case '(':
                    indexStack.Push(i);
                    break;
                
                case ')':
                    if (indexStack.Count == 0) break;

                    var top = indexStack.Pop();
                    charArray[i] = 'p';
                    charArray[top] = 'p';
                    break;
            }
        }

        int len = 0, maxLen = 0;

        for (var i = 0; i <= length - 1; i++)
        {
            switch (charArray[i])
            {
                case 'p':
                    len++;
                    break;
                
                default:
                    maxLen = Math.Max(maxLen, len);
                    len = 0;
                    break;
            }
        }

        return Math.Max(maxLen, len);
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        var s = "(()";
        Console.WriteLine(sol.LongestValidParentheses(s));
        // Output: 2

        s = ")()())";
        Console.WriteLine(sol.LongestValidParentheses(s));
        // Output: 4

        s = "";
        Console.WriteLine(sol.LongestValidParentheses(s));
        // Output: 0

        s = "()((()(())";
        Console.WriteLine(sol.LongestValidParentheses(s));
        // Output: 6
    }
}