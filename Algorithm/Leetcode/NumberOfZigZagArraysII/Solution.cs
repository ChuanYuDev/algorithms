namespace Leetcode.NumberOfZigZagArraysII;

//  Runtime 1522 ms, Beats 5.71%

//  dp[i+1, y, 0] = sum(dp[i,x,1]) x > y, y from l to r
//      l < x <= r
//      l+1 < x <= r
//      l+2 < x <= r
//      ...
//      r < x <= r
//
//  dp0[i+1, l]     = 0*dp1[i, l] + dp1[i, l+1]     + ... + dp1[i, r] 
//  dp0[i+1, l+1]   = 0*dp1[i, l] + 0*dp1[i, l+1]   + ... + dp1[i, r] 
//  ...
//  dp0[i+1, r]     = 0*dp1[i, l] + 0*dp1[i, l+1]   + ... + 0*dp1[i, r] 

//  dp[i+1, y, 1] = sum(dp[i,x,0]) x < y, y from l to r
//      l <= x < l
//      l <= x < l+1
//      l <= x < l+2
//      ...
//      l <= x < r
//
//  dp1[i+1, l]     = 0*dp0[i, l]   + 0*dp0[i, l+1] + ... + 0*dp0[i, r-1]   + 0*dp0[i, r] 
//  dp1[i+1, l+1]   = dp0[i, l]     + 0*dp0[i, l+1] + ... + 0*dp0[i, r-1]   + 0*dp0[i, r] 
//  ...
//  dp1[i+1, r]     = dp0[i, l]     + dp0[i, l+1]   + ... + dp0[i, r-1]     + 0*dp0[i, r] 

//  dp[1, x, 0] = dp[1, x, 1] = 1, l <= x <= r

//  result = sum(dp[n, x, 1] + dp[n, x, 0]), l <= x <= r

//  m = m^(n-1)
//  result = sum of all the elements of m 

//  Time complexity:
//      d = r - l + 1
//      Construct m: O(d^2)
//      Matrix multiply: O(d^3)
//      Matrix power: O(d^3 log n)
//      Total: O(d^3 log n)

//  Space complexity:
//      Matrix: O(d^2)
//      Total: O(d^2)

public static class Matrix
{
    
    private static int[,] Multiply(int length, int[,] a, int[,] b)
    {
        var c = new int[length, length];

        for (var i = 0; i <= length - 1; i++)
        {
            for (var j = 0; j <= length - 1; j++)
            {
                for (var k = 0; k <= length - 1; k++)
                {
                    c[i, j] = (int)(((long)a[i, k] * b[k, j] + c[i, j]) % Const.Mod);
                }
            }
        }

        return c;
    }

    public static int[,] Power(int length, int[,] m, int expo)
    {
        // y is identity matrix
        var y = new int[length, length];
        for (var i = 0; i <= length - 1; i++) y[i, i] = 1;

        while (expo > 1)
        {
            if ((expo & 1) == 1) y = Multiply(length, y, m);
            m = Multiply(length, m, m);
            expo >>= 1;
        }

        return Multiply(length, y, m);
    }
}

public class Solution
{
    public int ZigZagArrays(int n, int l, int r)
    {
        var d = r - l + 1;
        var length = 2 * d;
        var m = new int[length, length];

        for (var i = 0; i <= d - 2; i++)
        {
            for (var j = d + 1 + i; j <= length - 1; j++)
            {
                m[i, j] = 1;
                m[length - 1 - i, length - 1 - j] = 1;
            }
        }

        m = Matrix.Power(length, m, n - 1);

        var result = 0;

        for (var i = 0; i <= length - 1; i++)
        {
            for (var j = 0; j <= length - 1; j++)
            {
                result = (result + m[i, j]) % Const.Mod;
            }
        }
        
        return result;
    }
}
