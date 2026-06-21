namespace Leetcode.MaximumBuildingHeight;

//  Optimization
//  1. No need to calculate maxHeight one by one, based on the following analysis, we can get mH directly from the restrictions

//  Formula
//  id1 mH1
//  id2 mH2

//  id  1 2 3 4 5 6 7 8 9 10
//      0 1 2 3 4 4 3
//
// id in [id1,id2]
//  mH = min(mH1 + (id - id1), mH2 + (id2 - id))
//  id = id1, mH = min(mH1, mH2 + id2 - id1) = mH1
//  id = id2, mH = mH2
//
//  mH1 + id -id1 = mH2 + id2 - id 
//  id = (mH2 + id2 + id1 - mH1 / 2)
//  mH = mH1 + id - id1 = (mH2 + id2 - id1 + mH1 / 2)
//  
//  id in [1,7]
//  mH = (3+7-1+0)/2 = 4

//  Time complexity: O(rlogr)
//  Space complexity: O(r)

public class Solution2
{
    private List<int[]> GetValidRestrictions(int n, int[][] restrictions)
    {
        List<int[]> validR = [[1, 0]];
        SortedSet<int> ss = [1];
        var map = new Dictionary<int, int>
        {
            [1] = 0
        };
        
        Array.Sort(restrictions, (x, y) => x[1].CompareTo(y[1]));

        foreach (var restriction in restrictions)
        {
            var id = restriction[0];
            var maxHeight = restriction[1];
            var leftId = ss.GetViewBetween(1, id).Max;
            var rightId = ss.GetViewBetween(id, n).Min;
            
            if (maxHeight >= map[leftId] + (id - leftId)) continue;
            
            if (rightId != 0)
            {
                if (maxHeight >= map[rightId] + (rightId - id)) continue;
            }
            
            validR.Add([id, maxHeight]);
            ss.Add(id);
            map[id] = maxHeight;
        }

        return validR;
    }
    public int MaxBuilding(int n, int[][] restrictions)
    {
        var validR = GetValidRestrictions(n, restrictions);
        var validRLength = validR.Count;
        validR.Sort((x, y) => x[0].CompareTo(y[0]));
        var maxHeightResult = int.MinValue;
        var maxHeight = 0;

        for (var i = 0; i <= validRLength - 2; i++)
        {
            var id1 = validR[i][0];
            var maxHeight1 = validR[i][1];
            var id2 = validR[i + 1][0];
            var maxHeight2 = validR[i + 1][1];
            maxHeight = (maxHeight2 + id2 - id1 + maxHeight1) / 2;
            maxHeightResult = Math.Max(maxHeightResult, maxHeight);
        }

        var idLast = validR[validRLength - 1][0];
        var maxHeightLast = validR[validRLength - 1][1];
        maxHeight = n - idLast + maxHeightLast;
        maxHeightResult = Math.Max(maxHeightResult, maxHeight);
        return maxHeightResult;
    }
}

