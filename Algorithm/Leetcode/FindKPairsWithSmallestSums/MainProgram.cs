using Helper;

namespace Leetcode.FindKPairsWithSmallestSums;

//  Find K Pairs with Smallest Sums
//  Medium
//
//  You are given two integer arrays nums1 and nums2 sorted in non-decreasing order and an integer k.
//  Define a pair (u, v) which consists of one element from the first array and one element from the second array.
//
//  Return the k pairs (u1, v1), (u2, v2), ..., (uk, vk) with the smallest sums.
//
//  Example 1:
//  Input: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
//  Output: [[1,2],[1,4],[1,6]]
//
//  Example 2:
//  Input: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
//  Output: [[1,1],[1,1]]
//
//  Constraints:
//      1 <= nums1.length, nums2.length <= 10^5
//     -10^9 <= nums1[i], nums2[i] <= 10^9
//      nums1 and nums2 both are sorted in non-decreasing order.
//      1 <= k <= 10^4
//      k <= nums1.length * nums2.length

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution3();
        int[] nums1 = [1, 7, 11], nums2 = [2, 4, 6];
        int k = 3;
        PrintHelper.Print2DList(sol.KSmallestPairs(nums1, nums2, k));
        //  Output: [[1,2],[1,4],[1,6]]

        nums1 = [1, 1, 2];
        nums2 = [1, 2, 3];
        k = 2;
        PrintHelper.Print2DList(sol.KSmallestPairs(nums1, nums2, k));
        //  Output: [[1,1],[1,1]]

        nums1 = [-10, -4, 0, 0, 6];
        nums2 = [3, 5, 6, 7, 8, 100];
        k = 10;
        PrintHelper.Print2DList(sol.KSmallestPairs(nums1, nums2, k));
        //  Output: [[-10,3],[-10,5],[-10,6],[-10,7],[-10,8],[-4,3],[-4,5],[-4,6],[-4,7],[0,3]]

        nums1 = [1, 2, 4, 5, 6];
        nums2 = [3, 5, 7, 9];
        k = 20;
        PrintHelper.Print2DList(sol.KSmallestPairs(nums1, nums2, k));

        //  Output: [[1,3],[2,3],[1,5],[2,5],[4,3],[1,7],[5,3],[2,7],[4,5],[6,3],[1,9],[5,5],[2,9],[4,7],[6,5],[5,7],[4,9],[6,7],[5,9],[6,9]]
    }
}