namespace Leetcode.NumberOfZigZagArraysI;

//  Runtime 271 ms, Beats 89.03%

//  Optimization
//  1. Merge two loops of calculating sumDp0 and sumDp1 into one loop
//      Why does this improve runtime??

public class Solution5
{
    private const int Mod = 1_000_000_007;
    
    public int ZigZagArrays(int n, int l, int r)
    {
        r -= l;
        l = 0;
        var range = r - l + 1;
        var dp0 = new int[range];
        var dp1 = new int[range];
        var sumDp0 = new int[range];
        var sumDp1 = new int[range];
        
        for (var j = l; j <= r; j++)
        {
            dp0[j] = 1;
            dp1[j] = 1;
            sumDp0[j] = j - l;
            sumDp1[j] = r - j;
        }

        for (var i = 2; i <= n; i++)
        {
            for (var j = l; j <= r; j++)
            {
                dp0[j] = sumDp1[j];
                dp1[j] = sumDp0[j];
            }

            sumDp0[l] = 0;
            sumDp1[r] = 0;
            for (var j = l + 1; j <= r; j++)
            {
                sumDp0[j] = (sumDp0[j - 1] + dp0[j - 1]) % Mod;
                sumDp1[-j + r + l] = (sumDp1[-j + r + l + 1] + dp1[-j + r + l + 1]) % Mod;

            }
        }

        return (sumDp0[r] + sumDp1[l]) % Mod;
    }
}
