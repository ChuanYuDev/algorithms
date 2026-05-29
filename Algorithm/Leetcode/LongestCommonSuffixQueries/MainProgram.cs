using Helper;

namespace Leetcode.LongestCommonSuffixQueries;
//  Longest Common Suffix Queries
//  Hard
//
//  You are given two arrays of strings wordsContainer and wordsQuery.
//
//  For each wordsQuery[i], you need to find a string from wordsContainer that has the longest common suffix with wordsQuery[i].
//  If there are two or more strings in wordsContainer that share the longest common suffix, find the string that is the smallest in length.
//  If there are two or more such strings that have the same smallest length, find the one that occurred earlier in wordsContainer.
//
//  Return an array of integers ans, where ans[i] is the index of the string in wordsContainer that has the longest common suffix with wordsQuery[i].
//
//  Example 1:
//  Input: wordsContainer = ["abcd","bcd","xbcd"], wordsQuery = ["cd","bcd","xyz"]
//  Output: [1,1,1]
//
//  Example 2:
//  Input: wordsContainer = ["abcdefgh","poiuygh","ghghgh"], wordsQuery = ["gh","acbfgh","acbfegh"]
//  Output: [2,0,2]
//
//  Constraints:
//      1 <= wordsContainer.length, wordsQuery.length <= 10^4
//      1 <= wordsContainer[i].length <= 5 * 10^3
//      1 <= wordsQuery[i].length <= 5 * 10^3
//      wordsContainer[i] consists only of lowercase English letters.
//      wordsQuery[i] consists only of lowercase English letters.
//      Sum of wordsContainer[i].length is at most 5 * 10^5.
//      Sum of wordsQuery[i].length is at most 5 * 10^5.

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution2();
        string[] wordsContainer = ["abcd", "bcd", "xbcd"], wordsQuery = ["cd", "bcd", "xyz"];
        PrintHelper.PrintArray(sol.StringIndices(wordsContainer, wordsQuery));
        //  Output: [1,1,1]

        wordsContainer = ["abcdefgh", "poiuygh", "ghghgh"];
        wordsQuery = ["gh", "acbfgh", "acbfegh"];
        PrintHelper.PrintArray(sol.StringIndices(wordsContainer, wordsQuery));
        //  Output: [2,0,2]

        wordsContainer = ["abcde", "abcde"];
        wordsQuery = ["abcde", "bcde", "cde", "de", "e"];
        PrintHelper.PrintArray(sol.StringIndices(wordsContainer, wordsQuery));
        //  Output: [0,0,0,0,0]
    }
}