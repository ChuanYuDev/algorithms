namespace Leetcode.NumberOfZigZagArraysII;

//  Runtime 775 ms, Beats 7.14%

//  Optimization
//  1. Rearranging loops to increase spatial locality of matrix multiplication
//      Refer to computer system chapter 6
public static class Matrix3
{
    
    //  a shape: l * m
    //  b shape: m * n
    //  c shape: l * n
    private static int[,] Multiply(int[,] a, int[,] b)
    {
        var l = a.GetLength(0);
        var m = a.GetLength(1);
        var n = b.GetLength(1);
        
        var c = new int[l, n];

        for (var i = 0; i <= l - 1; i++)
        {
            for (var k = 0; k <= m - 1; k++)
            {
                var r = a[i, k];
                for (var j = 0; j <= n - 1; j++)
                {
                    c[i, j] = (int)(((long)r * b[k, j] + c[i, j]) % Const.Mod);
                }
            }
        }

        return c;
    }

    public static int[,] Power(int[,] m, int[,] acc, int expo)
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
        var m = new int[length, length];

        for (var i = 0; i <= d - 2; i++)
        {
            for (var j = d + 1 + i; j <= length - 1; j++)
            {
                m[i, j] = 1;
                m[length - 1 - i, length - 1 - j] = 1;
            }
        }

        var acc = new int[length, 1];

        for (var i = 0; i <= length - 1; i++) acc[i, 0] = 1;

        acc = Matrix3.Power(m, acc, n - 1);

        var result = 0;

        for (var i = 0; i <= length - 1; i++)
        {
            result = (result + acc[i, 0]) % Const.Mod;
        }
        
        return result;
    }
}
 
