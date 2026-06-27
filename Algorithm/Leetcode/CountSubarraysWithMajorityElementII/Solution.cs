namespace Leetcode.CountSubarraysWithMajorityElementII;

//  nums = [1,2,2,3], target = 2
//      [2]
//      [2]
//      [2,2]
//      [1,2,2]
//      [2,2,3]

//  n:4
//   idx:   0   1   2   3   4
//  nums:   1   2   2   3
//   arr:   -1  1   1   -1
//  pref:   0   -1  0   1   0
//  pref':  -1  0   1   0

//  i<j -> [i, j)
//  target majority [i, j] <-> sum(arr[k]) > 0, i <= k <= j

//  pref[j] = pref[j-1]+arr[j-1] = pref[i] + arr[i] + ... + arr[j-1] > pref[i]
//  0 <= i < j <= n
//  arr[i] + ... + arr[j-1] > 0
//  [i, j-1] valid

//  pref'[j] = arr[0] + ... + arr[j]
//  pref'[i] = arr[0] + ... + arr[i]
//  pref'[j] > 0 <-> [0, j]  O(n)
//  Or
//  pref'[j] > pref'[i], 0 <= i < j <= n-1 <-> pref'[j] - pref'[i] = arr[i+1 ... j] > 0 <-> [i+1, j]

public class Solution
{
    public long CountMajoritySubarrays(int[] nums, int target)
    {
        return 0;
    }
}

