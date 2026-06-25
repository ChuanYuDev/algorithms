namespace Algorithm.Algorithm.MatrixExponentiation;

public static class MatrixExponentiation
{
    // Multiply two 2x2 Matrices
    public static int[,] Multiply(int[,] a, int[,] b)
    {
        // Matrix to store the result
        var c = new int[2, 2];

        // Matrix Multiply
        c[0, 0] = a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0];
        c[0, 1] = a[0, 0] * b[0, 1] + a[0, 1] * b[1, 1];
        c[1, 0] = a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0];
        c[1, 1] = a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1];

        return c;
    }

    // Matrix m ^ expo
    public static int[,] Power(int[,] m, int expo)
    {
        // Initialize result with identity matrix
        int[,] y = {{1, 0}, {0,1}};

        // Fast Exponentiation
        while (expo > 1)
        {
            if ((expo & 1) > 0)
                y = Multiply(y, m);
            m = Multiply(m, m);
            expo >>= 1;
        }
        
        return Multiply(y, m);
    }
}

public class Solution
{
    public int NthFibonacci(int n)
    {
        if (n == 0 || n == 1) return n;

        int[,] m = { { 1, 1 }, { 1, 0 } };

        // Make f [1, 0] as 2 * 2 for Multiply function 
        int[,] f = { { 1, 0 }, { 0, 0 } };
        
        // Multiply matrix m (n - 1) times
        var mPow = MatrixExponentiation.Power(m, n - 1);
        
        var fPrime = MatrixExponentiation.Multiply(mPow, f);

        return fPrime[0, 0];
    }
}
