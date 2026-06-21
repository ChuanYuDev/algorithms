namespace Leetcode.MaximumBuildingHeight;

//  Sort restrictions based on idi
//  The building between two restrictions
//  2,1     4,1
//  id1     id2
//  id1<id<id2
//  height <= maxHeight1 + (id - id1)
//  height <= maxHeight2 + (id2 - id)
//  maxHeight = min(maxHeight1 + (id - id1), maxHeight2 + (id2 - id))

//  id  1 2 3 4 5 6 7 8 9   id  mH
//  mH  0 1 2 3 4 5 6 7 8   1   0
//      0 1 2 2 3 4 5 6 7   4   2 (mH < 3)
//      0 1 2 2 3 4 4 3 2   9   2 (mH < 7)   

//  id  1 2 3 4 5 6 7 8 9
//            2 3 4 4 3 2      
//            2 3 4 5 6 2   
//            2 6 5 4 3 2      

//  id  1 2 3 4 5 6 7 8 9
//            2 3 4 5 4 3
//            2 3 4 5 6 3
//            2 7 6 5 4 3

//  id  1 2 3 4 5 6 7 8 9   id  mH
//      0 1 2 3 4 5 4       7   4 (mH < 3) 4 is redundant maxHeight
//      0 1 2 3 4 4 3 2 1   9   1

//  id  1 2 3 4 5 6 7 8 9
//      0 1 2 3 4 4 3 2 1
//      0 1 2 3 4 5 6 7 1
//      0 8 7 6 5 4 3 2 1

//  Remove redundant maxHeights so that the max height of maxHeighti is maxHeighti
//  id  1 2 3 4 5 6 7 8 9 10
//  mH  0 5     3   4 4 1
//      0       3   4 4    
//      0       3       1      
//
//  1? O
//  3? O [0, 1]
//  4? X [3, 1]
//  4? X [3, 1]
//  5? X [0, 3] 

//  Pseudocode
//  Dictionary map
//      id1 -> maxHeighti
//      O(r)

//  sort restrictions based on maxHeighti
//  9,1
//  5,3
//  7,4 X
//  8,4 X
//  2,5 X
//      O(rlogr)
//  
//  sortedSet ss = [1]
//      O(rlogr)
//      idi
//      1 5 9
//
//  foreach pair in restrictions
//      id = pair[0]
//      maxHeight = pair[1]
//      left = ss.GetViewBetween(1, id).Max
//      right = ss.GetViewBetween(id, n).Min
//      if (right == 0) // no right restriction
//          if (maxHeight >= map[left] + (id - left)) continue
//      else
//          if (maxHeight >= map[left] + (id - left) || maxHeight >= map[right] + (right - id)) continue
//      validR.Add([id, maxHeight])

//  sort remaining restrictions based on idi
//  List<int[]> validR = [[1, 0]]
//  1,0
//  5,3
//  9,1
//
//  maxHeight 
//  id  1 2 3 4 5 6 7 8 9 10
//      0       3       1
//      0 1 2 3 3 4 3 2 1 2
//      O(n)

//  maxHeightResult = MinValue
//  for i from 0 to validR.Length - 2
//      id1 = validR[i][0]
//      maxHeight1 = validR[i][1]
//      id2 = validR[i+1][0]
//      maxHeight2 = validR[i+1][1]
//      maxHeightResult = max(maxHeightResult, maxHeight1)
//      for id from id1 + 1 to id2 - 1
//          maxHeight = min(maxHeight1 + (id - id1), maxHeight2 + (id2 - id))
//          maxHeightResult = max(maxHeightResult, maxHeight)
//
//  idLast = validR[length - 1][0]
//  maxHeightLast = validR[length - 1][1]
//  maxHeight = n - idLast + maxHeightLast
//  maxHeightResult = max(maxHeightResult, maxHeight)
//  return maxHeightResult

//  Time complexity: O(rlogr + n)
//  Space complexity: O(r)

public class Solution
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
            maxHeightResult = Math.Max(maxHeightResult, maxHeight1);

            for (var id = id1 + 1; id <= id2 - 1; id++)
            {
                maxHeight = Math.Min(maxHeight1 + (id - id1), maxHeight2 + (id2 - id));
                maxHeightResult = Math.Max(maxHeightResult, maxHeight);
            }
        }

        var idLast = validR[validRLength - 1][0];
        var maxHeightLast = validR[validRLength - 1][1];
        maxHeight = n - idLast + maxHeightLast;
        maxHeightResult = Math.Max(maxHeightResult, maxHeight);
        return maxHeightResult;
    }
}
