namespace Leetcode.FindKPairsWithSmallestSums;

//  Time Limit Exceeded 19 / 32 testcases passed

//  Input: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
//  Output: [[1,2],[1,4],[1,6]]

//  If the sum is equal, the order is not important 

//  Total sum is smallest, we only need to choose the smallest pair each time
//  Get all the pairs and insert them into SortedDictionary based on sum
//  If the sum is equal, add the pair to the list of the sum

//  Pseudocode
//  sd = new SortedDictionary<int, List<List<int>>>()
//  for i from 0 to nums1.Length - 1
//      for j from 0 to nums2.Length - 1
//          sum = nums1[i] + nums2[j]
//          if (sd.ContainsKey(sum)) sd[sum].Add([nums1[i], nums2[j])
//          else sd[sum] = new List<List<int>>{{nums1[i], nums2[j]}}
//
//  result = new List<IList<int>>()
//  foreach pair in sd
//      if (k >= pair.Value.Count)
//          result.AddRange(pair.Value)
//          k -= pair.Value.Count
//      else
//          result.AddRange(pair.Value.Slice(0, k))
//          break
//  return result

//  Time complexity:
//      m: nums1.Length
//      n: nums2.Length
//      mnlog(mn)

//  Space complexity
//      O(mn)

public class Solution
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        var sd = new SortedDictionary<int, List<List<int>>>();

        for (var i = 0; i <= nums1.Length - 1; i++)
        {
            for (var j = 0; j <= nums2.Length - 1; j++)
            {
                var sum = nums1[i] + nums2[j];

                if (sd.ContainsKey(sum)) sd[sum].Add([nums1[i], nums2[j]]);
                else sd[sum] = [[nums1[i], nums2[j]]];
            }
        }

        var result = new List<IList<int>>();

        foreach (var pair in sd)
        {
            if (k >= pair.Value.Count)
            {
                result.AddRange(pair.Value);
                k -= pair.Value.Count;
            }
            else
            {
                result.AddRange(pair.Value.Slice(0, k));
                break;
            }
        }

        return result;
    }
}
