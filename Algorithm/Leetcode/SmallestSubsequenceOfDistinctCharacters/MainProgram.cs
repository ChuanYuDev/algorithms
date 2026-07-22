namespace Leetcode.SmallestSubsequenceOfDistinctCharacters;
/*
Smallest Subsequence of Distinct Characters
Medium
   
Given a string s, return the lexicographically smallest subsequence of s that contains all the distinct characters of s exactly once.
   
Example 1:
Input: s = "bcabc"
Output: "abc"

Example 2:
Input: s = "cbacdcbc"
Output: "acdb"
   
Constraints:
    1 <= s.length <= 1000
    s consists of lowercase English letters.
   
Note: This question is the same as 316: https://leetcode.com/problems/remove-duplicate-letters/
*/

/*
Hint 1
    Greedily try to add one missing character.
    How to check if adding some character will not cause problems ?
    Use bit-masks to check whether you will be able to complete the sub-sequence if you add the character at some index i.
*/

/*
Lexicographically Smaller
    A string a is lexicographically smaller than a string b if in the first position where a and b differ, string a has a letter that appears earlier in the alphabet than the corresponding letter in b.
    If the first min(a.length, b.length) characters do not differ, then the shorter string is the lexicographically smaller one.

Subsequence
    A subsequence is a string that can be derived from another string by deleting some or no characters without changing the order of the remaining characters.
*/

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution2();

        var s = "bcabc";
        Console.WriteLine(sol.SmallestSubsequence(s));
        // Output: "abc"

        s = "cbacdcbc";
        Console.WriteLine(sol.SmallestSubsequence(s));
        // Output: "acdb"
    }
}