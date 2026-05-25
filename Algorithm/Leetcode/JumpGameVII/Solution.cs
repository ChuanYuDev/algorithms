namespace Leetcode.JumpGameVII;

//  visited[0] = true
//  queue.Enqueue(0)
//  while (queue.Count > 0)
//      i = queue.Dequeue()
//      for (j = i + minJump; j <= min(i + maxJump, s.length - 1); j++)
//          if (s[j] == '0' && !visited[j])
//              if (j == length - 1) return true
//              visited[j] = true
//              queue.Enqueue(j)
//  return false
//
//  BFS O(n^2) because the edges are O(n^2)
//      This method is not qualified because of high time complexity

public class Solution
{
    public bool CanReach(string s, int minJump, int maxJump)
    {
        var length = s.Length;
        bool[] visited = new bool[length];
        var queue = new Queue<int>();

        visited[0] = true;
        queue.Enqueue(0);
        while (queue.Count > 0)
        {
            var i = queue.Dequeue();

            for (var j = i + minJump; j <= Math.Min(i + maxJump, length - 1); j++)
            {
                if (s[j] == '0' && !visited[j])
                {
                    if (j == length - 1) return true;

                    visited[j] = true;
                    queue.Enqueue(j);
                }
            }
        }

        return false;
    }
}
