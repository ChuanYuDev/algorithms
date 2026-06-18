using System.Numerics;

namespace Leetcode.NumberOfWaysToAssignEdgeWeightsI;

// We can use DFS to get maximum Depth

public class Solution3
{
    private int Dfs(List<int>[] nodeEdges, int node, int parent)
    {
        var maxDepth = 0;

        foreach (var i in nodeEdges[node])
        {
            if (i == parent) continue;

            maxDepth = Math.Max(maxDepth, Dfs(nodeEdges, i, node) + 1);
        }
        return maxDepth;
    }
    
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

        var depth = Dfs(nodeEdges, 1, 0);
        
        // Get ways so that total cost is odd
        var ways = new BigInteger(1) << (depth - 1);
            
        return (int)(ways % 1_000_000_007);
    }
}

