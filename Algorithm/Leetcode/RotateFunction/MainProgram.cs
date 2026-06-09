namespace Leetcode.RotateFunction;

//  Rotate Function
//  Medium
//  You are given an integer array nums of length n.
//  Assume arrk to be an array obtained by rotating nums by k positions clock-wise.
//  We define the rotation function F on nums as follow:
//      F(k) = 0 * arrk[0] + 1 * arrk[1] + ... + (n - 1) * arrk[n - 1].
//
//  Return the maximum value of F(0), F(1), ..., F(n-1).
//  The test cases are generated so that the answer fits in a 32-bit integer.
//
//  Example 1:
//  Input: nums = [4,3,2,6]
//  Output: 26
//
//  Example 2:
//  Input: nums = [100]
//  Output: 0
//
//  Constraints:
//      n == nums.length
//      1 <= n <= 10^5
//      -100 <= nums[i] <= 100

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution2();
        int[] nums = [4, 3, 2, 6];
        Console.WriteLine(sol.MaxRotateFunction(nums));
        //  Output: 26

        nums = [100];
        Console.WriteLine(sol.MaxRotateFunction(nums));
        //  Output: 0
    }
}