namespace Leetcode.TrappingRainWater;

//  Fix:
//  1. SolutionWrong doesn't take the following case into account
//      block 3 should be ignored because 4 and 5 are larger than it
//
//  idx:    0 1 2 3 4 5
//  height: 4 2 0 3 2 5
//  peak:   4     3   5
//  
//  lIdx    rIdx    lHeight rHeight maxWater    block   water
//  0       5       4       5       16          7       9

//  Runtime 16 ms, Beats 5.07%
//  Memory 49.95 MB, Beats 5.18%

//  Time complexity:
//      Find peaks and save them into sortedDictionary: O(nlogn)
//      Selected the largest peak and calculate water: O(nlogn)
//      Total: O(nlogn)

//  Space complexity:
//      sortedDictionary: O(n)
//      Total: O(n)

//  Sorted dictionary
//  idx, peak
//  peak large -> small
//  if peak is the same, index small -> large

/*
private List<int> _height = [];

int Trap(int[] height)
    _height = new List<int>(height) {0}
    sortedPeaks = new sortedDictionary<int, int>(CustomComparer) 
    isPrevIncrease = true

    for i from 0 to n - 1
        isIncrease = _height[i] <= _height[i + 1];
        if (isPrevIncrease && !isIncrease)
            sortedPeaks.Add(new KeyValuePair<int, int>(i, _height[i]))

        isPrevIncrease = isIncrease
        
    cnt = 0
    lIdx, rIdx = 0
    water = 0
   
    foreach (sP in sortedPeaks)
        cnt++
        if (cnt == 1)
            lIdx = sP.Key
            continue
     
        if (cnt == 2)
            if (sP.Key > lIdx) rIdx = sP.Key
            else (lIdx, rIdx) = (sP.Key, lIdx)
            water += Trap(lIdx, rIdx)
        
        if (cnt >= 3)
            if (sp.Key < lIdx)
                water += Trap(sp.Key, lIdx)
                lIdx = sp.Key
                continue
                
            if (sp.Key > rIdx)
                water += Trap(rIdx, sp.Key)
                rIdx = sp.Key
                
    return water
   
int Trap(lIdx, rIdx)
    lHeight = _height[lIdx]
    rHeight = _height[rIdx]
    minHeight = min(lHeight, rHeight)
    maxWater = minHeight * (rIdx - lIdx - 1)
    blocks = 0

    for j from lIdx + 1 to rIdx - 1
        blocks += min(_height[j], minHeight)

    return maxWater - blocks
*/

public class CustomComparer2 : IComparer<KeyValuePair<int, int>>
{
    public int Compare(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
    {
        var valueCompare = x.Value.CompareTo(y.Value);

        if (valueCompare != 0) return -valueCompare;
        
        return x.Key.CompareTo(y.Key);
    }
}

public class Solution2
{
    private List<int> _heights = [];
    
    public int Trap(int[] height)
    {
        _heights = [..height, 0];
        var sortedPeaks = new SortedSet<KeyValuePair<int, int>>(new CustomComparer2());
        var isPrevIncrease = true;
        var length = height.Length;
        
        for (var i = 0; i <= length - 1; i++)
        {
            var isIncrease = _heights[i] <= _heights[i + 1];

            if (isPrevIncrease && !isIncrease) sortedPeaks.Add(new KeyValuePair<int, int>(i, _heights[i]));

            isPrevIncrease = isIncrease;
        }

        var cnt = 0;
        int lIdx = 0, rIdx = 0;
        var water = 0;

        foreach (var sortedPeak in sortedPeaks)
        {
            cnt++;
            var idx = sortedPeak.Key;

            switch (cnt)
            {
                case 1:
                    lIdx = idx;
                    break;
                
                case 2:
                    if (sortedPeak.Key > lIdx) rIdx = sortedPeak.Key;
                    else (lIdx, rIdx) = (idx, lIdx);

                    water += Trap(lIdx, rIdx);
                    break;
                
                default:
                    if (idx < lIdx)
                    {
                        water += Trap(idx, lIdx);
                        lIdx = idx;
                        continue;
                    }

                    if (idx > rIdx)
                    {
                        water += Trap(rIdx, idx);
                        rIdx = idx;
                    }
                    
                    break;
            }
        }
        
        return water;
    }
    
    private int Trap(int lIdx, int rIdx)
    {
        var lHeight = _heights[lIdx];
        var rHeight = _heights[rIdx];
        var minHeight = Math.Min(lHeight, rHeight);
        var maxWater = minHeight * (rIdx - lIdx - 1);
        
        var block = 0;
        for (var j = lIdx + 1; j <= rIdx - 1; j++) block += Math.Min(_heights[j], minHeight);

        return maxWater - block;
    }
}
