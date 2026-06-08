using Helper;

namespace Leetcode.PartitionArrayAccordingToGivenPivot;
//  Partition Array According to Given Pivot
//  Medium
//  You are given a 0-indexed integer array nums and an integer pivot
//
//  Rearrange nums such that the following conditions are satisfied:
//      Every element less than pivot appears before every element greater than pivot.
//      Every element equal to pivot appears in between the elements less than and greater than pivot.
//      The relative order of the elements less than pivot and the elements greater than pivot is maintained.
//          More formally, consider every pi, pj where pi is the new position of the ith element and pj is the new position of the jth element.
//          If i < j and both elements are smaller (or larger) than pivot, then pi < pj.
//
//  Return nums after the rearrangement.
//
//  Example 1:
//      Input: nums = [9,12,5,10,14,3,10], pivot = 10
//      Output: [9,5,3,10,10,12,14]
//
//  Example 2:
//      Input: nums = [-3,4,3,2], pivot = 2
//      Output: [-3,2,4,3]
//
//  Constraints:
//      1 <= nums.length <= 10^5
//      -10^6 <= nums[i] <= 10^6
//      pivot equals to an element of nums.

//  Pseudocode
//  lessThan, equal, greaterThan
//  foreach num in nums
//      if (num < pivot) lessThan.Add(num)
//      else if (num == pivot) equal.Add(num)
//      else greaterThan.Add(num)
//  lessThan.AddRange(equal)
//  lessThan.AddRange(greaterThan)
//  return lessThan.ToArray()

//  Time complexity
//      O(n)
//  Space complexity
//      O(n)

public class Solution
{
    public int[] PivotArray(int[] nums, int pivot)
    {
        List<int> lessThan = [], equal = [], greaterThan = [];

        foreach (var num in nums)
        {
            if (num < pivot) lessThan.Add(num);
            else if (num == pivot) equal.Add(num);
            else greaterThan.Add(num);
        }
        
        lessThan.AddRange(equal);
        lessThan.AddRange(greaterThan);

        return lessThan.ToArray();
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        int[] nums = [9, 12, 5, 10, 14, 3, 10];
        int pivot = 10;
        PrintHelper.PrintEnumerable(sol.PivotArray(nums, pivot));
        // Output: [9,5,3,10,10,12,14]

        nums = [-3, 4, 3, 2];
        pivot = 2;
        PrintHelper.PrintEnumerable(sol.PivotArray(nums, pivot));
        // Output: [-3,2,4,3]
    }
}