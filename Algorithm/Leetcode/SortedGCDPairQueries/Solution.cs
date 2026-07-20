namespace Leetcode.SortedGCDPairQueries;

/* Time Limit Exceeded
713 / 721 testcases passed
*/

/* Get the number of pairs that have a GCD of g, 
gcd = g
numPairsWithGcd[g]
max = max(nums)
   
M: max(nums)
Count the numbers which can be divided by g, g: 1 - max
    cnt[g]
    O(nM)

Choose two to get the pairs that have a GCD of kg, k = 1, 2, ..., 
    numPairs[g] = cnt[g] * (cnt[g] - 1) / 2
    O(M)
       
Use inclusion-exclusion
    numPairsWithGcd[g] = numPairs[g] - numPairsWithGcd[2g] ... - numPairsWithGcd[kg], kg <= max
    O(M^2)
*/

/* Dry run
nums: [4,4,2,1]
sorted gcdPairs: [1, 1, 1, 2, 2, 4]
max = 4
g   cnt numPairs    numsPairsWithGcd
1   4   6           3
2   3   3           2
3   0   0           0
4   2   1           1
*/

/* Prefix + binary search
Input: nums = [4,4,2,1], queries = [5,3,1,0]
Output: [4,2,1,1]

Sorted gcdPairs: [1, 1, 1, 2, 2, 4]
numPairsWithGcd: [0, 3, 2, 0, 1]
    1: 3, 2: 2, 3: 0, 4: 1
Prefix numPairsWithGcd: [0, 3, 5, 5, 6], O(M)
Every query: O(logM)
Total: O(logM * q)

Subtraction:
    Every query: O(M)
    Total: O(Mq)
*/

/* Dry run
numPairsWithGcd: [0, 3, 5, 5, 6]
query = 5
left    right   mid
1       4       2
1       2       1
2       2       
*/

/* Complexity
Time complexity: O(logM * q + nM + M^2)
Space complexity: O(M)
*/

public class Solution
{
    private int _max = 0;
    private long[] _numPairsWithGcd = [];

    private void GetNumPairsWithGcd(int[] nums)
    {
        var cnt = new int[_max + 1];

        for (var g = 1; g <= _max; g++)
        {
            foreach (var num in nums) if (num % g == 0) cnt[g]++;
        }

        for (var g = 1; g <= _max; g++) cnt[g] = cnt[g] * (cnt[g] - 1) / 2;

        _numPairsWithGcd = [..cnt];

        for (var g = _max; g >= 1; g--)
        {
            var maxK = _max / g;

            for (var k = 2; k <= maxK; k++)
            {
                _numPairsWithGcd[g] -= _numPairsWithGcd[k * g];
            }
        }
    }

    private int Query(long query)
    {
        int left = 1, right = _max;

        while (left < right)
        {
            var mid = (left + right) / 2;

            if (_numPairsWithGcd[mid] < query) left = mid + 1;
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
        for (var g = 2; g <= _max; g++) _numPairsWithGcd[g] += _numPairsWithGcd[g - 1];
        
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
