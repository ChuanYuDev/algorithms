using System.Numerics;

namespace Leetcode.NumberOfWaysToAssignEdgeWeightsI;
//  Optimization
//  1. When use BFS to calculate the depth, we don't need the visited array
//      Because except for the parent, all the other nodes are children which are all not visited
//      We only need to pass the parent in the queue
//
//  2. We can use directly define mod number with digit separator

public class Solution2
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

        var queue = new Queue<(int,int)>();
        queue.Enqueue((1, 0));
        var depth = -1;
        while (queue.Count > 0)
        {
            depth++;
            var nextLayer = new Queue<(int,int)>();
            foreach (var (i, parent) in queue)
            {
                foreach (var j in nodeEdges[i])
                {
                    if (j == parent) continue;
                    nextLayer.Enqueue((j, i));
                }
            }

            queue = nextLayer;
        }
        
        // Get ways so that total cost is odd
        var ways = new BigInteger(1) << (depth - 1);
            
        return (int)(ways % 1_000_000_007);
    }
}
