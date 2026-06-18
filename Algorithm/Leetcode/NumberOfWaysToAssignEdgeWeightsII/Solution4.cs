using System.Numerics;

namespace Leetcode.NumberOfWaysToAssignEdgeWeightsII;

// Slightly optimize Solution
public class Tree4
{
    private readonly int[] _depths;
    private readonly int[] _parents;
    private readonly List<int>[] _nodeEdges;

    public Tree4(int[][] edges)
    {
        var nodeNum = edges.Length + 1;
        _depths = new int[nodeNum + 1];
        _parents = new int[nodeNum + 1];
        
        _nodeEdges = new List<int>[nodeNum + 1];
        for (var i = 1; i <= _nodeEdges.Length - 1; i++) _nodeEdges[i] = [];
        
        ConstructAdjacencyList(edges);
        Dfs(1, 0, 0);
    }
    
    public int GetDistance(int u, int v)
    {
        if (u == v) return 0;
        var anc = GetLowestCommonAncestor(u, v);
        var disUAnc = _depths[u] - _depths[anc];
        var disVAnc = _depths[v] - _depths[anc];
        return disUAnc + disVAnc;
    }

    private void ConstructAdjacencyList(int[][] edges)
    {
        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            _nodeEdges[u].Add(v);
            _nodeEdges[v].Add(u);
        }
    }

    private void Dfs(int node, int parent, int depth)
    {
        _parents[node] = parent;
        _depths[node] = depth;

        foreach (var i in _nodeEdges[node])
        {
            if (i == parent) continue;
            Dfs(i, node, depth + 1);
        }
    }

    private int GetLowestCommonAncestor(int u, int v)
    {
        var depthU = _depths[u];
        var depthV = _depths[v];
        var ancU = u;
        var ancV = v;

        if (depthU < depthV)
        {
            for (var i = 0; i <= depthV - depthU - 1; i++) ancV = _parents[ancV];
        }
        else if (depthU > depthV)
        {
            for (var i = 0; i <= depthU - depthV - 1; i++) ancU = _parents[ancU];
        }

        while (ancU != ancV)
        {
            ancU = _parents[ancU];
            ancV = _parents[ancV];
        }

        return ancU;
    }
}

public class Solution4
{
    private const int Mod = 1_000_000_007;
    
    public int[] AssignEdgeWeights(int[][] edges, int[][] queries)
    {
        var tree = new Tree4(edges);
        var qLength = queries.Length;
        var result = new int[qLength];
        var one = new BigInteger(1);

        for (var i = 0; i <= qLength - 1; i++)
        {
            var query = queries[i];
            var dist = tree.GetDistance(query[0], query[1]);
            if (dist == 0)
            {
                result[i] = 0;
                continue;
            }

            var ways = one << (dist - 1);
            result[i] = (int)(ways % Mod);
        }

        return result;
    }
}
