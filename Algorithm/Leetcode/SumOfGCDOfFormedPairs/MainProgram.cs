namespace Leetcode.SumOfGCDOfFormedPairs;

/*
Sum of GCD of Formed Pairs
Medium

You are given an integer array nums of length n.
Construct an array prefixGcd where for each index i:
    Let mxi = max(nums[0], nums[1], ..., nums[i]).
    prefixGcd[i] = gcd(nums[i], mxi).

After constructing prefixGcd:
    Sort prefixGcd in non-decreasing order.
    Form pairs by taking the smallest unpaired element and the largest unpaired element.
    Repeat this process until no more pairs can be formed.
    For each formed pair, compute the gcd of the two elements.
    If n is odd, the middle element in the prefixGcd array remains unpaired and should be ignored.
    
Return an integer denoting the sum of the GCD values of all formed pairs.

The term gcd(a, b) denotes the greatest common divisor of a and b.
 
Example 1:
Input: nums = [2,6,4]
Output: 2
Explanation:
    Construct prefixGcd:
    i	nums[i]	mxi	prefixGcd[i]
    0	2	    2	2
    1	6	    6	6
    2	4	    6	2
    prefixGcd = [2, 6, 2]. After sorting, it forms [2, 2, 6].

    Pair the smallest and largest elements: gcd(2, 6) = 2.
    The remaining middle element 2 is ignored.
    Thus, the sum is 2.

Example 2:
Input: nums = [3,6,2,8]
Output: 5
   Explanation:
    Construct prefixGcd:
    i	nums[i]	mxi	prefixGcd[i]
    0	3	    3	3
    1	6	    6	6
    2	2	    6	2
    3	8	    8	8
    prefixGcd = [3, 6, 2, 8].
    After sorting, it forms [2, 3, 6, 8].

    Form pairs: gcd(2, 8) = 2 and gcd(3, 6) = 3. Thus, the sum is 2 + 3 = 5.

Constraints:
    1 <= n == nums.length <= 10^5
    1 <= nums[i] <= 10^9
*/

/* Complexity
Time complexity:
    M: maximum value in nums
    Calculate mxi: O(n)
    Gcd(a,b): O(logM)
    Calculate prefixGcd: O(nlogM)
    Sort: O(nlogn)
    Get pair: O(n)
    Calculate GCD: O(nlogM)
    Total: O(nlogn + nlogM)
    
Space complexity:
    Total: O(n)
*/

public class Solution
{
    private int Gcd(int a, int b)
    {
        while (b != 0) (a, b) = (b, a % b);
        return a;
    }
    
    public long GcdSum(int[] nums)
    {
        var length = nums.Length;
        var prefixGcd = new int[length];

        prefixGcd[0] = nums[0];

        for (var i = 1; i <= length - 1; i++) prefixGcd[i] = Math.Max(prefixGcd[i - 1], nums[i]);

        for (var i = 0; i <= length - 1; i++) prefixGcd[i] = Gcd(nums[i], prefixGcd[i]);
        
        Array.Sort(prefixGcd);

        long sum = 0;
        int l = 0, r = length - 1;
        while (l < r)
        {
            sum += Gcd(prefixGcd[l], prefixGcd[r]);
            l++;
            r--;
        }

        return sum;
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        int[] nums = [2, 6, 4];
        Console.WriteLine(sol.GcdSum(nums));
        // Output: 2

        nums = [3, 6, 2, 8];
        Console.WriteLine(sol.GcdSum(nums));
        // Output: 5
    }
}