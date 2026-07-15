namespace Leetcode.TrappingRainWater;

//  This solution is wrong, refer to Solution2

//  maxWater = min(lHeight, rHeight) * (rIdx - lIdx - 1)
//  block = min(block, min(lHeight, rHeight))

//  idx:    0 1 2 3 4 5 6 7 8 9 0 1
//  height: 0 1 0 2 1 0 1 3 2 1 2 1
//  peak:     1   2       3     2
//
//  lIdx    rIdx    lHeight rHeight maxWater    block   water
//  1       3       1       2       1           0       1
//  3       7       2       3       6           2       4
//  7       10      3       2       4           3       1

//  Time complexity:
//      Find peak: O(n)
//      Calculate water: O(n)
//      Total: O(n)

//  Space complexity:
//      O(1)

//  isPrevIncrease = true
//  prevPeakIdx = -1
//  water = 0
//  var heightList = new List<int>(height)
//  heightList.Add(0)
//
//  for i from 0 to n - 1
//      isIncrease = (height[i] <= height[i + 1]) ? true: false;
//      if (isPrevIncrease && !isIncrease)
//          peakIdx = i
//
    //      if (prevPeakIdx != -1)
    //          lIdx = prevPeakIdx
    //          lHeight = height[lIdx]
    //          rIdx = peakIdx
    //          rHeight = height[rIdx]
    //          minHeight = min(lHeight, rHeight)
    //          maxWater = minHeight * (rIdx - lIdx - 1)
    //          block = 0
    //          for j from lIdx + 1 to rIdx - 1
    //              block += min(height[j], minHeight)
    //          water += maxWater - block
//
    //      prevPeakIdx = peakIdx
//
//      isPrevIncrease = isIncrease

public class SolutionWrong
{
    private List<int> _height = [];
    
    public int Trap(int[] height)
    {
        var isPrevIncrease = true;
        var prevPeakIdx = -1;
        var length = height.Length;

        _height = [..height, 0];
        
        var water = 0;

        for (var i = 0; i <= length - 1; i++)
        {
            var isIncrease = _height[i] <= _height[i + 1];

            if (isPrevIncrease && !isIncrease)
            {
                if (prevPeakIdx != -1) water += Trap(prevPeakIdx, i);

                prevPeakIdx = i;
            }

            isPrevIncrease = isIncrease;
        }
        
        return water;
    }
    
    private int Trap(int lIdx, int rIdx)
    {
        var lHeight = _height[lIdx];
        var rHeight = _height[rIdx];
        var minHeight = Math.Min(lHeight, rHeight);
        var maxWater = minHeight * (rIdx - lIdx - 1);
        
        var block = 0;
        for (var j = lIdx + 1; j <= rIdx - 1; j++) block += Math.Min(_height[j], minHeight);

        return maxWater - block;
    }
}