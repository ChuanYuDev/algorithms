namespace Leetcode.FindKPairsWithSmallestSums;

//  Runtime Error 19 / 32 testcases passed
//  Out of memory.

//  Get all the pair and insert them into List<ValueTuple<List<int>, int>> 
//  Initialize priorityQueue with list
//  Get the first k pairs with smallest sum

//  Pseudocode
//  list = new List<ValueTuple<List<int>, int>>()
//  for i from 0 to nums1.Length - 1
//      for j from 0 to nums2.Length - 1
//          sum = nums1[i] + nums2[j]
//          list.Add(new ValueTuple([nums1[i], nums2[j]], sum))
//
//  pq = new PriorityQueue(list)
//
//  result = new List<List<int>>()
//  for (var i = 0; i <= k - 1; i++)
//      result.Add(pq.Dequeue())
//
//  return result

//  Time complexity:
//      m: nums1.Length
//      n: nums2.Length
//      Create pq: O(mn)
//      O(k * log(mn))

//  Space complexity
//      O(mn)

public class Solution2
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        var list = new List<ValueTuple<List<int>, int>>();

        for (var i = 0; i <= nums1.Length - 1; i++)
        {
            for (var j = 0; j <= nums2.Length - 1; j++)
            {
                var sum = nums1[i] + nums2[j];
                list.Add(ValueTuple.Create(new List<int>{nums1[i], nums2[j]}, sum));
            }
        }

        var pq = new PriorityQueue<List<int>, int>(list);

        var result = new List<IList<int>>();
        
        for (var i = 0; i <= k - 1; i++) result.Add(pq.Dequeue());

        return result;
    }
}