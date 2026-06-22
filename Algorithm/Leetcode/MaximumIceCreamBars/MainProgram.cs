namespace Leetcode.MaximumIceCreamBars;
//  Maximum Ice Cream Bars
//  Medium
//  It is a sweltering summer day, and a boy wants to buy some ice cream bars.
//  At the store, there are n ice cream bars.
//      You are given an array costs of length n, where costs[i] is the price of the ith ice cream bar in coins.
//      The boy initially has coins coins to spend, and he wants to buy as many ice cream bars as possible. 
//      Note: The boy can buy the ice cream bars in any order.
//
//  Return the maximum number of ice cream bars the boy can buy with coins coins.
//
//  You must solve the problem by counting sort.
//
//  Example 1:
//  Input: costs = [1,3,2,4,1], coins = 7
//  Output: 4
//
//  Example 2:
//  Input: costs = [10,6,8,7,7,8], coins = 5
//  Output: 0
//
//  Example 3:
//  Input: costs = [1,6,3,1,2,5], coins = 20
//  Output: 6
//
//  Constraints:
//      costs.length == n
//      1 <= n <= 10^5
//      1 <= costs[i] <= 10^5
//      1 <= coins <= 10^8

//  Counting sort
//  n: number of costs
//  m: max(costs)
//  Time complexity: O(n + m)
//  Space complexity: O(n + m)

public class Solution
{
    private int[] CoutingSort(int[] nums)
    {
        var max = 0;
        foreach (var num in nums)
        {
            max = Math.Max(max, num);
        }

        var cntNums = new int[max + 1];

        foreach (var num in nums)
        {
            cntNums[num]++;
        }

        for (var i = 1; i <= cntNums.Length - 1; i++)
        {
            cntNums[i] += cntNums[i - 1];
        }

        var numsLength = nums.Length;
        var result = new int[numsLength];

        for (var i = numsLength - 1; i >= 0; i--)
        {
            var val = nums[i];
            result[cntNums[val] - 1] = val;
            cntNums[val]--;
        }

        return result;
    }
    
    public int MaxIceCream(int[] costs, int coins)
    {
        var sortedCosts = CoutingSort(costs);

        var iceCreamNum = 0;

        foreach (var cost in sortedCosts)
        {
            if (cost <= coins)
            {
                coins -= cost;
                iceCreamNum++;
            }
        }

        return iceCreamNum;
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        int[] costs = [1, 3, 2, 4, 1];
        int coins = 7;
        Console.WriteLine(sol.MaxIceCream(costs, coins));
        //  Output: 4

        costs = [10, 6, 8, 7, 7, 8];
        coins = 5;
        Console.WriteLine(sol.MaxIceCream(costs, coins));
        //  Output: 0

        costs = [1, 6, 3, 1, 2, 5];
        coins = 20;
        Console.WriteLine(sol.MaxIceCream(costs, coins));
        //  Output: 6
    }
}