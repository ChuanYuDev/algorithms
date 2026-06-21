namespace Leetcode.MaximumBuildingHeight;

//  Maximum Building Height
//  Hard
//  You want to build n new buildings in a city.
//      The new buildings will be built in a line and are labeled from 1 to n.
//
//  However, there are city restrictions on the heights of the new buildings:
//      The height of each building must be a non-negative integer.
//      The height of the first building must be 0.
//      The height difference between any two adjacent buildings cannot exceed 1.
//
//  Additionally, there are city restrictions on the maximum height of specific buildings.
//      These restrictions are given as a 2D integer array restrictions where restrictions[i] = [idi, maxHeighti] indicates that building idi must have a height less than or equal to maxHeighti.
//
//  It is guaranteed that each building will appear at most once in restrictions, and building 1 will not be in restrictions.
//
//  Return the maximum possible height of the tallest building.
//
//  Example 1:
//  Input: n = 5, restrictions = [[2,1],[4,1]]
//  Output: 2
//
//  Example 2:
//  Input: n = 6, restrictions = []
//  Output: 5
//
//  Example 3:
//  Input: n = 10, restrictions = [[5,3],[2,5],[7,4],[10,3]]
//  Output: 5
//
//  Constraints:
//      2 <= n <= 10^9
//      0 <= restrictions.length <= min(n - 1, 10^5)
//      2 <= idi <= n
//      idi is unique.
//      0 <= maxHeighti <= 10^9

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution2();
        int n = 5;
        int[][] restrictions = [[2, 1], [4, 1]];
        Console.WriteLine(sol.MaxBuilding(n, restrictions));
        //  Output: 2

        n = 6;
        restrictions = [];
        Console.WriteLine(sol.MaxBuilding(n, restrictions));
        //  Output: 5

        n = 10;
        restrictions = [[5, 3], [2, 5], [7, 4], [10, 3]];
        Console.WriteLine(sol.MaxBuilding(n, restrictions));
        //  Output: 5
    }
}