namespace Leetcode.MaximumBuildingHeight;

//  Optimization
//  1. To get the valid restriction, we don't need to remove them, we can change their values
//  2. We need to consider the restrictions on the left, we can simply do one pass from left to right and change the invalid restrictions' value
//  3. The same process applies to the right restrictions

//  id  1 2 3 4 5 6 7 8 9 10
//  mH  0 5     3   4 4 1
//      0 1     3   4 4 1 2
//      0 1     3   3 2 1 2

public class Solution3
{
    private List<int[]> ValidateRestrictions(int n, int[][] restrictions)
    {
        List<int[]> validRs = [[1, 0]];
        Array.Sort(restrictions, (x, y) => x[0].CompareTo(y[0]));
        validRs.AddRange(restrictions);

        var rLength = validRs.Count;

        for (var i = 1; i <= rLength - 1; i++)
        {
            var idLeft = validRs[i - 1][0];
            var mHLeft = validRs[i - 1][1];
            var id = validRs[i][0];
            var mH = validRs[i][1];
            validRs[i][1] = Math.Min(mH, mHLeft + (id - idLeft));
        }

        var idLast = validRs[rLength - 1][0];
        var mHLast = validRs[rLength - 1][1];
        if (idLast != n)
        {
            validRs.Add([n, mHLast + n - idLast]);
        }
        
        for (var i = validRs.Count - 2; i >= 1; i--)
        {
            var idRight = validRs[i + 1][0];
            var mHRight = validRs[i + 1][1];
            var id = validRs[i][0];
            var mH = validRs[i][1];
            validRs[i][1] = Math.Min(mH, mHRight + (idRight - id));
        }
        
        return validRs;
    }
    public int MaxBuilding(int n, int[][] restrictions)
    {
        var validRs = ValidateRestrictions(n, restrictions);
        var rLength = validRs.Count;
        var maxHeightResult = int.MinValue;
        var maxHeight = 0;

        for (var i = 0; i <= rLength - 2; i++)
        {
            var id1 = validRs[i][0];
            var maxHeight1 = validRs[i][1];
            var id2 = validRs[i + 1][0];
            var maxHeight2 = validRs[i + 1][1];
            maxHeight = (maxHeight2 + id2 - id1 + maxHeight1) / 2;
            maxHeightResult = Math.Max(maxHeightResult, maxHeight);
        }

        return maxHeightResult;
    }
}
