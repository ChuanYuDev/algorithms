namespace Leetcode.JumpGameIV;
//  Jump Game IV
//  Hard
//
//  Given an array of integers arr, you are initially positioned at the first index of the array.
//  In one step you can jump from index i to index:
//      i + 1 where: i + 1 < arr.length.
//      i - 1 where: i - 1 >= 0.
//      j where: arr[i] == arr[j] and i != j.
//
//  Return the minimum number of steps to reach the last index of the array.
//  Notice that you can not jump outside of the array at any time.
//
//  Example 1:
//  Input: arr = [100,-23,-23,404,100,23,23,23,3,404]
//  Output: 3
//
//  Example 2:
//  Input: arr = [7]
//  Output: 0
//
//  Example 3:
//  Input: arr = [7,6,9,6,9,6,9,7]
//  Output: 1
//
//  Constraints:
//      1 <= arr.length <= 5 * 10^4
//     -10^8 <= arr[i] <= 10^8

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution2();
        int[] arr = [100, -23, -23, 404, 100, 23, 23, 23, 3, 404];
        Console.WriteLine(sol.MinJumps(arr));
        //  Output: 3

        arr = [7];
        Console.WriteLine(sol.MinJumps(arr));
        //  Output: 0

        arr = [7, 6, 9, 6, 9, 6, 9, 7];
        Console.WriteLine(sol.MinJumps(arr));
        //  Output: 1

        arr = [7, 7, 2, 1, 7, 7, 7, 3, 4, 1];
        Console.WriteLine(sol.MinJumps(arr));
        //  Output: 3

        arr = [6, 1, 2, 3, 4, 1, 2, 3, 4, 7, 11];
        Console.WriteLine(sol.MinJumps(arr));
        //  Output: 6
    }
}