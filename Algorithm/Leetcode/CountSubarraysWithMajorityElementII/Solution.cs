namespace Leetcode.CountSubarraysWithMajorityElementII;

//  Runtime 25 ms, Beats 16.27%

//  Use coordinate compression with fenwick tree

//  nums = [1,2,2,3], target = 2
//      [2]
//      [2]
//      [2,2]
//      [1,2,2]
//      [2,2,3]

//  n:4
//  idx:    0   1   2   3
//  nums:   1   2   2   3
//  arr:    -1  1   1   -1
//  pref:   -1  0   1   0
//  target majority [i, j] <-> sum(arr[k]) > 0, i <= k <= j

//  pref[j] = arr[0] + ... + arr[j]
//  pref[i] = arr[0] + ... + arr[i]
//  pref[j] > 0 <-> [0, j]  O(n)
//  Or
//  pref[j] > pref[i], 0 <= i < j <= n-1 <-> pref[j] - pref[i] = arr[i+1 ... j] > 0 <-> [i+1, j]

//  pref[i] [-n, +n] -> + n+1 -> [1, 2n+1]

//  Time complexity: O(nlogn)
//  Space complexity: O(n)

public class Fenwick
{
    private readonly int _length;
    private readonly int[] _f;

    public Fenwick(int length)
    {
        _length = length;
        //  Fenwick tree index is 1 to length
        //  Initially, all the elements of f arrays are 0
        _f = new int[_length + 1];
    }

    public int Query(int i)
    {
        var result = 0;
        while (i > 0)
        {
            result += _f[i];
            i -= Lsb(i);
        }

        return result;
    }
    
    // Increment _f[i] by 1 each time
    public void Update(int i)
    {
        while (i <= _length)
        {
            _f[i]++;
            i += Lsb(i);
        }
    }

    private int Lsb(int i) => i & -i;
}

public class Solution
{
    public long CountMajoritySubarrays(int[] nums, int target)
    {
        var length = nums.Length;
        var prevPref = 0;
        long result = 0;

        var fenwick = new Fenwick(2 * length + 1);

        for (var i = 0; i <= length - 1; i++)
        {
            var num = (nums[i] == target) ? 1 : -1;
            
            var pref = prevPref + num;
            prevPref = pref;
            if (pref > 0) result++;

            // Adjust pref range from [-n, n] to [1, 2n+1] by add n+1 for fenwick tree
            pref += length + 1; 
            result += fenwick.Query(pref - 1);
            fenwick.Update(pref);
        }
        return result;
    }
}

