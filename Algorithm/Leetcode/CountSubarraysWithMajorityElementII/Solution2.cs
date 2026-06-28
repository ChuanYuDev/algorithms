namespace Leetcode.CountSubarraysWithMajorityElementII;

//  idx:    0   1   2   3
//  nums:   1   2   2   3
//  nums':  -1  1   1   -1
//  pref:   -1  0   1   0

//  pref[j] > 0 <-> [0, j]  O(n)
//  1

//  pref[j] > pref[i], 0 <= i < j <= n-1 <-> pref[j] - pref[i] = nums'[i+1 ... j] > 0 <-> [i+1, j]
//  Occurrence of pref
//  val:    -4  -3  -2  -1  0   1   2   3   4
//  occIdx: 0   1   2   3   4   5   6   7   8
//  occ:                1   2   1
//  0 + 1 + 2 + 1 = 4

//  Since nums' is either 1 or -1, pref is either increased by 1 or decreased by 1 each time
//  This means each time the query boundary (occIdx) is shrunk or expanded by 1
//  Initially, occPref = 0, occIdx = n

//  Pseudocode 
//  if (nums' == -1)
//      occIdx--
//      occPref -= occ[occIdx] 
//  if (nums' == 1)
//      occPref += occ[occIdx]
//      occIdx++
//  
//  occ[occIdx]++

//  Time complexity:
//      Every time, we can get occPref in O(1) runtime
//      Total: O(n)

//  Space complexity:
//      occ: O(n)
//      Total: O(n)

public class Solution2
{
    public long CountMajoritySubarrays(int[] nums, int target)
    {
        var length = nums.Length;
        
        var occ = new int[2 * length + 1];
        var occIdx = length;
        long result = 0, occPref = 0;
        
        for (var i = 0; i <= length - 1; i++)
        {
            var num = (nums[i] == target) ? 1 : -1;

            if (num == -1)
            {
                occIdx--;
                occPref -= occ[occIdx];
            }
            else
            {
                occPref += occ[occIdx];
                occIdx++;
            }

            result += occPref;
            occ[occIdx]++;

            var pref = occIdx - length;
            if (pref > 0) result++;
        }
        
        return result;
    }
}