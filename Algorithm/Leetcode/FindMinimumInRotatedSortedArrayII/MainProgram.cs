namespace Leetcode.FindMinimumInRotatedSortedArrayII;

//  Find Minimum in Rotated Sorted Array II
//  Hard
//  Suppose an array of length n sorted in ascending order is rotated between 1 and n times.
//  For example, the array nums = [0,1,4,4,5,6,7] might become:
//      [4,5,6,7,0,1,4] if it was rotated 4 times.
//      [0,1,4,4,5,6,7] if it was rotated 7 times.
//
//  Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].
//
//  Given the sorted rotated array nums that may contain duplicates, return the minimum element of this array.
//  You must decrease the overall operation steps as much as possible.
//
//  Example 1:
//  Input: nums = [1,3,5]
//  Output: 1
//
//  Example 2:
//  Input: nums = [2,2,2,0,1]
//  Output: 0

//  Constraints:
//      n == nums.length
//      1 <= n <= 5000
//      -5000 <= nums[i] <= 5000
//      nums is sorted and rotated between 1 and n times.

//  Follow up: This problem is similar to Find Minimum in Rotated Sorted Array, but nums may contain duplicates.
//      Would this affect the runtime complexity? How and why?

//  [2,2,2,0,1]
//  [2,2,0,1,2]
//  [2,3,3,0,2,2]

//  i<j
//  if nums[i] < nums[j], min -> [0, i] or [j+1, n-1]
//  if nums[i] > nums[j], min -> [i+1, j]
//  if nums[i] == nums[j]
//      i' = i+1
//      if nums[i] > nums[i'] < nums[j], min = nums[i+1]
//      if nums[i] < nums[i'] > nums[j], min -> ([0, i] or [i'+1, n-1]) and [i'+1, j], min -> [i'+1, j]
//      if nums[i'] == nums[j], min -> [0,i] or [j+1, n-1] 
//
//      j' = j-1
//      if nums[i] > nums[j'] < nums[j], min -> [i+1, j-1] and ([0,j'] or [j+1, n-1]), min -> [i+1, j-1]
//      if nums[i] < nums[j'] > nums[j], min = nums[j]
//      if nums[i] == nums[j'] == nums[j], min -> [0,i] or [j+1, n-1]

//  first=0, last=n-1
//  i=(first+last)/2, j=last
//  if i == j return nums[first]
//  else
//  if nums[i] < nums[j]
//      min -> [0,i]
//      last=i
//  if nums[i] > nums[j], min -> [i+1, j]
//      first = i+1
//      last = j
//  if nums[i] == nums[j]
//      j--
//      if nums[i] > nums[j], min -> [i+1, j-1]
//          first=i+1
//          last=j-1
//      if nums[i] < nums[j], min = nums[i]
//      if nums[i] == nums[j]
//          j-- until i == j, last=i
//      
//      3 cases -> last=last-1

//  first   last    i
//  0       0       0
//  0       1       0

public class Solution 
{
    public int FindMin(int[] nums)
    {
        var length = nums.Length;
        int first = 0, last = length - 1;
        while (first <= last)
        {
            var i = (first + last) / 2;
            var j = last;

            if (i == j) return nums[first];

            if (nums[i] < nums[j])
            {
                last = i;
            }
            else if (nums[i] > nums[j])
            {
                first = i + 1;
                last = j;
            }
            else
            {
                last = j - 1;
            }
        }

        return -5001;
    }
}

public class MainProgram
{
    static void Main()
    {
        Solution sol = new Solution();

        int[] nums = [1, 3, 5];
        Console.WriteLine(sol.FindMin(nums));
        //  Output: 1

        nums = [2, 2, 2, 0, 1];
        Console.WriteLine(sol.FindMin(nums));
        //  Output: 0
    }
}