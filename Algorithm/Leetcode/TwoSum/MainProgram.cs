using Helper;

namespace Leetcode.TwoSum;

// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
//
// You may assume that each input would have exactly one solution, and you may not use the same element twice.
//
// You can return the answer in any order.

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];

            if (map.ContainsKey(complement))
            {
                return [map[complement], i];
            }

            map[nums[i]] = i;
        }

        return [];
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        int[] nums = [2, 7, 11, 15];
        var target = 9;
        
        PrintHelper.PrintEnumerable(sol.TwoSum(nums, target));
        // Output: [0,1]
        
        nums = [3,2,4];
        target = 6;
        
        PrintHelper.PrintEnumerable(sol.TwoSum(nums, target));
        // Output: [1,2]
        
        nums = [3,3];
        target = 6;
        
        PrintHelper.PrintEnumerable(sol.TwoSum(nums, target));
        // Output: [0,1]
    }
}