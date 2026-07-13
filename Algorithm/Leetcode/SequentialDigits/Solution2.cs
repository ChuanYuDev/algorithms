namespace Leetcode.SequentialDigits;

//  Optimization:
//  1. GenNum can be simplified to get the substring from 123456789

//  start + length -1 <=8
//  start <= 9 - length

public class Solution2
{
    private const string s = "123456789";
        
    public IList<int> SequentialDigits(int low, int high)
    {
        int lowLength = GetLength(low);
        int highLength = GetLength(high);
        var res = new List<int>();

        for (var length = lowLength; length <= highLength; length++)
        {
            var maxStartIdx = 9 - length;
            for (var startIdx = 0; startIdx <= maxStartIdx; startIdx++)
            {
                var num = int.Parse(s.Substring(startIdx, length));
                if (num < low) continue;
                if (num > high) break;
                res.Add(num);
            }
        }

        return res;
    }
    
    private int GetLength(int num) => num.ToString().Length;
}