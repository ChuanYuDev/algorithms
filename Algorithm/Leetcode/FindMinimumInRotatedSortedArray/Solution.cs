namespace Leetcode.FindMinimumInRotatedSortedArray;

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

