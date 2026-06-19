namespace Leetcode.NumberOfWaysToAssignEdgeWeightsII;

//  Time complexity of Solution is actually:
//      Dfs: O(n)
//      GetLowestCommonAncestor: O(n)
//      Total: O(kn) instead of O(klogn + n)

//  Optimization
//  1. Precompute 2^x % Mod
//  2. Construct ancs

//  Precompute 2^x % Mod
//      2^x %m = r1
//      2^(x+1) % m = r2
//      prove that r2 = r1 * 2 % m
//      r2 = (2^x) * 2 % m = (am + r1) *2 % m = r1 * 2 % m

//  Construct ancs table ancs[x][i] that denotes the 2^i th ancestor of x
//      Specially, ancs[x][0] is the parent of x
//      n = 5, 2^i + 1 <= n, maxI = log2n = 2
//      ancs[i][k] = ancs[ancs[i][k-1]][k-1]
//      [1]
//      [2,3]
//      [] [4,5]
//      i k 0   1   2   depth
//      0   0   0   0   0
//      1   0   0   0   0
//      2   1   0   0   1   
//      3   1   0   0   1
//      4   3   1   0   2
//      5   3   1   0   2

//  Time complexity
//      Construct ancs table: O(nlogn)
//      Find LCA: O(logn)
//      Total: O(klogn+nlogn)

//  Space complexity
//      O(nlogn)

public class Tree4
{
    private readonly int _nodeNum;
    private readonly int _maxK;
    private readonly int[] _depths;
    private readonly int[,] _ancs;
    private readonly List<int>[] _nodeEdges;

    public Tree4(int[][] edges)
    {
        _nodeNum = edges.Length + 1;
        _maxK = (int)Math.Log2(_nodeNum);
        
        _depths = new int[_nodeNum + 1];
        _depths[0] = -1;

        _ancs = new int[_nodeNum + 1, _maxK + 1];
        
        _nodeEdges = new List<int>[_nodeNum + 1];
        for (var i = 1; i <= _nodeEdges.Length - 1; i++) _nodeEdges[i] = [];
        
        ConstructAdjacencyList(edges);
        Dfs(1, 0, 0);

        for (var k = 1; k <= _maxK; k++)
        {
            for (var i = 1; i <= _nodeNum; i++) _ancs[i, k] = _ancs[_ancs[i, k - 1], k - 1];
        }
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
        _ancs[node, 0] = parent;
        _depths[node] = depth;

        foreach (var i in _nodeEdges[node])
        {
            if (i == parent) continue;
            Dfs(i, node, depth + 1);
        }
    }

    private int GetLowestCommonAncestor(int u, int v)
    {
        if (_depths[u] > _depths[v]) (u, v) = (v, u);

        for (var k = _maxK; k >= 0; k--)
        {
            var ancsK = _ancs[v, k];
            if (_depths[u] <= _depths[ancsK]) v = ancsK;
        }

        if (u == v) return u;

        for (var k = _maxK; k >= 0; k--)
        {
            var ancsUk = _ancs[u, k];
            var ancsVk = _ancs[v, k];
            if (ancsUk != ancsVk)
            {
                u = ancsUk;
                v = ancsVk;
            }
        }

        return _ancs[u, 0];
    }
}

public class Solution4
{
    private const int Mod = 1_000_000_007;
    private const int MaxNodeNum = 100_000;
    private static readonly int[] WaysMods;

    static Solution4()
    {
        var maxDist = MaxNodeNum - 1;
        WaysMods = new int[maxDist + 1];
        WaysMods[0] = 0;
        WaysMods[1] = 1;

        for (var i = 2; i <= WaysMods.Length - 1; i++)
        {
            WaysMods[i] = (int)((long)WaysMods[i - 1] * 2 % Mod);
        }
    }
    
    public int[] AssignEdgeWeights(int[][] edges, int[][] queries)
    {
        var tree = new Tree4(edges);
        var qLength = queries.Length;
        var result = new int[qLength];

        for (var i = 0; i <= qLength - 1; i++)
        {
            var query = queries[i];
            var dist = tree.GetDistance(query[0], query[1]);
            result[i] = WaysMods[dist];
        }

        return result;
    }
}
