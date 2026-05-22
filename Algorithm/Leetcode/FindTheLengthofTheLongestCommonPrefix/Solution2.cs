namespace Leetcode.FindTheLengthofTheLongestCommonPrefix;

//  Add all of prefix of every number in arr1 to HashSet
//
//  For every number in arr2, check whether it or its prefix can be found in HashSet

public class Solution2
{
    private int GetDigitsLength(int num)
    {
        int digitsLength = 0;

        while (num > 0)
        {
            num /= 10;
            digitsLength++;
        }

        return digitsLength;
    }
    
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        HashSet<int> prefixes = new HashSet<int>();
        int longestLength = 0;

        for (var i = 0; i < arr1.Length; i++)
        {
            var num = arr1[i];
            while (num > 0)
            {
                prefixes.Add(num);
                num /= 10;
            }
        }

        for (var i = 0; i < arr2.Length; i++)
        {
            var num = arr2[i];

            while (num > 0)
            {
                if (prefixes.Contains(num)) break;

                num /= 10;
            }

            var digitsLength = GetDigitsLength(num);

            if (digitsLength > longestLength) longestLength = digitsLength;
        }

        return longestLength;
    }
}