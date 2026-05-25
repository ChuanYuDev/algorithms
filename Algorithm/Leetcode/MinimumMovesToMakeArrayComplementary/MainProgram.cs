namespace Leetcode.MinimumMovesToMakeArrayComplementary;

//  Minimum Moves to Make Array Complementary
//  Medium
//  You are given an integer array nums of even length n and an integer limit.
//  In one move, you can replace any integer from nums with another integer between 1 and limit, inclusive.

//  The array nums is complementary if for all indices i (0-indexed), nums[i] + nums[n - 1 - i] equals the same number.
//  For example, the array [1,2,3,4] is complementary because for all indices i, nums[i] + nums[n - 1 - i] = 5.

//  Return the minimum number of moves required to make nums complementary.

//  Constraints:
//      n == nums.length
//      2 <= n <= 10^5
//      1 <= nums[i] <= limit <= 10^5
//      n is even.

//  Example 1:
//  Input: nums = [1,2,4,3], limit = 4
//  Output: 1

//  Example 2:
//  Input: nums = [1,2,2,1], limit = 2
//  Output: 2

//  Example 3:
//  Input: nums = [1,2,1,2], limit = 2
//  Output: 0

//  Moves per group: 0 1 2

//  4 numbers, A, B, A -> B or B -> A, moves are not the same
//      7 5 5 8 | 9
//      7 9 6 8 -> 2 moves
//      2 5 5 8 -> 1 move

// 7 5 5 8 | 9
//
// 2limit>=c>=2
// a<=b

//  if c = a + b, 0

//  if c > a + b
//      c - a - b = d
//      limit - a >= d or limit - b >= d, 1
//      c<=limit+b or c<=limit+a
//      c<=limit+b 1

//      if limit-a<d&limit-b<d, 2
//      limit-a<c-a-b -> c>limit+b
//      limit-b<c-a-b -> c>limit+a
//      c>limit+b 2
//
//  if c<a+b
//      a+b-c=d
//      a-1>=d or b-1>=d
//      b-1>=a+b-c
//      c>=a+1 1
//      c<a+1 2
//
//  2<=c<a+1 2
//  a+1<=c<a+b 1
//  c = a + b, 0
//  a+b<c<=limit+b 1
//  limit+b<c<=2limit 2
//
//  nums: [1,2,4,3]
//  limit: 4
//          c       2   3   4   5   6   7   8   9
//  move    (1, 3)  1   1   0   1   1   1   2   2
//          (2, 4)  2   1   1   1   0   1   1   2
//  total move      3   2   1   2   1   2   3

//          c       2   3   4   5   6   7   8  
//  diff    (1, 3)  1   0   -1  1   0   0   1   
//          (2, 4)  2   -1  0   0   -1  1   0   1
//  total diff      3   -1  -1  1   -1  1   1
//  prefix sum      3   2   1   2   1   2   3

// Use difference array and prefix sum

public class Solution
{
    public int MinMoves(int[] nums, int limit)
    {
        var diff = new int[2 * limit + 2];
        var length = nums.Length;

        for (var i = 0; i < length / 2; i++)
        {
            var a = Math.Min(nums[i], nums[length - 1 - i]);
            var b = Math.Max(nums[i], nums[length - 1 - i]);
            diff[2] += 2;
            diff[a + 1] -= 1;
            diff[a + b] -= 1;
            diff[a + b + 1] += 1;
            diff[limit + b + 1] += 1;
        }

        var ans = diff[2];
        var prefixSum = 0;
        
        for (var i = 2; i <= 2 * limit; i++)
        {
            prefixSum += diff[i];

            if (prefixSum < ans)
            {
                ans = prefixSum;
            }
        }

        return ans;
    }
}

public class MainProgram
{
    static void Main()
    {
        Solution sol = new Solution();

        int[] nums = [1, 2, 4, 3];
        var limit = 4;
        
        Console.WriteLine(sol.MinMoves(nums, limit));
        //  Output: 1

        nums = [1, 2, 2, 1];
        limit = 2;
        Console.WriteLine(sol.MinMoves(nums, limit));
        //  Output: 2

        nums = [1, 2, 1, 2];
        limit = 2;
        Console.WriteLine(sol.MinMoves(nums, limit));
        //  Output: 0
    }
}