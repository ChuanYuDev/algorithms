namespace Leetcode.ValidParenthesisString;

/*
Valid Parenthesis String
Medium

Given a string s containing only three types of characters: '(', ')' and '*', return true if s is valid.

The following rules define a valid string:
    Any left parenthesis '(' must have a corresponding right parenthesis ')'.
    Any right parenthesis ')' must have a corresponding left parenthesis '('.
    Left parenthesis '(' must go before the corresponding right parenthesis ')'.
    '*' could be treated as a single right parenthesis ')' or a single left parenthesis '(' or an empty string "".

Example 1:
Input: s = "()"
Output: true

Example 2:
Input: s = "(*)"
Output: true

Example 3:
Input: s = "(*))"
Output: true

Example 4:
Input: s = "("
Output: false
 
Constraints:
    1 <= s.length <= 100
    s[i] is '(', ')' or '*'.
*/

/*
(*)
((*)
(*))
*/

/*
(()*
based on the rules, 0 can match with 2, 1 can match with 3
*/

/*
Convert string to char array

((**((*)
-> (**((* No
-> ((**(* Yes
Left matches with the nearest right
Stack index

**)*()**()**((**(*)
->
**)*  **  **((** *
All matched pairs are set to ""

if right
    if stack is empty, continue
    if not, matched pairs are set to ""

if left, push index into stack

if *, continue

Scan from left to right, stack character
if right
    if stack top is *, match
    if stack is empty invalid
    
if left, push to stack
if *
    if stack top is left, match
    if stack top is *, push 
    
if "", continue
    
i == length, if stack top is *, valid
    else is left, invalid
/*
 
/*
(((((()*)(*)*))())())(()())())))((**)))))(()())()";
->
***)))**)))";
*/    

/* Complexity
Time complexity: O(n)
Space complexity: O(n)
*/

public class Solution
{
    public bool CheckValidString(string s)
    {
        var length = s.Length;
        var charArray = s.ToCharArray();

        var indexStack = new Stack<int>();

        for (var i = 0; i <= length - 1; i++)
        {
            switch (charArray[i])
            {
                case '*':
                    break;
                
                case '(':
                    indexStack.Push(i);
                    break;
                
                case ')':
                    if (indexStack.Count == 0) break;
                    
                    var index = indexStack.Pop();
                    charArray[index] = 'p';
                    charArray[i] = 'p';
                    break;
            }
        }

        var charStack = new Stack<char>();
        char top;
        
        for (var i = 0; i <= length - 1; i++)
        {
            switch (charArray[i])
            {
                case ')':
                    if (charStack.Count == 0) return false;

                    // Must be '*'
                    charStack.Pop();
                    break;
                
                case '(':
                    charStack.Push(charArray[i]);
                    break;
                
                case '*':
                    if (charStack.Count == 0)
                    {
                        charStack.Push(charArray[i]);
                        break;
                    }

                    top = charStack.Peek();

                    if (top == '(')
                    {
                        charStack.Pop();
                        break;
                    }
                    
                    // Must be '*'
                    charStack.Push(charArray[i]);
                    break;
                
                case 'p':
                    break;
            }
        }

        if (charStack.Count == 0) return true;
        
        top = charStack.Peek();

        if (top == '(') return false;

        // Must be '*'
        return true;
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        
        var s = "()";
        Console.WriteLine(sol.CheckValidString(s));
        // Output: true

        s = "(*)";
        Console.WriteLine(sol.CheckValidString(s));
        // Output: true

        s = "(*))";
        Console.WriteLine(sol.CheckValidString(s));
        // Output: true

        s = "(";
        Console.WriteLine(sol.CheckValidString(s));
        // Output: false

        s = "**)*()**()**((**(*)";
        Console.WriteLine(sol.CheckValidString(s));
        // Output: true

        s = "(((((()*)(*)*))())())(()())())))((**)))))(()())()";
        Console.WriteLine(sol.CheckValidString(s));
        // Output: false
    }
}