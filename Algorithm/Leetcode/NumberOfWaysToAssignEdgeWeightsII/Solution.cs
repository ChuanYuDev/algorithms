using System.Numerics;

namespace Leetcode.NumberOfWaysToAssignEdgeWeightsII;

//  Time Limit Exceeded 585 / 589 testcases passed

//  [1]
//  [2,3]
//  [] [4,5]
//  [6,7]
//
//  6, 5 -> 3  
//  1,5-> 2
//  1,3-> 1
//  3,5-> 1
//  
//  1,6-> 3
//  1,3-> 1
//  3,6-> 2

//  Construct depth[] with O(n)
//      DFS
//      parent[i]
//
//  v u -> a
//  va = depth[v] - depth[a]
//  ua = depth[u] - depth[a]
//  dist = va + ua
//  ways = BigInteger(1) << (dist - 1)
//  result[i] = ways % 1_000_000_007

//  Lowest common ancestor
//  depthU
//  depthV
//
//  ancU = u
//  ancV = v
//
//  if (depthU < depthV)
//      for i from 0 to (depthV - depthU) - 1
//          ancV = parent[ancV]
//  else if (depthU > depthV)
//      for i from 0 to (depthU - depthV) - 1
//          ancU = parent[ancU]
//
//  while(ancU != ancV)
//      ancU = parent[ancU]     
//      ancV = parent[ancV]
//  return ancU

//  Time complexity: O(klogn + n)
//  Space complexity: O(n)

public class Tree
{
    private readonly int[][] _edges;
    private readonly int _nodeNum;
    private readonly int[] _depths;
    private readonly int[] _parents;
    private readonly List<int>[] _nodeEdges;

    public Tree(int[][] edges)
    {
        _edges = edges;
        _nodeNum = _edges.Length + 1;
        _depths = new int[_nodeNum + 1];
        _parents = new int[_nodeNum + 1];
        _nodeEdges = new List<int>[_nodeNum + 1];
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

public class Solution
{
    private const int Mod = 1_000_000_007;
    
    public int[] AssignEdgeWeights(int[][] edges, int[][] queries)
    {
        var tree = new Tree(edges);
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
