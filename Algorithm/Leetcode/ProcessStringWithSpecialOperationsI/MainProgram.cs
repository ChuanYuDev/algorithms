using System.Text;

namespace Leetcode.ProcessStringWithSpecialOperationsI;

//  Process String with Special Operations I
//  Medium

//  You are given a string s consisting of lowercase English letters and the special characters: *, #, and %.
//  Build a new string result by processing s according to the following rules from left to right:
//      If the letter is a lowercase English letter append it to result.
//      A '*' removes the last character from result, if it exists.
//      A '#' duplicates the current result and appends it to itself.
//      A '%' reverses the current result.
//
//  Return the final string result after processing all characters in s.
//
//  Example 1:
//  Input: s = "a#b%*"
//  Output: "ba"
//
//  Example 2:
//  Input: s = "z*#"
//  Output: ""
//
//  Constraints:
//      1 <= s.length <= 20
//      s consists of only lowercase English letters and special characters *, #, and %.
    
//  "a#b%*"
//
//  a
//  aa  
//  aab
//  baa
//  ba

//  Time complexity
//      Append(char): O(1)
//      #, %: O(result.Length)
//      worst case 1+2+2^2+...2^n = O(2^n)

//  Space complexity: O(2^n)

//  Use StringBuilder

//  Pseudocode
//  result = new StringBuilder()

//  foreach c in s
//      if (c == '*')      
//          if (result.Length > 0) result.Length--
//          continue
//      if (c == '#')
//          result.Append(result)
//          continue
//      if (c == '%')
//          charArray = result.ToString().ToCharArray()
//          Array.Reverse(charArray)
//          result = new StringBuilder(new String(charArray))
//          continue
//      result.Append(c)
//  return result
public class Solution
{
    public string ProcessStr(string s)
    {
        var result = new StringBuilder();

        foreach (var c in s)
        {
            switch (c)
            {
                case '*':
                    if (result.Length > 0) result.Length--;
                    break;
                
                case '#':
                    result.Append(result);
                    break;
                
                case '%':
                    var charArray = result.ToString().ToCharArray();
                    Array.Reverse(charArray);
                    result = new StringBuilder(new string(charArray));
                    break;
                
                default:
                    result.Append(c);
                    break;
            }
        }
        
        return result.ToString();
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        string s = "a#b%*";
        Console.WriteLine(sol.ProcessStr(s));
        //  Output: "ba"

        s = "z*#";
        Console.WriteLine(sol.ProcessStr(s));
        //  Output: ""
    }
}