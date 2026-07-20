namespace Leetcode.SortedGCDPairQueries;

/* Optimization
1. Instead of traversing nums and checking every element if it can be divided by g, we first initialize cnt to only count 1*g
    cnt[g] = cnt[g] + cnt[2g] ... + cnt[kg], kg <= max

2. The time complexity of the above formula is MlogM instead of M^2
    g = 1, M
    g = 2, M/2
    ...
    g = M, M/M
    
    running time is O(M + M/2 + ... M/M) = M O(1 + 1/2 +... 1/M) 
    Since the harmonic series complexity is O(logM), the time complexity is O(MlogM)

3. For numPairsWithGcd[g] = numPairs[g] - numPairsWithGcd[2g] ... - numPairsWithGcd[kg], kg <= max
    No need to create numPairsWithGcd and numPairs separately
    Because we use g from max to 1 in order to calculate numPairsWithGcd 

4. The time complexity of the above formula is MlogM instead of M^2
    The reason is the same as point 2
*/

/* Dry run: Count the numbers which can be divided by g, g: 1 - max
   
nums: [4,4,2,1]
g   cnt cnt2
1   1   4
2   1   3
3   0   0
4   2   2

*/

/* Complexity
Time complexity: O(logM * q + MlogM)

Space complexity: O(M)
*/

public class Solution2
{
    private int _max = 0;
    private long[] _cnt = [];

    private void GetNumPairsWithGcd(int[] nums)
    {
        _cnt = new long[_max + 1];

        foreach (var num in nums) _cnt[num]++;
        
        for (var g = 1; g <= _max; g++)
        {
            var maxK = _max / g;

            for (var k = 2; k <= maxK; k++)
            {
                _cnt[g] += _cnt[k * g];
            }
        }

        for (var g = 1; g <= _max; g++) _cnt[g] = _cnt[g] * (_cnt[g] - 1) / 2;

        for (var g = _max; g >= 1; g--)
        {
            var maxK = _max / g;

            for (var k = 2; k <= maxK; k++)
            {
                _cnt[g] -= _cnt[k * g];
            }
        }
    }

    private int Query(long query)
    {
        int left = 1, right = _max;

        while (left < right)
        {
            var mid = (left + right) / 2;

            if (_cnt[mid] < query) left = mid + 1;
            else right = mid;
        }

        return left;
    }
    
    public int[] GcdValues(int[] nums, long[] queries)
    {
        _max = 0;
        foreach (var num in nums) _max = Math.Max(_max, num);
        
        GetNumPairsWithGcd(nums);
        
        // Calculate prefix numPairsWithGcd
        for (var g = 2; g <= _max; g++) _cnt[g] += _cnt[g - 1];
        
        var qLength = queries.Length;
        var result = new int[qLength];

        for (var qI = 0; qI <= qLength - 1; qI++)
        {
            var query = queries[qI];
            query++;
            result[qI] = Query(query);
        }

        return result;
    }
}
