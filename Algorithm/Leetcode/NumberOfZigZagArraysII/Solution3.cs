namespace Leetcode.NumberOfZigZagArraysII;

//  Runtime 347 ms, Beats 43.57%

//  Optimization
//  1. Rearranging loops to increase spatial locality of matrix multiplication
//      Refer to computer system chapter 6
//      Runtime 775 ms, Beats 7.14%
//
//  2. If a[i,k] = 0, skip loop
//      Runtime 347 ms, Beats 43.57%
//
//  3. Define the matrix as long[,], Mod as long and initialized value as 1L
//      We still modulo Mod to make sure their values are with int
//      But we can save the conversion from long to int
//      Runtime 341 ms, Beats 43.57%

public class Const3
{
    public const long Mod = 1_000_000_007;
}

public static class Matrix3
{
    
    //  a shape: l * m
    //  b shape: m * n
    //  c shape: l * n
    private static long[,] Multiply(long[,] a, long[,] b)
    {
        var l = a.GetLength(0);
        var m = a.GetLength(1);
        var n = b.GetLength(1);
        
        var c = new long[l, n];

        for (var i = 0; i <= l - 1; i++)
        {
            for (var k = 0; k <= m - 1; k++)
            {
                var r = a[i, k];
                if (r == 0) continue;
                
                for (var j = 0; j <= n - 1; j++)
                {
                    c[i, j] = (r * b[k, j] + c[i, j]) % Const3.Mod;
                }
            }
        }

        return c;
    }

    public static long[,] Power(long[,] m, long[,] acc, int expo)
    {
        while (expo > 1)
        {
            if ((expo & 1) == 1) acc = Multiply(m, acc);
            m = Multiply(m, m);
            expo >>= 1;
        }

        return Multiply(m, acc);
    }
}

public class Solution3
{
    public int ZigZagArrays(int n, int l, int r)
    {
        var d = r - l + 1;
        var length = 2 * d;
        var m = new long[length, length];

        for (var i = 0; i <= d - 2; i++)
        {
            for (var j = d + 1 + i; j <= length - 1; j++)
            {
                m[i, j] = 1L;
                m[length - 1 - i, length - 1 - j] = 1L;
            }
        }

        var acc = new long[length, 1];

        for (var i = 0; i <= length - 1; i++) acc[i, 0] = 1L;

        acc = Matrix3.Power(m, acc, n - 1);

        var result = 0L;

        for (var i = 0; i <= length - 1; i++)
        {
            result = (result + acc[i, 0]) % Const3.Mod;
        }
        
        return (int)result;
    }
}
 
