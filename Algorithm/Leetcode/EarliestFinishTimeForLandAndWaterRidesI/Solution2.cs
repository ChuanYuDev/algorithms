namespace Leetcode.EarliestFinishTimeForLandAndWaterRidesI;

//  land: [s1, d1], water [s2, d2]
//      if land first
//      land -> water: s1 -> s1 + d1
//
//      If (s2 < s1 + d1)
//          endTime = s1 + d1 + d2
//
//      If (s1 + d1 <= s2)
//          endTime = s2 + d2
//
//  if land first, endTime = max(s1 + d1, s2) + d2
//      endTime is non-decreasing with regard to s1 + d1 
//      minimize s1 + d1

//  // if land first
//  landEarliestEndTime = int.MaxValue
//  for i from 0 to landLength - 1
//      landFinish = landStartTime[i] + landDuration[i]
//      landEarliestEndTime = Math.Min(landFinish, landEarliestEndTime)
//
//  earliestEndTime = int.MaxValue
//  for j from 0 to waterLength - 1
//      endTime = Math.Max(landFinish, waterStartTime[j]) + waterDuration[j]
//      earliestEndTime = Math.Min(earliestEndTime, endTime)
//
//  return earliestEndTime

public class Solution2
{
    private int GetEarliestEndTime(int[] ride1StartTime, int[] ride1Duration, int[] ride2StartTime, int[] ride2Duration)
    {
        var ride1EarliestEndTime = int.MaxValue;

        for (var i = 0; i <= ride1StartTime.Length - 1; i++)
        {
            var ride1EndTime = ride1StartTime[i] + ride1Duration[i];
            ride1EarliestEndTime = Math.Min(ride1EndTime, ride1EarliestEndTime);
        }

        var earliestEndTime = int.MaxValue;

        for (var j = 0; j <= ride2StartTime.Length - 1; j++)
        {
            var endTime = Math.Max(ride1EarliestEndTime, ride2StartTime[j]) + ride2Duration[j];
            earliestEndTime = Math.Min(earliestEndTime, endTime);
        }

        return earliestEndTime;
    }
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
    {
        var landFirstEarliestEndTime = GetEarliestEndTime(landStartTime, landDuration, waterStartTime, waterDuration);
        var waterFirstEarliestEndTime = GetEarliestEndTime(waterStartTime, waterDuration, landStartTime, landDuration);
        return Math.Min(landFirstEarliestEndTime, waterFirstEarliestEndTime);
    }
}