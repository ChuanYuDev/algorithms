namespace Leetcode.JumpGameII;
//  Jump Game II
//  Medium
//
//  You are given a 0-indexed array of integers nums of length n.
//      You are initially positioned at index 0.

//  Each element nums[i] represents the maximum length of a forward jump from index i.
//      In other words, if you are at index i, you can jump to any index (i + j) where:
//
//      0 <= j <= nums[i] and
//      i + j < n
//
//  Return the minimum number of jumps to reach index n - 1.
//
//  The test cases are generated such that you can reach index n - 1.
//
//  Example 1:
//  Input: nums = [2,3,1,1,4]
//  Output: 2
//
//  Example 2:
//  Input: nums = [2,3,0,1,4]
//  Output: 2
//  
//  Constraints:
//      1 <= nums.length <= 10^4
//      0 <= nums[i] <= 1000
//      It's guaranteed that you can reach nums[n - 1].

//  Index       0   1   2   3   4   5
//  nums        2,  3,  1,  1,  4   0
//  CanJump     0   -1  -1  -1  -1  -1
//              0   1   1   -1  -1  -1
//              0   1   1   2   2   -1
//              0   1   1   2   2   -1
//              0   1   1   2   2   -1
//              0   1   1   2   2   3

//  for i = 2, 3, 4, we have different jumps 
//  for i = 2, jump is still 1, this is within lastFarthest

//  jump = 0
//  lastFarthest = 0
//  farthest = 0
//
//  i = 0
//      jump = 0
//      lastFarthest = 0
//      farthest = 2
//  i = 1
//      jump = 1
//      lastFarthest = 2
//      farthest = 4
//  i = 2
//      jump = 1
//      farthest = 4
//  i = 3
//      jump = 2
//      lastFarthest = 4
//      farthest = 4
//  i = 4
//      jump = 2
//      lastFarthest = 4
//      farthest = 5
//  i = 5
//      jump = 3

//  if (i > lastFarthest)
//      jump++
//      lastFarthest = farthest
//  
//  if (i == n-1)
//      return jump
//
//  if (i + nums[i] > farthest)
//      farthest = i + nums[i]
//

//  Index       0   1   2   3   4   5
//  nums        2,  3,  3,  1,  4   0
//  CanJump     0   -1  -1  -1  -1  -1
//              0   1   1   -1  -1  -1
//              0   1   1   2   2   -1
//              0   1   1   2   2   2

//  Index       0   1   2   3   4   5
//  nums        4,  3,  1,  1,  4   0
//  CanJump     0   -1  -1  -1  -1  -1
//              0   1   1   1   1   -1
//              0   1   1   1   1   -1
//              0   1   1   1   1   -1
//              0   1   1   1   1   -1
//              0   1   1   1   1   2

public class Solution
{
    public int Jump(int[] nums)
    {
        var length = nums.Length;

        int jump = 0, lastFarthest = 0, farthest = 0;

        for (var i = 0; i < length; i++)
        {
            if (i > lastFarthest)
            {
                jump++;
                lastFarthest = farthest;

            }

            if (i == length - 1)
                return jump;

            if (i + nums[i] > farthest) farthest = i + nums[i];
        }

        return -1;
    }
}

public class MainProgram
{
    static void Main()
    {
        Solution sol = new Solution();

        int[] nums = [2, 3, 1, 1, 4];
        Console.WriteLine(sol.Jump(nums));
        //  Output: 2

        nums = [2, 3, 0, 1, 4];
        Console.WriteLine(sol.Jump(nums));
        //  Output: 2

        nums = [2, 3, 1, 1, 4, 0];
        Console.WriteLine(sol.Jump(nums));
        //   Output: 3

        nums = [2, 3, 3, 1, 4, 0];
        Console.WriteLine(sol.Jump(nums));
        //  Output: 2

        nums = [4, 3, 1, 1, 4, 0];
        Console.WriteLine(sol.Jump(nums));
        //   Output: 2
    }
    
}