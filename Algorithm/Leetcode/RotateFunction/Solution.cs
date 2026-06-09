namespace Leetcode.RotateFunction;

//  [4,3,2,6]
//  
//  0 1 2 ... n-1
//  F(0) = 0 * nums[0] + 1 * nums[1] + 2 * nums[2] + ... + (n-1) * nums[n-1]
//
//  n-1 0 1 2 ... n-2
//  F(1) = 0 * nums[n-1] + 1 * nums[0] + 2 * nums[1] + ... + (n-1) * nums[n-2]
//  
//  n-2 n-1 0 1 2 ...n-3
//  F(2) = 0 * nums[n-2] + 1 * nums[n-1] + 2 * nums[0] + 3 * nums[1] + ... + (n-1) * nums[n-3]
//
//  F(1) - F(0) = nums[0] + nums[1] + ... + nums[n-2] - (n-1) * nums[n-1]
//  F(2) - F(1) = nums[n-1] + nums[0] + ... + nums[n-3] - (n-1) * nums[n-2]
//
//  total = nums[0] + nums[1] + ... nums[n-1] 
//  F(1) - F(0) = total - n * nums[n-1]
//  F(2) - F(1) = total - n * nums[n-2]

//  Pseudocode
//  Total
//      O(n)
//  Calculate difference array T(n)
//      O(n)
//      T(0) = F(0)
//          O(n)
//      T(1) = F(1) - F(0) = total - n * nums[n-1]
//          O(1)
//      T(2) = total - n * nums[n-2]
//      T(k) = F(k) - F(k-1) = total - n * nums[n-k]  k from 1 to n-1
//
//  Calculate prefix sum which is F(n)
//      O(n)

//  Time complexity
//      Brute-force = O(n^2)
//      Difference array + prefix sum = O(n)

//  Space complexity
//      No need to allocate space for F(n)
//      T(n) = O(n)

public class Solution
{
    public int MaxRotateFunction(int[] nums)
    {
        int total = nums.Sum();
        var length = nums.Length;

        int[] diff = new int[length];

        for (var i = 0; i <= length - 1; i++)
        {
            diff[0] += i * nums[i];
        }

        for (var k = 1; k <= length - 1; k++)
        {
            diff[k] = total - length * nums[length - k];
        }

        int maxValue = diff[0], value = diff[0];

        for (var k = 1; k <= length - 1; k++)
        {
            value += diff[k];
            maxValue = Math.Max(maxValue, value);
        }

        return maxValue;
    }
}

