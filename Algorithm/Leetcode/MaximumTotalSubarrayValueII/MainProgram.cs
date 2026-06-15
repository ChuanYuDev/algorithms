namespace Leetcode.MaximumTotalSubarrayValueII;

//  Maximum Total Subarray Value II
//  Hard
//  You are given an integer array nums of length n and an integer k.
//  You must select exactly k distinct non-empty subarrays nums[l..r] of nums.
//  Subarrays may overlap, but the exact same subarray (same l and r) cannot be chosen more than once.
//
//  The value of a subarray nums[l..r] is defined as: max(nums[l..r]) - min(nums[l..r]).
//  The total value is the sum of the values of all chosen subarrays.
//
//  Return the maximum possible total value you can achieve.
//
//  Example 1:
//  Input: nums = [1,3,2], k = 2
//  Output: 4
//
//  Example 2:
//  Input: nums = [4,2,5,1], k = 3
//  Output: 12
//
//  Constraints:
//      1 <= n == nums.length <= 5 * 10^4
//      0 <= nums[i] <= 10^9
//      1 <= k <= min(10^5, n * (n + 1) / 2)

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution4();
        int[] nums = [1, 3, 2];
        int k = 2;
        Console.WriteLine(sol.MaxTotalValue(nums, k));
        //  Output: 4

        nums = [4, 2, 5, 1];
        k = 3;
        Console.WriteLine(sol.MaxTotalValue(nums, k));
        //  Output: 12

        nums = [11, 8];
        k = 3;
        Console.WriteLine(sol.MaxTotalValue(nums, k));
        //  Output: 3

        nums = [28, 21, 50, 32];
        k = 10;
        Console.WriteLine(sol.MaxTotalValue(nums, k));
        //  Output: 141
    }
}