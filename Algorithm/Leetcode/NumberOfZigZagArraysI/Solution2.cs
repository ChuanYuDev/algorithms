namespace Leetcode.NumberOfZigZagArraysI;

//  Optimization
//  1. Simplify dfs + dp to dp only
//  2. Even int + int may overflow, but (int + int) % Mod will return back to int range

//  Input: n = 3, l = 1, r = 3
//      [1, 2, 1], [1, 3, 1], [1, 3, 2]
//      [2, 1, 2], [2, 1, 3], [2, 3, 1], [2, 3, 2]
//      [3, 1, 2], [3, 1, 3], [3, 2, 3]

//  dp[1, y, 0] = sum(dp[0,x,1]) x > y, y from l to r

//  idx        i  i+1
//          z, x, y
//  dp[i+1, y, 0] = sum(dp[i,x,1]) x > y, y from l to r
//      l < x <= r
//      l+1 < x <= r
//      l+2 < x <= r
//      ...
//      r < x <= r
//      no suffix sum: O(D^2)
//      calculate suffix sum: O(D)
//      prefix sum: O(D)

//  sumDp1[i, min] = sum(dp[i,x,1]) min < x <= r
//  dp[i+1, y, 0] = sumDp1[i, y]

//  dp[i+1, y, 1] = sum(dp[i,x,0]) x < y, y from l to r
//      l <= x < l
//      l <= x < l+1
//      l <= x < l+2
//      ...
//      l <= x < r

//  sumDp0[i, max] = sum(dp[i,x,0]) l <= x < max
//  dp[i+1, y, 1] = sumDp0[i, y]

//  result = sum(dp[n,y,0]) + sum(dp[n,y,1]) = sumDp0[n, r] + sumDp1[n,l]
//      0: l <= y < r
//      1: l < y <= r

//  n = 3, l = 4, r = 5
//  x in [0, 1]
//  i   x   inc dp
//  1   0   0   1
//  1   0   1   1
//  1   1   0   1
//  1   1   1   1

//  i   max sumDp0  
//  1   0   0       
//  1   1   1       
//  i   min sumDp1
//  1   0   1
//  1   1   0

//  i   x   inc dp
//  2   0   0   1   
//  2   0   1   0
//  2   1   0   0
//  2   1   1   1

//  i   x   inc dp
//  3   0   0   1   
//  3   0   1   0
//  3   1   0   0
//  3   1   1   1

//  Time complexity:
//      D: r - l + 1
//      Total: O(D * n)

//  Space complexity:
//      dp: O(D * n)

public class Solution2
{
    private int[,,] _dp = null!;
    private int[,] _sumDp0 = null!;
    private int[,] _sumDp1 = null!;
    private const int Mod = 1_000_000_007;
    
    public int ZigZagArrays(int n, int l, int r)
    {
        r -= l;
        l = 0;
        var range = r - l + 1;
        _dp = new int[n + 1, range, 2];
        _sumDp0 = new int[n + 1, range];
        _sumDp1 = new int[n + 1, range];

        for (var i = 1; i <= n; i++)
        {
            if (i == 1)
            {
                for (var j = l; j <= r; j++)
                {
                    _dp[i, j, 0] = 1;
                    _dp[i, j, 1] = 1;
                }
                
            }
            else
            {
                for (var j = l; j <= r; j++) _dp[i, j, 0] = _sumDp1[i - 1, j];
                for (var j = l; j <= r; j++) _dp[i, j, 1] = _sumDp0[i - 1, j];
            }

            _sumDp0[i, 0] = 0;
            for (var j = 1; j <= r; j++) _sumDp0[i, j] = (_sumDp0[i, j - 1] + _dp[i, j - 1, 0]) % Mod;
        
            _sumDp1[i, r] = 0;
            for (var j = r - 1; j >= l; j--) _sumDp1[i, j] = (_sumDp1[i, j + 1] + _dp[i, j + 1, 1]) % Mod;
        }

        return (int)((_sumDp0[n, r] + _sumDp1[n, l]) % Mod);
    }
}