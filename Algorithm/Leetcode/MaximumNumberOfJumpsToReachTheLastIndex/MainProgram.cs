namespace Leetcode.MaximumNumberOfJumpsToReachTheLastIndex;

//  You are given a 0-indexed array nums of n integers and an integer target.
//
//  You are initially positioned at index 0. In one step, you can jump from index i to any index j such that:
//      0 <= i < j < n
//      -target <= nums[j] - nums[i] <= target
//  Return the maximum number of jumps you can make to reach index n - 1.
//  If there is no way to reach index n - 1, return -1.

//  Constraints:
//      2 <= nums.length == n <= 1000
//      -10^9 <= nums[i] <= 10^9
//      0 <= target <= 2 * 10^9

//  Input: nums = [1,3,6,4,1,2], target = 2
//  Output: 3

//  i       0 1 2 3 4 5
//  nums    1,3,6,4,1,2
//  jump1   0 1 0 0 1 1
//  jump2   0 1 0 2 2 2
//  jump3   0 1 0 2 2 3

//  nums[i] - target <= nums[j] <= nums[i] + target

//  i: 0 -> nums[i] = 1 -> [-1, 3]
//  j: 1, 4, 5

//  i: 1 -> nums[i] = 3 -> [1, 5]
//  j: 3, 4, 5

//  i: 3 -> nums[i] = 4 -> [2, 6]
//  j: 5

//  i: 4 -> nums[i] = 1 -> [-1, 3]
//  j: 5

//  nums = [1, 3, 4, 0, 2]; target = 2;
//  Output: 3
//  i       0 1 2 3 4
//  nums    1,3,4,0,2
//  jump1   0 1 0 1 1   [-1, 3]
//  jump2   0 1 2 1 2   [1, 5]
//  jump3   0 1 2 1 3   [2, 6]
//  jump4   0 1 2 1 3   [-2, 2]

public class Solution
{
    public int MaximumJumps(int[] nums, int target)
    {
        var length = nums.Length;
        uint t = (uint)target;
        
        int[] jump = new int[length];

        for (var i = 0; i < length; i++)
        {
            if (i != 0 && jump[i] == 0)
            {
                continue;
            }
            
            for (var j = i + 1; j < length; j++)
            {
                if (nums[j] <= nums[i] + t && nums[j] >= nums[i] - t)
                {
                    jump[j] = Math.Max(jump[i] + 1, jump[j]);
                }
            }
        }

        return jump[length - 1] == 0 ? -1 : jump[length - 1];
    }
}

public class MainProgram
{
    static void Main()
    {
        Solution sol = new Solution();
        
        int[] nums = [1, 3, 6, 4, 1, 2];
        var target = 2;
        Console.WriteLine(sol.MaximumJumps(nums, target));
        //  Output: 3

        nums = [1, 3, 6, 4, 1, 2];
        target = 3;
        Console.WriteLine(sol.MaximumJumps(nums, target));
        //  Output: 5

        nums = [1, 3, 6, 4, 1, 2];
        target = 0;
        Console.WriteLine(sol.MaximumJumps(nums, target));
        //  Output: -1

        nums = [1, 3, 4, 0, 2];
        target = 2;
        Console.WriteLine(sol.MaximumJumps(nums, target));
        //  Output: 3

        nums = [758043978, 79060681, 785252849, 287889790, -983845055, 224430896, -477101480];
        target = 1769097904;
        Console.WriteLine(sol.MaximumJumps(nums, target));
        //  Output: 6
    }
}