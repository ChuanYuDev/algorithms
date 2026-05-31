using Helper;

namespace Leetcode.BlockPlacementQueries;
//  Block Placement Queries
//  Hard
//         
//  There exists an infinite number line, with its origin at 0 and extending towards the positive x-axis.
//  You are given a 2D array queries, which contains two types of queries:
//
//  For a query of type 1, queries[i] = [1, x].
//      Build an obstacle at distance x from the origin.
//      It is guaranteed that there is no obstacle at distance x when the query is asked.
//
//  For a query of type 2, queries[i] = [2, x, sz].
//      Check if it is possible to place a block of size sz anywhere in the range [0, x] on the line, such that the block entirely lies in the range [0, x].
//      A block cannot be placed if it intersects with any obstacle, but it may touch it.
//      Note that you do not actually place the block.
//      Queries are separate.
//
//  Return a boolean array results, where results[i] is true if you can place the block specified in the ith query of type 2, and false otherwise.
//
//  Example 1:
//  Input: queries = [[1,2],[2,3,3],[2,3,1],[2,2,2]]
//  Output: [false,true,true]
//
//  Example 2:
//  Input: queries = [[1,7],[2,7,6],[1,2],[2,7,5],[2,7,6]]
//  Output: [true,true,false]
//
//  Constraints:
//      1 <= queries.length <= 15 * 10^4
//      2 <= queries[i].length <= 3
//      1 <= queries[i][0] <= 2
//      1 <= x, sz <= min(5 * 10^4, 3 * queries.length)
//      The input is generated such that for queries of type 1, no obstacle exists at distance x when the query is asked.
//      The input is generated such that there is at least one query of type 2.

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution2();
        int[][] queries = [[1, 2], [2, 3, 3], [2, 3, 1], [2, 2, 2]];
        PrintHelper.PrintEnumerable(sol.GetResults(queries));
        //  Output: [false,true,true]

        queries = [[1, 7], [2, 7, 6], [1, 2], [2, 7, 5], [2, 7, 6]];
        PrintHelper.PrintEnumerable(sol.GetResults(queries));
        //  Output: [true,true,false]

        queries =
        [
            [1, 24], [2, 19, 28], [2, 25, 17], [2, 26, 16], [1, 9], [1, 14], [1, 11], [1, 28], [1, 1], [2, 11, 10]
        ];

        PrintHelper.PrintEnumerable(sol.GetResults(queries));
        //  Output: [false,true,true,false]

        queries =
        [
            [2, 11, 13], [1, 23], [1, 14], [1, 26], [2, 13, 29], [2, 18, 24], [1, 25], [1, 10], [2, 21, 11], [2, 5, 1]
        ];
        PrintHelper.PrintEnumerable(sol.GetResults(queries));
        //  Output: [false,false,false,false,true]
        
    }
}