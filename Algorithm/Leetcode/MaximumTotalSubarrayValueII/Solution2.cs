namespace Leetcode.MaximumTotalSubarrayValueII;

//  Time Limit Exceeded 304 / 930 testcases passed

//  We don't need to store all the values, we only need to store the value as the key, its occurrence and sort them based on the value

//  Input: nums = [1,3,2], k = 2
//  l r max min value
//  0 0   1   1     0
//  0 1   3   1     2
//  0 2   3   1     2
//  1 1   3   3     0
//  1 2   3   2     1
//  2 2   2   2     0

//  0: 3
//  2: 2
//  1: 1

//  Get value
//  Insert it into SortedDictionary
//  Get the largest first k

//  Pseudocode
//
//  SortedDictionary<int, int> sd = new SortedDictionary<int, int>(comparer)
//  for l from 0 to length-1
//      max = nums[l]
//      min = nums[l]
//      for r from l to length-1
//          max = Max(max, nums[r])
//          min = Min(min, nums[r])
//          value = max - min
//          if (sd.Contains(value)) sd[value]++
//          else sd[value] = 1
//
//  long totalValue = 0
//  foreach pair in sd
//      if (pair.Value <= k)
//          totalValue += (long)pair.Key * pair.Value
//          k -= pair.Value
//      else
//          totalValue += (long)pair.Key * k
//          break
//  return totalValue
//
//  Time complexity: O(n^2logn) 
//  Space complexity: O(max - min)

public class CustomComparer2 : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return -x.CompareTo(y);
    }
}

public class Solution2
{
    public long MaxTotalValue(int[] nums, int k)
    {
        var sd = new SortedDictionary<int, int>(new CustomComparer2());
        var length = nums.Length;

        for (var l = 0; l <= length - 1; l++)
        {
            var max = nums[l];
            var min = nums[l];

            for (var r = l; r <= length - 1; r++)
            {
                max = Math.Max(max, nums[r]);
                min = Math.Min(min, nums[r]);
                var value = max - min;
                if (sd.ContainsKey(value)) sd[value]++;
                else sd[value] = 1;
            }
        }

        long totalValue = 0;

        foreach (var pair in sd)
        {
            if (pair.Value <= k)
            {
                totalValue += (long)pair.Key * pair.Value;
                k -= pair.Value;
            }
            else
            {
                totalValue += (long)pair.Key * k;
                break;
            }
        }

        return totalValue;
    }
}