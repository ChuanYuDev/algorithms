using Helper;

namespace Leetcode.FindThePrefixCommonArrayOfTwoArrays;
//  Find the Prefix Common Array of Two Arrays
//  Medium
//  You are given two 0-indexed integer permutations A and B of length n.
//  A prefix common array of A and B is an array C such that C[i] is equal to the count of numbers that are present at or before the index i in both A and B.
//
//  Return the prefix common array of A and B.

//  A sequence of n integers is called a permutation if it contains all integers from 1 to n exactly once.
//
//  Example 1:
//  Input: A = [1,3,2,4], B = [3,1,2,4]
//  Output: [0,2,3,4]
//
//  Example 2:
//  Input: A = [2,3,1], B = [3,1,2]
//  Output: [0,1,3]
//
//  Constraints:
//      1 <= A.length == B.length == n <= 50
//      1 <= A[i], B[i] <= n
//      It is guaranteed that A and B are both a permutation of n integers.

//  c[0] = a[0] == b[0]?1:0
//
//  i >= 1
//  c[i] = c[i-1]
//
//  if a[i] == b[i]
//      c[i] = c[i] + 1
//  else
//      if bMap.ContainsKey(a[i])
//          c[i] = c[i] + 1
//      if aMap.ContainsKey(b[i])
//          c[i] = c[i] + 1
//
//  aMap[a[i]] = 1
//  bMap[b[i]] = 1

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution2();

        int[] a = [1, 3, 2, 4], b = [3, 1, 2, 4];
        PrintHelper.PrintArray(sol.FindThePrefixCommonArray(a, b));
        //  Output: [0,2,3,4]

        a = [2, 3, 1];
        b = [3, 1, 2];
        PrintHelper.PrintArray(sol.FindThePrefixCommonArray(a, b));
        //  Output: [0,1,3]
    }
    
}