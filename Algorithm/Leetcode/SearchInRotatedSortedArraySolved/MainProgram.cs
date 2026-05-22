namespace Leetcode.SearchInRotatedSortedArraySolved;
//  Search in Rotated Sorted Array
//  Medium
//
//  There is an integer array nums sorted in ascending order (with distinct values).
//  Prior to being passed to your function, nums is possibly left rotated at an unknown index k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed).
//      For example, [0,1,2,4,5,6,7] might be left rotated by 3 indices and become [4,5,6,7,0,1,2].
//
//  Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.
//
//  You must write an algorithm with O(log n) runtime complexity.
//
//  Example 1:
//  Input: nums = [4,5,6,7,0,1,2], target = 0
//  Output: 4
//
//  Example 2:
//  Input: nums = [4,5,6,7,0,1,2], target = 3
//  Output: -1
//
//  Example 3:
//  Input: nums = [1], target = 0
//  Output: -1
//
//  Constraints:
//      1 <= nums.length <= 5000
//     -10^4 <= nums[i] <= 10^4
//      All values of nums are unique.
//      nums is an ascending array that is possibly rotated.
//      -10^4 <= target <= 10^4

//  first   last    mid
//  0       0       0
//  0       1       0
//  0       2       1
//
//  nums = 4,5,6,7,0,1,2, target = 0

//  first = 0 last = n -1
//  mid = (first + last) / 2
//  
//  if target <= nums[n-1]
//      if mid > nums[n-1]
//          first = mid + 1
//      else
//          if mid < target
//              first = mid + 1
//          if mid > target
//              last = mid - 1
//          else
//              return mid
//
//  if target >= nums[0]
//      if mid < nums[0]
//          last = mid - 1
//      else
//          if mid < target
//              first = mid + 1
//          if mid > target
//              last = mid - 1
//          else
//              return mid
//
//  else return -1

public class Solution
{
    public int Search(int[] nums, int target)
    {
        int first = 0, last = nums.Length - 1;

        while (first <= last)
        {
            var mid = (first + last) / 2;

            if (target <= nums[last])
            {
                if (nums[mid] > nums[last]) first = mid + 1;
                else
                {
                    if (nums[mid] < target) first = mid + 1;
                    else if (nums[mid] > target) last = mid - 1;
                    else return mid;
                }
                
            }
            else if (target >= nums[first])
            {
                if (nums[mid] < nums[first]) last = mid - 1;
                else
                {
                    if (nums[mid] < target) first = mid + 1;
                    else if (nums[mid] > target) last = mid - 1;
                    else return mid;
                }
            }
            else return -1;
        }

        return -1;
    }
}

public class MainProgram
{
    static void Main()
    {
        Solution sol = new Solution();
        int[] nums = [4, 5, 6, 7, 0, 1, 2];
        int target = 0;
        Console.WriteLine(sol.Search(nums, target));
        //  Output: 4

        nums = [4, 5, 6, 7, 0, 1, 2];
        target = 3;
        Console.WriteLine(sol.Search(nums, target));
        //  Output: -1

        nums = [1];
        target = 0;
        Console.WriteLine(sol.Search(nums, target));
        //  Output: -1
    }
}