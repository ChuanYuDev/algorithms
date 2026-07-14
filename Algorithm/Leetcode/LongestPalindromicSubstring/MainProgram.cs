namespace Leetcode.LongestPalindromicSubstring;

//  Longest Palindromic Substring
//  Medium
//
//  Given a string s, return the longest palindromic substring in s.
//
//  Example 1:
//  Input: s = "babad"
//  Output: "bab"
//  Explanation: "aba" is also a valid answer.
//
//  Example 2:
//  Input: s = "cbbd"
//  Output: "bb"
//
//  Constraints:
//      1 <= s.length <= 1000
//      s consist of only digits and English letters.

//  Input: s = "babad"
//  Output: "bab"

//  center: b x a x b x a x d

//  babad
//     i 
//  j
//  i-j>=0 && i+j<=length-1
//  j <= i && j <= length - 1 - i

//  string LongestPalindrome(string s)
//      length = s.Length
//      lPLen = 0
//      start = 0
//      for (var i  = 0; i <= length - 1; i++)
//          len = 1
//          maxJ = Math.Min(i, length - 1 - i)
//          for (var j = 1; j <= maxJ; j++)
//              if (s[i-j] != s[i+j]) break;
//              len+=2
//          
//          if (len > lPLen)
//              lPLen = len
//              start = i - (j - 1)

//  b    a   b   a   d
//  i    i+1 
//  j from 0
//  i-j>=0, i+1+j <= length-1
//  j<=i, j <= length-2-i

//      for (var i  = 0; i <= length - 2; i++)
//          len = 0
//          maxJ = Math.Min(i, length - 2 - i)
//          for (var j = 0; j <= maxJ; j++)
//              if (s[i-j] != s[i+1+j]) break;
//              len+=2
//          
//          if (len > lPLen)
//              lPLen = len
//              start = i - (j - 1)
//
//      return s.Substring(start, lPLen)

//  Time complexity: O(n^2)
//  Space complexity: O(1)
//      We don't count the answer as part of the space complexity

public class Solution
{
    public string LongestPalindrome(string s)
    {
        var length = s.Length;
        var lPLen = 0;
        var start = 0;

        for (var i = 0; i <= length - 1; i++)
        {
            var len = 1;
            var j = 0;
            var maxJ = Math.Min(i, length - 1 - i);

            for (j = 1; j <= maxJ; j++)
            {
                if (s[i - j] != s[i + j]) break;
                len += 2;
            }

            if (len <= lPLen) continue;
            lPLen = len;
            start = i - (j - 1);
        }
        
        for (var i = 0; i <= length - 2; i++)
        {
            var len = 0;
            var j = 0;
            var maxJ = Math.Min(i, length - 2 - i);

            for (j = 0; j <= maxJ; j++)
            {
                if (s[i - j] != s[i + 1 + j]) break;
                len += 2;
            }

            if (len <= lPLen) continue;
            lPLen = len;
            start = i - (j - 1);
        }

        return s.Substring(start, lPLen);
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();

        var s = "babad";
        Console.WriteLine(sol.LongestPalindrome(s));
        //  Output: "bab"

        s = "cbbd";
        Console.WriteLine(sol.LongestPalindrome(s));
        //  Output: "bb"
    }
}