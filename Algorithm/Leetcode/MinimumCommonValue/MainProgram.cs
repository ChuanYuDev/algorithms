namespace Leetcode.MinimumCommonValue;
//  Minimum Common Value
//  Easy
//  Given two integer arrays nums1 and nums2, sorted in non-decreasing order, return the minimum integer common to both arrays.
//  If there is no common integer amongst nums1 and nums2, return -1.
//  Note that an integer is said to be common to nums1 and nums2 if both arrays have at least one occurrence of that integer.
//
//  Example 1:
//  Input: nums1 = [1,2,3], nums2 = [2,4]
//  Output: 2
//
//  Example 2:
//  Input: nums1 = [1,2,3,6], nums2 = [2,3,4,5]
//  Output: 2

//  Constraints:
//      1 <= nums1.length, nums2.length <= 105
//      1 <= nums1[i], nums2[j] <= 109
//      Both nums1 and nums2 are sorted in non-decreasing order.

//  [1,2,3,6]
//  [3,7]
//  i = 0, j = 0
//  if nums1[i] == nums2[j]
//      return nums1[i]
//  if nums1[i] > nums2[j]
//      j++
//  if nums1[i] < nums2[j]
//      i++
//
//  if i > nums1.length or j > nums2.length 
//      return -1

public class Solution
{
    public int GetCommon(int[] nums1, int[] nums2)
    {
        int length1 = nums1.Length, length2 = nums2.Length;
        int i = 0, j = 0;

        while (i < length1 && j < length2)
        {
            if (nums1[i] == nums2[j]) return nums1[i];

            if (nums1[i] > nums2[j]) j++;
            else i++;
        }

        return -1;
    }
}

public class MainProgram
{
    static void Main()
    {
        Solution sol = new Solution();

        int[] nums1 = [1, 2, 3], nums2 = [2, 4];
        Console.WriteLine(sol.GetCommon(nums1, nums2));
        //  Output: 2

        nums1 = [1, 2, 3, 6];
        nums2 = [2, 3, 4, 5];
        Console.WriteLine(sol.GetCommon(nums1, nums2));
        //  Output: 2

        nums1 = [1, 6];
        nums2 = [2, 3, 4, 5];
        Console.WriteLine(sol.GetCommon(nums1, nums2));
        //  Output: -1

        nums1 = [1, 2];
        nums2 = [2, 4];
        Console.WriteLine(sol.GetCommon(nums1, nums2));
        // Output: 2
    }
}