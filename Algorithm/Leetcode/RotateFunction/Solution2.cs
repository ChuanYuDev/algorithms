namespace Leetcode.RotateFunction;
//  We don't even need to store diff[n]
//  Just calculate the diff and prefix sum

//  If we use linq library (nums.Sum() in this solution), the speed is slower than the plain loop 
//  Space complexity
//      O(1)

public class Solution2
{
    public int MaxRotateFunction(int[] nums)
    {
        int total = 0;
        foreach (var num in nums) total += num;
        var length = nums.Length;

        int diffInit = 0;

        for (var i = 0; i <= length - 1; i++) diffInit += i * nums[i];

        int maxValue = diffInit, value = diffInit;

        for (var k = 1; k <= length - 1; k++)
        {
            value += total - length * nums[length - k];
            maxValue = Math.Max(maxValue, value);
        }

        return maxValue;
    }
}
