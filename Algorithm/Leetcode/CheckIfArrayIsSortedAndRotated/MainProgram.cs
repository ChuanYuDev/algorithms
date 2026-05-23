namespace Leetcode.CheckIfArrayIsSortedAndRotated;
//  Check if Array Is Sorted and Rotated
//  Easy
//
//  Given an array nums, return true if the array was originally sorted in non-decreasing order, then rotated some number of positions (including zero).
//      Otherwise, return false.
//
//  There may be duplicates in the original array.
//  Note: An array A rotated by x positions results in an array B of the same length such that B[i] == A[(i+x) % A.length] for every valid index i.
//
//  Example 1:
//  Input: nums = [3,4,5,1,2]
//  Output: true
//  
//  Example 2:
//  Input: nums = [2,1,3,4]
//  Output: false
//
//  Example 3:
//  Input: nums = [1,2,3]
//  Output: true
//
//  Constraints:
//      1 <= nums.length <= 100
//      1 <= nums[i] <= 100

//  i = 1
//  found = false
//  for(; i < length-1; i++)
//      if (nums[i-1] > nums[i])
//          found = true
//          break
//
//  if (!found), return true
//  
//  for(j = i; j < length-2; j++)
//      if (nums[j] > nums[j+1]) return false
//  
//  if (nums[length-1] <= nums[0]) return true
//  else return false


public class Solution
{
    public bool Check(int[] nums)
    {
        var i = 1;
        var found = false;
        var length = nums.Length;

        for (; i <= length - 1; i++)
        {
            if (nums[i - 1] > nums[i])
            {
                found = true;
                break;
            }
        }

        if (!found) return true;

        for (var j = i; j <= length - 2; j++)
        {
            if (nums[j] > nums[j + 1]) return false;
        }

        if (nums[length - 1] <= nums[0]) return true;
        
        return false;
    }
}

public class MainProgram
{
    static void Main()
    {
        Solution sol = new Solution();
        
        int[] nums = [3, 4, 5, 1, 2];
        Console.WriteLine(sol.Check(nums));
        //  Output: true

        nums = [2, 1, 3, 4];
        Console.WriteLine(sol.Check(nums));
        //  Output: false

        nums = [1, 2, 3];
        Console.WriteLine(sol.Check(nums));
        //  Output: true

        nums = [5, 1, 5, 1];
        Console.WriteLine(sol.Check(nums));
        //  Output: false
    }
}