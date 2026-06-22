namespace Leetcode.MaximumNumberOfBalloons;

//  w: # of word
//  t: # of text
//  Time complexity: O(w + t + 26)
//  Space complexity: O(26)

public class Solution
{
    public int MaxNumberOfBalloons(string text)
    {
        var word = "balloon";
        var wordFreq = new Dictionary<char, int>();
        var textFreq = new Dictionary<char, int>();

        foreach (var c in word)
        {
            if (wordFreq.ContainsKey(c)) wordFreq[c]++;
            else
            {
                wordFreq[c] = 1;
                textFreq[c] = 0;
            }
        }

        foreach (var c in text)
        {
            if (!textFreq.ContainsKey(c)) continue;
            textFreq[c]++;
        }

        var minTextFreq = int.MaxValue;
        foreach (var key in textFreq.Keys) minTextFreq = Math.Min(minTextFreq, textFreq[key] / wordFreq[key]);

        return minTextFreq;
    }
}
