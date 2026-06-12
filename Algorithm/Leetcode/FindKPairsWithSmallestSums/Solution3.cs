namespace Leetcode.FindKPairsWithSmallestSums;

//  nums1[i], nums2[j]
//  i  j0   1   2   3   4
//  0   G   G   G   ?   ?
//  1   G   G   G   ?   ?
//  2   G   G   G   ?   ?
//  3   G   G   O   L   L
//  4   ?   ?   L   L   L
//  5   ?   ?   L   L   L
//
//  m <= i && n <= j
//  nums1[m] + nums2[n] <= nums1[i] + nums2[j]
//
//  m >= i && n >= j
//  nums1[m] + nums2[n] >= nums1[i] + nums2[j]

//  Input: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
//  Output: [[1,2],[1,4],[1,6]]

//  Case 1
//      0   1   2
//  0   1   2?  
//  1   2?
//  2           

//      0   1   2
//  0   1   3?  
//  1   2
//  2   3?      

//      0   1   2
//  0   1   3   4?
//  1   2   4?
//  2   4?      

//      0   1   2
//  0   1   3   5?
//  1   2   5?
//  2   4  

//      0   1   2
//  0   1   3   5
//  1   2   6   7?
//  2   4   7?

//      0   1   2
//  0   1   3   5
//  1   2   6   7
//  2   4   8   9

//  Case 2
//      0   1   2
//  0   1   2?  
//  1   2?
//  2           

//      0   1   2
//  0   1   2   3?  
//  1   3?
//  2           

//      0   1   2
//  0   1   2   3  
//  1   4   5?
//  2   5?       

//      0   1   2
//  0   1   2   3  
//  1   4   6   7?
//  2   5   7?   

//      0   1   2
//  0   1   2   3  
//  1   4   6   8
//  2   5   7   9   

//  pending1, pending2 are not single value
//  nums1 = [-10, -4, 0, 0, 6];
//  nums2 = [3, 5, 6, 7, 8, 100];
//  1 2:0   1   2   3   4   5
//  0   0   1   2   3   4   8?
//  1   5   6   7   8? 
//  2   8?
//  3
//  4
//  Output: [[-10,3],[-10,5],[-10,6],[-10,7],[-10,8],[-4,3],[-4,5],[-4,6],[-4,7],[0,3]]

//  If there is still pending node in row i+1 or col j+1, the candidate is no need to insert
//  The candidate is larger than pending node
//
//             4    5
//             7?   6X
//                  7?

//  pending1 = HashSet<int>{0}, pending2 = HashSet<int>{0}
//  (0, 0) is enqueue into pq
//  result = List<IList<int>>
//  while (pq.Count > 0)
//      (i, j) = pq.Dequeue()
//      result.Add(new List<int>{nums1[i], nums2[j]})
//      if (--k == 0) break
//      pending1.Remove(i)
//      pending2.Remove(j)
//      // Candidate is (i+1, j) or (i, j+1)
//      // If there is still pending node in row i+1 or col j+1, the candidate is no need to insert
//      if (!pending1.Contains(i+1) && (i+1) <= length2)
//          (i+1, j) is enqueue into pq
//          pending1.Add(i+1)
//          pending2.Add(j)
//
//      if (!pending2.Contains(j+1) && (j+1) <= length2 - 1)
//          (i, j+1) is enqueue
//          pending2.Add(j+1)
//          pending1.Add(i)

//  Time complexity
//      pq contains O(min(m,n)) at most
//      O(k * log(min(m,n))

//  Space complexity
//      O(min(m, n))

public class Solution3
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        var pending1 = new HashSet<int>{0};
        var pending2 = new HashSet<int>{0};
        var pq = new PriorityQueue<(int, int), int>();
        pq.Enqueue((0, 0), nums1[0] + nums2[0]);

        var result = new List<IList<int>>();
        while (pq.Count > 0)
        {
            var (i, j) = pq.Dequeue();
            result.Add(new List<int>{nums1[i], nums2[j]});

            if (--k == 0) break;
            pending1.Remove(i);
            pending2.Remove(j);

            int candidate1 = i + 1, candidate2 = j + 1;
            if (candidate1 <= nums1.Length - 1 && !pending1.Contains(candidate1))
            {
                pq.Enqueue((candidate1, j), nums1[candidate1] + nums2[j]);
                pending1.Add(candidate1);
                pending2.Add(j);
            }

            if (candidate2 <= nums2.Length - 1 && !pending2.Contains(candidate2))
            {
                pq.Enqueue((i, candidate2), nums1[i] + nums2[candidate2]);
                pending2.Add(candidate2);
                pending1.Add(i);
            }
        }

        return result;
    }
}