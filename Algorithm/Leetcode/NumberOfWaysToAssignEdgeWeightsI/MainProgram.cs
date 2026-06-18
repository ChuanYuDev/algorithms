
namespace Leetcode.NumberOfWaysToAssignEdgeWeightsI;

//  Number of Ways to Assign Edge Weights I
//  Medium
//  
//  There is an undirected tree with n nodes labeled from 1 to n, rooted at node 1.
//      The tree is represented by a 2D integer array edges of length n - 1, where edges[i] = [ui, vi] indicates that there is an edge between nodes ui and vi.
//
//  Initially, all edges have a weight of 0.
//      You must assign each edge a weight of either 1 or 2.
//
//  The cost of a path between any two nodes u and v is the total weight of all edges in the path connecting them.
//
//  Select any one node x at the maximum depth
//  Return the number of ways to assign edge weights in the path from node 1 to x such that its total cost is odd.
//
//  Since the answer may be large, return it modulo 10^9 + 7.
//
//  Note: Ignore all edges not in the path from node 1 to x.
//
//  Example 1:
//  Input: edges = [[1,2]]
//  Output: 1
//
//  Example 2:
//  Input: edges = [[1,2],[1,3],[3,4],[3,5]]
//  Output: 2
//
//  Constraints:
//      2 <= n <= 10^5
//      edges.length == n - 1
//      edges[i] == [ui, vi]
//      1 <= ui, vi <= n
//      edges represents a valid tree.


public class MainProgram
{
    static void Main()
    {
        var sol = new Solution3();
        int[][] edges = [[1, 2]];
        Console.WriteLine(sol.AssignEdgeWeights(edges));
        //  Output: 1

        edges = [[1, 2], [1, 3], [3, 4], [3, 5]];
        Console.WriteLine(sol.AssignEdgeWeights(edges));
        //  Output: 2
    }
}