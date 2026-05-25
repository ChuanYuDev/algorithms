namespace Leetcode.JumpGameIII;

//  Jump Game III
//  Medium
//
//  Given an array of non-negative integers arr, you are initially positioned at start index of the array.
//  When you are at index i, you can jump to i + arr[i] or i - arr[i], check if you can reach any index with value 0.
//
//  Notice that you can not jump outside of the array at any time.
//
//  Example 1:
//  Input: arr = [4,2,3,0,3,1,2], start = 5
//  Output: true

//  Example 2:
//  Input: arr = [4,2,3,0,3,1,2], start = 0
//  Output: true 
//
//  Example 3:
//  Input: arr = [3,0,2,1,2], start = 2
//  Output: false
//
//  Constraints:
//      1 <= arr.length <= 5 * 10^4
//      0 <= arr[i] < arr.length
//      0 <= start < arr.length

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution2();
        int[] arr = [4, 2, 3, 0, 3, 1, 2];
        int start = 5;
        Console.WriteLine(sol.CanReach(arr, start));
        //  Output: true

        arr = [4, 2, 3, 0, 3, 1, 2];
        start = 0;
        Console.WriteLine(sol.CanReach(arr, start));
        //  Output: true 

        arr = [3, 0, 2, 1, 2];
        start = 2;
        Console.WriteLine(sol.CanReach(arr, start));
        //  Output: false
    }
    
}