namespace Leetcode.RearrangeCharactersToMakeTargetString;

//  Rearrange Characters to Make Target String
//  Easy
//  You are given two 0-indexed strings s and target.
//      You can take some letters from s and rearrange them to form new strings.
//
//  Return the maximum number of copies of target that can be formed by taking letters from s and rearranging them.
//
//  Example 1:
//  Input: s = "ilovecodingonleetcode", target = "code"
//  Output: 2
//
//  Example 2:
//  Input: s = "abcba", target = "abc"
//  Output: 1
//
//  Example 3:
//  Input: s = "abbaccaddaeea", target = "aaaaa"
//  Output: 1
//
//  Constraints:
//      1 <= s.length <= 100
//      1 <= target.length <= 10
//      s and target consist of lowercase English letters.

//  tn: # of target
//  sn: # of s
//  Time complexity: O(tn + sn + 26)
//  Space complexity: O(26)

public class Solution
{
    public int RearrangeCharacters(string s, string target)
    {
        var targetFreq = new int[26];

        foreach (var c in target)
        {
            targetFreq[c - 'a']++;
        }

        var sFreq = new int[26];
        foreach (var c in s)
        {
            var cIdx = c - 'a';
            if (targetFreq[cIdx] == 0) continue;
            sFreq[cIdx]++;
        }

        var minSFreq = int.MaxValue;

        for (var i = 0; i <= sFreq.Length - 1; i++)
        {
            if (targetFreq[i] == 0) continue;
            minSFreq = Math.Min(minSFreq, sFreq[i] / targetFreq[i]);
        }

        return minSFreq;
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        string s = "ilovecodingonleetcode", target = "code";
        Console.WriteLine(sol.RearrangeCharacters(s, target));
        //  Output: 2

        s = "abcba";
        target = "abc";
        Console.WriteLine(sol.RearrangeCharacters(s, target));
        //  Output: 1

        s = "abbaccaddaeea";
        target = "aaaaa";
        Console.WriteLine(sol.RearrangeCharacters(s, target));
        //  Output: 1
    }
}