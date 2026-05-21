namespace Leetcode.FindThePrefixCommonArrayOfTwoArrays;
public class Solution
{
    public int[] FindThePrefixCommonArray(int[] a, int[] b)
    {
        var aMap = new Dictionary<int, int>();
        var bMap = new Dictionary<int, int>();

        var length = a.Length;

        int[] c = new int[length];

        c[0] = a[0] == b[0] ? 1 : 0;

        for (var i = 1; i < length; i++)
        {
            aMap[a[i - 1]] = 1;
            bMap[b[i - 1]] = 1;
            
            c[i] = c[i - 1];

            if (a[i] == b[i])
                c[i] += 1;
            else
            {
                if (bMap.ContainsKey(a[i]))
                    c[i] += 1;

                if (aMap.ContainsKey(b[i]))
                    c[i] += 1;
            }
        }

        return c;
    }
}
