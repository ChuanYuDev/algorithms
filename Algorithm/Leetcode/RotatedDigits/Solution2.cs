namespace Leetcode.RotatedDigits;

//  Optimization
//  1. For last digit, we can save these in status, there is no need to check the value of r every time
//  2. No need to traverse the status again to get good number, we can get it in the process of digit processing

//  2,5,6,9: good
//  0,1,8: same
//  3,4,7: invalid

public class Solution2
{
    public int RotatedDigits(int n)
    {
        var status = new int[n + 1];
        var goodCnt = 0;
        
        for (var i = 0; i <= n; i++)
        {
            if (i <= 9)
            {
                switch (i)
                {
                    case 3 or 4 or 7:
                        status[i] = 0;
                        break;
                    case 0 or 1 or 8:
                        status[i] = 1;
                        break;
                    default:
                        status[i] = 2;
                        goodCnt++;
                        break;
                }
                
                continue;
            }
            
            int q = i / 10, r = i % 10;
            var statusQ = status[q];
            var statusR = status[r];

            switch (statusQ)
            {
                case 0:
                    status[i] = 0;
                    break;
                
                case 1:
                    status[i] = statusR;
                    if (statusR == 2) goodCnt++;
                    break;
                
                case 2:
                    if (statusR >= 1)
                    {
                        status[i] = 2;
                        goodCnt++;
                    }
                    else status[i] = 0;
                    break;
            }
        }

        return goodCnt;
    }
}
