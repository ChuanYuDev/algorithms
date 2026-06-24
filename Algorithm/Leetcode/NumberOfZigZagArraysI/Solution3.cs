namespace Leetcode.NumberOfZigZagArraysI;

//  Runtime 705 ms, Beats 9.03%

//  Optimization
//  1. _dp ,_sumDp1 and _sumDp0 have the same i, we can use one-dimensional array to store them respectively
//      Then use _sumDp1 and _sumDp0 to calculate the next layer _dp

//  Time complexity:
//      D: r - l + 1
//      Total: O(D * n)

//  Space complexity:
//      dp: O(D)

public class Solution3
{
    private int[,] _dp = null!;
    private int[,] _sumDp = null!;
    private const int Mod = 1_000_000_007;
    
    public int ZigZagArrays(int n, int l, int r)
    {
        r -= l;
        l = 0;
        var range = r - l + 1;
        _dp = new int[range, 2];
        _sumDp = new int[range, 2];
        
        for (var j = l; j <= r; j++)
        {
            _dp[j, 0] = 1;
            _dp[j, 1] = 1;
            //  l <= x < j
            _sumDp[j, 0] = j - l;
            //  j < x <= r
            _sumDp[j, 1] = r - j;
        }

        for (var i = 2; i <= n; i++)
        {
            for (var j = l; j <= r; j++)
            {
                _dp[j, 0] = _sumDp[j, 1];
                _dp[j, 1] = _sumDp[j, 0];
            }

            _sumDp[l, 0] = 0;
            for (var j = l + 1; j <= r; j++) _sumDp[j, 0] = (_sumDp[j - 1, 0] + _dp[j - 1, 0]) % Mod;
        
            _sumDp[r, 1] = 0;
            for (var j = r - 1; j >= l; j--) _sumDp[j, 1] = (_sumDp[j + 1, 1] + _dp[j + 1, 1]) % Mod;
        }

        return (_sumDp[r, 0] + _sumDp[l, 1]) % Mod;
    }
}
