namespace Leetcode.GCDOfOddAndEvenSums;

/*
GCD of Odd and Even Sums
Easy

You are given an integer n.
    Your task is to compute the GCD (greatest common divisor) of two values:

sumOdd: the sum of the smallest n positive odd numbers.
sumEven: the sum of the smallest n positive even numbers.

Return the GCD of sumOdd and sumEven.

Example 1:
Input: n = 4
Output: 4
Explanation:
    Sum of the first 4 odd numbers sumOdd = 1 + 3 + 5 + 7 = 16
    Sum of the first 4 even numbers sumEven = 2 + 4 + 6 + 8 = 20
    Hence, GCD(sumOdd, sumEven) = GCD(16, 20) = 4.

Example 2:
Input: n = 5
Output: 5
Explanation:
    Sum of the first 5 odd numbers sumOdd = 1 + 3 + 5 + 7 + 9 = 25
    Sum of the first 5 even numbers sumEven = 2 + 4 + 6 + 8 + 10 = 30
    Hence, GCD(sumOdd, sumEven) = GCD(25, 30) = 5.

Constraints:
    1 <= n <= 1000
*/

/* Math
Odd
    2i + 1, i from 0 to n-1
    2sum(i) + n = 2 * (n-1)n/2 + n = n^2

Even
    2i, i from 1 to n
    2sum(i) = 2* (n+1)n/2 = n^2 + n

GCD(a, b) = GCD(a, b % a)
GCD(n^2, n^2+n) = GCD(n^2, n) = GCD(n^2 % n, n) = n
*/

/* Complexity
Time complexity: O(1)
Space complexity: O(1)
*/

public class Solution
{
    public int GcdOfOddEvenSums(int n)
    {
        return n;
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();

        var n = 4;
        Console.WriteLine(sol.GcdOfOddEvenSums(n));
        // Output: 4
        
        n = 5;
        Console.WriteLine(sol.GcdOfOddEvenSums(n));
        // Output: 5
    }
}