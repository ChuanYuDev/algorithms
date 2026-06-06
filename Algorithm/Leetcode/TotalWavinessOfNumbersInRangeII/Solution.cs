namespace Leetcode.TotalWavinessOfNumbersInRangeII;

// The same solution as I is not working because of the scale of parameters
// Time Limit Exceeded

public class Solution
{
    public long TotalWaviness(long num1, long num2)
    {
        long waviness = 0;

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
