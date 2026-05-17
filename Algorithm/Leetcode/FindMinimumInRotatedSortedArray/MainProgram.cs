namespace Leetcode.FindMinimumInRotatedSortedArray;

//  Find Minimum in Rotated Sorted Array
//  Medium
//  Suppose an array of length n sorted in ascending order is rotated between 1 and n times.
//  For example, the array nums = [0,1,2,4,5,6,7] might become:
//      [4,5,6,7,0,1,2] if it was rotated 4 times.
//      [0,1,2,4,5,6,7] if it was rotated 7 times.
//
//  Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].
//  Given the sorted rotated array nums of unique elements, return the minimum element of this array.
//  You must write an algorithm that runs in O(log n) time.
//
//  Constraints:
//      n == nums.length
//      1 <= n <= 5000
//      -5000 <= nums[i] <= 5000
//      All the integers of nums are unique.
//      nums is sorted and rotated between 1 and n times.

//  [4,5,6,7,0,1,2]
//  [7,0,1,2,4,5,6]
//  a < b < c
//  6 < 7 > 0
//  7 > 0 < 1

//  i < j
//      if nums[i] < nums[j], i,j in same region, min -> [0, i] or (j, n-1] -> [0, i] or [j+1, n-1]
//      if nums[i] > nums[j], min -> (i, j] -> [i+1, j]

//  first = 0, last = n - 1
//      i = first, j= (first + last) / 2
//      if i == j, return min(nums[first], nums[last]);
//      else
//      if nums[i] < nums[j]
//          if nums[i] < nums[n - 1], min = nums[i]
//          else
//          min -> [j+1, n -1]
//          first = j+1
//      if nums[i] > nums[j], min -> [i+1, j]
//          first = i+1
//          last = j

public class Solution
{
    public int FindMin(int[] nums)
    {
        var length = nums.Length;
        int first = 0, last = length - 1;

        while (first <= last)
        {
            int i = first, j = (first + last) / 2;

            if (i == j)
            {
                return Math.Min(nums[first], nums[last]);
            }

            if (nums[i] < nums[j])
            {
                if (nums[i] < nums[length - 1])
                {
                    return nums[i];
                }

                first = j + 1;
            }
            else
            {
                first = i + 1;
                last = j;
            }
        }

        return -5001;
    }
}

public class MainProgram
{
    static void Main()
    {
        Solution sol = new();
        
        int[] nums = [3, 4, 5, 1, 2];
        Console.WriteLine(sol.FindMin(nums));
        // Output: 1

        nums = [4, 5, 6, 7, 0, 1, 2];
        Console.WriteLine(sol.FindMin(nums));
        // Output: 0
        
        nums = [11, 13, 15, 17];
        Console.WriteLine(sol.FindMin(nums));
        // Output: 11
    }


    
}