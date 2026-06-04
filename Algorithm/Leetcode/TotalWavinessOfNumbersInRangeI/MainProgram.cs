namespace Leetcode.TotalWavinessOfNumbersInRangeI;

//  Total Waviness of Numbers in Range I
//  Medium
//  You are given two integers num1 and num2 representing an inclusive range [num1, num2].
//
//  The waviness of a number is defined as the total count of its peaks and valleys:
//      A digit is a peak if it is strictly greater than both of its immediate neighbors.
//      A digit is a valley if it is strictly less than both of its immediate neighbors.
//      The first and last digits of a number cannot be peaks or valleys.
//      Any number with fewer than 3 digits has a waviness of 0.
//
//  Return the total sum of waviness for all numbers in the range [num1, num2].
//
//  Example 1:
//  Input: num1 = 120, num2 = 130
//  Output: 3
//
//  Example 2:
//  Input: num1 = 198, num2 = 202
//  Output: 3
//
//  Example 3:
//  Input: num1 = 4848, num2 = 4848
//  Output: 2
//
//  Constraints:
//      1 <= num1 <= num2 <= 10^5

//  waviness = 0
//  for num from nums1 to nums2
//      numStr = num.ToString()
//      length = numStr.Length
//      if (length <= 2) continue
//
//      bool? lastCompare = null
//      for i from 1 to length - 1
//          if (numStr[i] == numStr[i-1]) continue
//          if (i == 1)
//              lastCompare = numStr[i] > numStr[i-1]
//              continue
//          compare = numStr[i] > numStr[i-1]
//
//          if (lastCompare == !compare) waviness++
//          lastCompare = compare
//
//  return waviness
//
//  Time complexity
//      digits: d
//      nums1 to num2: n
//      O(nd)
//
//  Space complexity
//      O(d)

//  5872 5921
//  5872 - 5877 1
//  5878 2
//  5879 2
//  5880
//  5921

public class Solution
{
    public int TotalWaviness(int num1, int num2)
    {
        int waviness = 0;

        for (var num = num1; num <= num2; num++)
        {
            var numStr = num.ToString();
            var length = numStr.Length;
            
            if (length <= 2) continue;

            bool? lastCompare = null;
            for (var i = 1; i <= length - 1; i++)
            {
                if (numStr[i] == numStr[i - 1])
                {
                    lastCompare = null;
                    continue;
                }

                if (i == 1)
                {
                    lastCompare = numStr[i] > numStr[i - 1];
                    continue;
                }

                var compare = numStr[i] > numStr[i - 1];

                if (lastCompare == !compare) waviness++;

                lastCompare = compare;
            }
        }

        return waviness;
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        int num1 = 120, num2 = 130;
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

        num1 = 991;
        num2 = 991;
        Console.WriteLine(sol.TotalWaviness(num1, num2));
        //  Output: 0

        num1 = 5872;
        num2 = 5921;
        Console.WriteLine(sol.TotalWaviness(num1, num2));
        //  Output: 58

    }
}