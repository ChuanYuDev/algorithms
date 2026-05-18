namespace Leetcode.FindMinimumInRotatedSortedArray;

//  i < j
//      if nums[i] < nums[j], i,j in same region, min -> [0, i] or (j, n-1] -> [0, i] or [j+1, n-1]
//      if nums[i] > nums[j], min -> (i, j] -> [i+1, j]

//  Because if nums[i] < nums[j], min -> [0, i] or [j+1, n-1]
//  There are two cases, we can choose j = last, i = (first+last)/2 to exclude [j+1, n-1]

//  first = 0, last = n - 1
//      i = (first + last) / 2, j = last
//      if i == j, return nums[first]
//      else
//      if nums[i] < nums[j]
//          min -> [0, i]
//          last = i
//      if nums[i] > nums[j], min -> [i+1, j]
//          first = i+1
//          last = j

public class Solution2
{
    public int FindMin(int[] nums)
    {
        var length = nums.Length;
        int first = 0, last = length - 1;

        while (first <= last)
        {
            int i = (first + last) / 2, j = last;

            if (i == j)
            {
                return nums[first];
            }

            if (nums[i] < nums[j])
            {
                last = i;
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