namespace Leetcode.MaximumTotalSubarrayValueII;

//  Runtime Error 305 / 930 testcases passed
//  Out of memory.

//  Input: nums = [1,3,2], k = 2
//  l r max min value
//  0 0   1   1     0
//  0 1   3   1     2
//  0 2   3   1     2
//  1 1   3   3     0
//  1 2   3   2     1
//  2 2   2   2     0

//  Get all the values
//      O(n^2)
//
//  Sort from largest to smallest
//      O(n^2logn)
//
//  Get first k
//      O(n^2)
//
//  Time complexity: O(n^2logn) 
//  Space complexity: O(n^2)

public class Solution
{
    public long MaxTotalValue(int[] nums, int k)
    {
        var length = nums.Length;
        var values = new List<int>();
        
        for (var l = 0; l <= length - 1; l++)
        {
            var min = nums[l];
            var max = nums[l];
            
            for (var r = l; r <= length - 1; r++)
            {
                min = Math.Min(min, nums[r]);
                max = Math.Max(max, nums[r]);
                values.Add(max - min);
            }
        }
        
        values.Sort((x, y) => -x.CompareTo(y));

        long total = 0;
        for (var i = 0; i <= k - 1; i++)
        {
            total += values[i];
        }

        return total;
    }
}
