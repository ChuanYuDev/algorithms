namespace Leetcode.MaximumNumberOfBalloons;

//  Use int[] with char index to replace dictionary

//  w: # of word
//  t: # of text
//  Time complexity: O(w + t + 26)
//  Space complexity: O(26)

public class Solution2
{
    public int MaxNumberOfBalloons(string text)
    {
        var word = "balloon";
        var wordFreq = new int[26];

        foreach (var c in word)
        {
            wordFreq[c - 'a']++;
        }

        var textFreq = new int[26];
        foreach (var c in text)
        {
            var cIdx = c - 'a';
            if (wordFreq[cIdx] == 0) continue;
            textFreq[cIdx]++;
        }

        var minTextFreq = int.MaxValue;

        for (var i = 0; i <= textFreq.Length - 1; i++)
        {
            if (wordFreq[i] == 0) continue;
            minTextFreq = Math.Min(minTextFreq, textFreq[i] / wordFreq[i]);
        }

        return minTextFreq;
    }
}