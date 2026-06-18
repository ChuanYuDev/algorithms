using System.Numerics;
namespace Leetcode.NumberOfWaysToAssignEdgeWeightsI;

//  Get maximum depth
//      [[3,4],[3,5],[1,2],[1,3]]
//      [[1,2],[1,3], [3,4],[3,5]]
//      idx depth
//      1   0
//      2   1
//      3   1
//      4   2
//      5   2

//      1
//      2 5
//        3 
//        4
//      [1,2], [1,5], [3,5], [3,4]
//      1: [2,5]
//      2: [1]
//      3: [4,5]
//      4: [3]
//      5: [1,3]
//      queue   depth
//      1       0
//      2,5     1
//      3       2
//      4       3
//
//      BFS
//      queue
//      visited[1] = true
//      queue.Enqueue(1)
//      depth=-1
//      while(queue.Count > 0)
//          depth++
//          nextQueue
//          for i in queue
//              for j in edges[i]
//                  if (!visited[j])
//                      visited[j] = true
//                      nextQueue.Enqueue(j)
//          queue = nextQueue
//      return depth

//  Total cost is odd
//      # of edges with weight 1 is odd
//      2 edges    
//      total ways:4, ways: 2
//      1   1
//      1   2
//      2   1
//      2   2
//  
//      3 edges
//      1   1   1   Y
//      1   1   
//      1       1
//          1   1
//      1           Y
//          1       Y
//              1   Y
//      2   2   2 X
//
//      4 edges
//      # of weight 1: 1, 3
//      4 + 4 = 8
//      symmetric
//      # of weight 2: 1, 3
//      when # of weight 2 is 1, the # of weight 1 is 3
//      # of weight 1: 3, 1
//
//  Half: 2^(depth) / 2 = 2^(depth - 1)

//  Modulo 10^9 + 7
//      depth max: 10^5
//      ways: 2^(depth-1) = (2^10)^(10^4) = 10^(3*10^4) >>> long

//  Time complexity
//      n = edges.Length 
//      O(n)

//  Space complexity
//      nodeEdges: O(# of edges) = O(n)
//      visited: O(n)
//      queue: O(n)
//      Total: O(n)

public class Solution
{
    public int AssignEdgeWeights(int[][] edges)
    {
        // Get maximum depth
        var nodeNum = edges.Length + 1;
        var nodeEdges = new List<int>[nodeNum + 1];

        for (var i = 1; i <= nodeEdges.Length - 1; i++) nodeEdges[i] = [];

        foreach (var edge in edges)
        {
            var i = edge[0];
            var j = edge[1];
            nodeEdges[i].Add(j);
            nodeEdges[j].Add(i);
        }

        var queue = new Queue<int>();
        var visited = new bool[nodeNum + 1];
        queue.Enqueue(1);
        visited[1] = true;
        var depth = -1;
        while (queue.Count > 0)
        {
            depth++;
            var nextLayer = new Queue<int>();
            foreach (var i in queue)
            {
                foreach (var j in nodeEdges[i])
                {
                    if (!visited[j])
                    {
                        visited[j] = true;
                        nextLayer.Enqueue(j);
                    }
                }
            }

            queue = nextLayer;
        }
        
        // Get ways so that total cost is odd
        var ways = new BigInteger(1) << (depth - 1);
            
        return (int)(ways % ((int)Math.Pow(10, 9) + 7));
    }
}
