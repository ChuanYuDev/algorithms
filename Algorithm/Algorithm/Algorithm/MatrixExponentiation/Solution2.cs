namespace Algorithm.Algorithm.MatrixExponentiation;

//  Dynamic programming
//  Time complexity: O(n)
//  Space complexity: O(1)

public class Solution2
{
    public int NthFibonacci(int n)
    {
        if (n == 0 || n == 1) return n;

        int a = 0, b = 1;

        for (var i = 2; i <= n - 1; i++) (a, b) = (b, a + b);

        return a + b;
    }
}