namespace Leetcode.RotatedDigits;

//  invalid: 0, ex.7
//  same: 1, valid + same, ex.1
//  good: 2, valid + diff, ex.2
//
//  n -> n / 10, n % 10
//      if (n/10 is invalid)
//          n is invalid
//      if (n/10 is same)
//          if (n%10 is 2,5,6,9) n is good
//          else (n%10 is 0,1,8) n is same
//          else n is invalid
//      if (n/10 is good)
//          if (n%10 is 0,1,8,2,5,6,9) n is good
//          else n is invalid

//  Time complexity: O(n)
//  Space complexity: O(n)

public class Solution
{
    public int RotatedDigits(int n)
    {
        int[] status = new int[n + 1];
        status[0] = 1;

        for (var i = 1; i <= n; i++)
        {
            int q = i / 10, r = i % 10;
            var statusQ = status[q];

            switch (statusQ)
            {
                case 0:
                    status[i] = 0;
                    break;
                
                case 1:
                    status[i] = r switch
                    {
                        2 or 5 or 6 or 9 => 2,
                        0 or 1 or 8 => 1,
                        _ => 0,
                    };
                    break;
                
                case 2:
                    status[i] = r switch
                    {
                        0 or 1 or 8 or 2 or 5 or 6 or 9 => 2,
                        _ => 0,
                    };
                    break;
                default:
                    break;
            }
        }

        var goodNum = 0;

        foreach (var s in status)
        {
            if (s == 2) goodNum++;
        }

        return goodNum;
    }
}
