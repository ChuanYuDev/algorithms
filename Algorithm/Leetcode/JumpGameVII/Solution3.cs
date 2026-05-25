namespace Leetcode.JumpGameVII;

//  Because we always check the new element, visited[j] is always false, we don't need to check it, it is safe to be removed
//  
//  We can pre-calculate maxJ and no need to calculate it in each loop

//  DP + sliding window
//  Refer to https://leetcode.com/problems/jump-game-vii/solutions/8291603/dp-sliding-window-easy-solution-by-vkram-us6a/?envType=daily-question&envId=2026-05-25
//  The time complexity is the same as BFS, but it is faster

public class Solution3
{
    public bool CanReach(string s, int minJump, int maxJump)
    {
        var length = s.Length;
        var queue = new Queue<int>();
        int lastIdx = 0;

        queue.Enqueue(0);
        while (queue.Count > 0)
        {
            var i = queue.Dequeue();

            var minJ = i + minJump;
            
            if (i != 0) minJ = Math.Max(minJ, Math.Min(lastIdx + maxJump, length - 1) + 1);
            lastIdx = i;

            var maxJ = Math.Min(i + maxJump, length - 1);

            for (var j = minJ; j <= maxJ; j++)
            {
                if (s[j] == '0')
                {
                    if (j == length - 1) return true;
                    queue.Enqueue(j);
                }
            }
        }

        return false;
    }
}
