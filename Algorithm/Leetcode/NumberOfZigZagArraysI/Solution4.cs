namespace Leetcode.NumberOfZigZagArraysI;

//  Runtime 503 ms, Beats 22.58%

//  Optimization
//  1. Separate int[range, 2] _dp, _sumDp into two arrays, maybe better to cache
//  2. Change class member to local variable

public class Solution4
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
            for (var j = l + 1; j <= r; j++) sumDp0[j] = (sumDp0[j - 1] + dp0[j - 1]) % Mod;
        
            sumDp1[r] = 0;
            for (var j = r - 1; j >= l; j--) sumDp1[j] = (sumDp1[j + 1] + dp1[j + 1]) % Mod;
        }

        return (sumDp0[r] + sumDp1[l]) % Mod;
    }
}
