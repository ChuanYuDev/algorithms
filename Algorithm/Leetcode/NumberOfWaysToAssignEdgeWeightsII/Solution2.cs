using System.Numerics;

namespace Leetcode.NumberOfWaysToAssignEdgeWeightsII;

//  Runtime Error 581 / 589 testcases passed
//  Out of memory.

//  To get lowest common ancestor, we can save the ancestors of nodes in the path

//  int[,] ancs = new int[_nodeNum + 1, _nodeNum+1]

//  Lowest common ancestor
//  if (u == v) return u
//  if (ancs[u, v] != 0) return anc[u, v]

//  depthU
//  depthV
//
//  ancU = u
//  ancV = v
//  ancUs = List<int>{u}
//  ancVs = List<int>{v}
//
//  if (depthU < depthV)
//      for i from 0 to (depthV - depthU) - 1
//          ancV = parent[ancV]
//          ancVs.Add(ancV)
//  else if (depthU > depthV)
//      for i from 0 to (depthU - depthV) - 1
//          ancU = parent[ancU]
//          ancUs.Add(ancU) 
//
//  while(ancU != ancV)
//      ancU = parent[ancU]     
//      ancV = parent[ancV]
//      ancUs.Add(ancU)
//      ancVs.Add(ancV)
//  
//  anc = ancU
//  foreach ancU in ancUs
//      foreach ancV in ancVs
//          ancs[ancU, ancV] = anc
//          ancs[ancV, ancU] = anc
//      
//  return anc

public class Tree2
{
    private readonly int[][] _edges;
    private readonly int _nodeNum;
    private readonly int[] _depths;
    private readonly int[] _parents;
    private readonly List<int>[] _nodeEdges;
    private readonly int[,] _ancs;

    public Tree2(int[][] edges)
    {
        _edges = edges;
        _nodeNum = _edges.Length + 1;
        _depths = new int[_nodeNum + 1];
        _parents = new int[_nodeNum + 1];
        _nodeEdges = new List<int>[_nodeNum + 1];
        _ancs = new int[_nodeNum + 1, _nodeNum + 1];
        InitialzieNodeEdges();
        ConstructAdjacencyList();
        Dfs(1, 0, 0);
    }
    
    public int GetDistance(int u, int v)
    {
        var anc = GetLowestCommonAncestor(u, v);
        var disUAnc = _depths[u] - _depths[anc];
        var disVAnc = _depths[v] - _depths[anc];
        return disUAnc + disVAnc;
    }

    private void InitialzieNodeEdges()
    {
        for (var i = 1; i <= _nodeEdges.Length - 1; i++) _nodeEdges[i] = [];
    }

    private void ConstructAdjacencyList()
    {
        foreach (var edge in _edges)
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
        if (u == v) return u;

        if (_ancs[u, v] != 0) return _ancs[u, v];
        
        var depthU = _depths[u];
        var depthV = _depths[v];
        var ancU = u;
        var ancV = v;
        List<int> ancUs = [u];
        List<int> ancVs = [v];

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
                _ancs[i, j] = anc;
                _ancs[j, i] = anc;
            }
        }

        return anc;
    }
}

public class Solution2
{
    private const int Mod = 1_000_000_007;
    
    public int[] AssignEdgeWeights(int[][] edges, int[][] queries)
    {
        var tree = new Tree2(edges);
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
