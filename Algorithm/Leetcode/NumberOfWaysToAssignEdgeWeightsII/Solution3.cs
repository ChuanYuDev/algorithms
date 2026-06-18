using System.Numerics;

namespace Leetcode.NumberOfWaysToAssignEdgeWeightsII;

//  Runtime Error 581 / 589 testcases passed
//  Out of memory.

//  We can only assign half the memory to _ancs

public class Tree3
{
    private readonly int[] _depths;
    private readonly int[] _parents;
    private readonly List<int>[] _nodeEdges;
    private readonly int[][] _ancs;

    public Tree3(int[][] edges)
    {
        var nodeNum = edges.Length + 1;
        _depths = new int[nodeNum + 1];
        _parents = new int[nodeNum + 1];
        
        _nodeEdges = new List<int>[nodeNum + 1];
        for (var i = 1; i <= _nodeEdges.Length - 1; i++) _nodeEdges[i] = [];
        
        _ancs = new int[nodeNum + 1][];
        for (var i = 1; i <= _ancs.Length - 1; i++) _ancs[i] = new int[i];
        
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
        if (u < v) (u, v) = (v, u);
        if (_ancs[u][v] != 0) return _ancs[u][v];
        
        var depthU = _depths[u];
        var depthV = _depths[v];
        var ancU = u;
        var ancV = v;
        List<int> ancUs = [ancU];
        List<int> ancVs = [ancV];

        if (depthU < depthV)
        {
            for (var i = 0; i <= depthV - depthU - 1; i++)
            {
                ancV = _parents[ancV];
                ancVs.Add(ancV);
            }
        }
        else if (depthU > depthV)
        {
            for (var i = 0; i <= depthU - depthV - 1; i++)
            {
                ancU = _parents[ancU];
                ancUs.Add(ancU);
            }
        }

        while (ancU != ancV)
        {
            ancU = _parents[ancU];
            ancV = _parents[ancV];
            ancUs.Add(ancU);
            ancVs.Add(ancV);
        }

        var anc = ancU;

        foreach (var i in ancUs)
        {
            foreach (var j in ancVs)
            {
                if (i == j) continue; 
                if (i < j) _ancs[j][i] = anc;
                else _ancs[i][j] = anc;
            }
        }

        return anc;
    }
}

public class Solution3
{
    private const int Mod = 1_000_000_007;
    
    public int[] AssignEdgeWeights(int[][] edges, int[][] queries)
    {
        var tree = new Tree3(edges);
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
