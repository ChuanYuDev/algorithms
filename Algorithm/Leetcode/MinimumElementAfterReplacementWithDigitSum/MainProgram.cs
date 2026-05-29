namespace Leetcode.MinimumElementAfterReplacementWithDigitSum;
//  Minimum Element After Replacement With Digit Sum
//  Easy
//  You are given an integer array nums.
//  You replace each element in nums with the sum of its digits.
//
//  Return the minimum element in nums after all replacements.
//
//  Example 1:
//  Input: nums = [10,12,13,14]
//  Output: 1
//
//  Example 2:
//  Input: nums = [1,2,3,4]
//  Output: 1
//
//  Example 3:
//  Input: nums = [999,19,199]
//  Output: 10
//
//  Constraints:
//      1 <= nums.length <= 100
//      1 <= nums[i] <= 10^4
//
//  int DigitSum(int num)
//      sum = 0
//      while (num >0)
//          sum += num % 10
//          num /= 10
//      return sum
//  
//  int MinElement(int[] nums)
//      nums.Min(DigitSum)

public class Solution
{
    private int DigitSum(int num)
    {
        var sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }

        return sum;
    }
    
    public int MinElement(int[] nums)
    {
        return nums.Min(DigitSum);
    }
}

public class MainProgram
{
    static void Main()
    {
        Solution sol = new Solution();
        int[] nums = [10, 12, 13, 14];
        Console.WriteLine(sol.MinElement(nums));
        //  Output: 1

        nums = [1, 2, 3, 4];
        Console.WriteLine(sol.MinElement(nums));
        //  Output: 1

        nums = [999, 19, 199];
        Console.WriteLine(sol.MinElement(nums));
        //  Output: 10
    }
}