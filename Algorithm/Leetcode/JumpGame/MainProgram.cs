namespace Leetcode.JumpGame;
//  Jump Game
//  Medium
//  You are given an integer array nums.
//  You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.
//  Return true if you can reach the last index, or false otherwise.

//  Example 1:
//  Input: nums = [2,3,1,1,4]
//  Output: true

//  Example 2:
//  Input: nums = [3,2,1,0,4]
//  Output: false
//
//  Constraints:
//      1 <= nums.length <= 10^4
//      0 <= nums[i] <= 10^5

//  idx         0   1   2   3   4   
//              2,  3,  1,  1,  4
//  CanJump     1   0   0   0   0
//              1   1   1   0   0
//              1   1   1   1   1

//              3,  2,  1,  0,  4
//  CanJump     1   0   0   0   0
//              1   1   1   1   0
//              1   1   1   1   0
//              1   1   1   1   0

public class Solution
{
    public bool CanJump(int[] nums)
    {
        int longestJumpIndex = 0;
        var length = nums.Length;

        if (length == 1) return true;

        for (var i = 0; i < length; i++)
        {
            if (i > longestJumpIndex) break;

            var currentLongestJumpIndex = i + nums[i];

            if (currentLongestJumpIndex <= longestJumpIndex) continue;
            
            longestJumpIndex = currentLongestJumpIndex;
            if (longestJumpIndex >= length - 1) return true;
        }

        return false;
    }
}

public class MainProgram
{
    static void Main()
    {
        Solution sol = new Solution();

        int[] nums = [2, 3, 1, 1, 4];
        Console.WriteLine(sol.CanJump(nums));
        //  Output: true

        nums = [3, 2, 1, 0, 4];
        Console.WriteLine(sol.CanJump(nums));
        //  Output: false

        nums = [0];
        Console.WriteLine(sol.CanJump(nums));
        //  Output: true
    }
}