namespace Leetcode.CountTheNumberOfSpecialCharactersI;

//  Count the Number of Special Characters I
//  Easy
//  You are given a string word.
//  A letter is called special if it appears both in lowercase and uppercase in word.
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
//  Input: word = "abBCab"
//  Output: 1
//
//  Constraints:
//  1 <= word.length <= 50
//  word consists of only lowercase and uppercase English letters.

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        var word = "aaAbcBC";
        Console.WriteLine(sol.NumberOfSpecialChars(word));
        //  Output: 3

        word = "abc";
        Console.WriteLine(sol.NumberOfSpecialChars(word));
        //  Output: 0

        word = "abBCab";
        Console.WriteLine(sol.NumberOfSpecialChars(word));
        //  Output: 1
    }
}