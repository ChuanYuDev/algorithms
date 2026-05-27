namespace Leetcode.CountTheNumberOfSpecialCharactersII;

//  Count the Number of Special Characters II
//  Medium
//         
//  You are given a string word.
//  A letter c is called special if it appears both in lowercase and uppercase in word, and every lowercase occurrence of c appears before the first uppercase occurrence of c.
//
//  Return the number of special letters in word.
//
//  Example 1:
//  Input: word = "aaAbcBC"
//  Output: 3
//
//  Example 2:
//  Input: word = "abc"
//  Output: 0
//
//  Example 3:
//  Input: word = "AbBCab"
//  Output: 0
//
//  Constraints:
//      1 <= word.length <= 2 * 10^5
//      word consists of only lowercase and uppercase English letters.

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();

        string word = "aaAbcBC";
        Console.WriteLine(sol.NumberOfSpecialChars(word));
        //  Output: 3

        word = "abc";
        Console.WriteLine(sol.NumberOfSpecialChars(word));
        //  Output: 0

        word = "AbBCab";
        Console.WriteLine(sol.NumberOfSpecialChars(word));
        //  Output: 0
    }
}