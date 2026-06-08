namespace Leetcode.TotalWavinessOfNumbersInRangeII;
//  Total Waviness of Numbers in Range II
//  Hard
//  Problem description is the same as Total Waviness of Numbers in Range I, except for constraints
//
//  Constraints:
//      1 <= num1 <= num2 <= 10^15
//

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution3();
        long num1 = 120, num2 = 130;
        Console.WriteLine(sol.TotalWaviness(num1, num2));
        //  Output: 3

        num1 = 198;
        num2 = 202;
        Console.WriteLine(sol.TotalWaviness(num1, num2));
        //  Output: 3

        num1 = 4848;
        num2 = 4848;
        Console.WriteLine(sol.TotalWaviness(num1, num2));
        //  Output: 2

        num1 = 8900;
        num2 = 9532;
        Console.WriteLine(sol.TotalWaviness(num1, num2));
        //  Output: 794

        num1 = 2549294942;
        num2 = 5067104447;
        Console.WriteLine(sol.TotalWaviness(num1, num2));
        //  Output: 11661365485
    }
}