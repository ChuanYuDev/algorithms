namespace Leetcode.JumpGameVII;

//  0100110
//  minJump = 2, maxJump = 5
//  0 -> 2 3 4 5
//  2 -> 4 5 6 7
//  3 -> 5 6 7 8
//  For each node
//      i -> i + minJump ~ min(i + maxJump, s.length - 1), for example, j
//      j -> j + minJump ~ min(j + maxJump, s.length - 1)
//          X Because i + minJump ~ min(i + maxJump, s.length - 1) has been checked
//      minJ = max(j + minJump, min(i + maxJump, s.length - 1) + 1 )
//      j -> minJ ~ min(j + maxJump, s.length - 1)
//  Remember last index
//                  lastIdx
//  0 -> 2 3 4 5    0
//  2 -> 6 7        2
//  3 -> 8          3
//  4 -> 9          4
//
//  Time complexity: O(n)

public class Solution2
{
    public bool CanReach(string s, int minJump, int maxJump)
    {
        var length = s.Length;
        bool[] visited = new bool[length];
        var queue = new Queue<int>();
        int lastIdx = 0;

        visited[0] = true;
        queue.Enqueue(0);
        while (queue.Count > 0)
        {
            var i = queue.Dequeue();

            var minJ = i + minJump;
            
            if (i != 0) minJ = Math.Max(minJ, Math.Min(lastIdx + maxJump, length - 1) + 1);
            lastIdx = i;

            for (var j = minJ; j <= Math.Min(i + maxJump, length - 1); j++)
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
