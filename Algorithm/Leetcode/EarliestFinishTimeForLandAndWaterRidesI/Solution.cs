namespace Leetcode.EarliestFinishTimeForLandAndWaterRidesI;

//  landStartTime = [2,8], landDuration = [4,1], waterStartTime = [6], waterDuration = [3]
//  land: [2, 4], [8, 1]
//  water: [6, 3]

//  land: [i1, d1], water [i2, d2], i1 <= i2
//  If (i2 < i1 + d1)
//      land -> water: i1 -> i1 + d1 -> i1 + d1 + d2 Wins
//      water -> land: i2 -> i2 + d2 -> i2 + d1 + d2
//  If (i1 + d1 <= i2)
//      land -> water: i1 -> i1 + d1 -> i2 -> i2 + d2 Wins
//      water -> land: i2 -> i2 + d2 -> i2 + d1 + d2
//
//  If i1 <= i2, i1 ride first

//  land 0 -> water 0: 9
//  Test following water 1, water 2 ... until wateri >= 9
//  land 0 finish
//  Compare land 1 with water 0

//  landLength = landStartTime.length
//  int[][] land = new int[landLength][]
//  for i from 0 to landLength - 1
//      land[i][0] = landStartTime[i]
//      land[i][1] = landDuration[i]
//
//  // Sort land based on land[i][0] and land[i][1]
//  Array.sort(land, (array1, array2) =>
//      {
//          compareResult = array1[0].CompareTo(array2[0])
//          return compareResult != 0?: compareResult: array1[1].CompareTo(array2[1])
//      }
//  )
//
//  // DO the same thing to water
//  earliestEndTime = int.MaxValue
//  for m from 0 to landLength - 1
//      for n from 0 to waterLength - 1
//          if (water[m][0] >= earliestEndTime) break
//          if (land[m][0] <= water[n][0])
//              ride1 = land[m]
//              ride2 = water[n]
//          else
//              ride1 = water[n]
//              ride2 = land[m]
//
//          if (ride2[0] < ride1[0] + ride1[1]) endTime = ride1[0] + ride1[1] + ride2[1]
//          else endTime = ride2[0] + ride2[1]
//          earliestEndTime = Math.Min(endTime, earliestEndTime)
//
//      if(land[m][0] >= earliestEndTime) break
//
//  return earliestEndTime

//  Time complexity
//      O(nm)
//  Space complexity
//      O(m + n)


public class Solution
{
    private int[][] GetRide(int[] startTime, int[] duration)
    {
        var length = startTime.Length;
        int[][] ride = new int[length][];

        for (var i = 0; i <= length - 1; i++)
        {
            ride[i] = [startTime[i], duration[i]];
        }

        return ride;
    }
    
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
    {
        Comparison<int[]> comparison = (land1, land2) =>
        {
            var compareResult = land1[0].CompareTo(land2[0]);
            return (compareResult != 0) ? compareResult : land1[1].CompareTo(land2[1]);
        };
        
        var land = GetRide(landStartTime, landDuration);
        Array.Sort(land, comparison);

        var water = GetRide(waterStartTime, waterDuration);
        Array.Sort(water, comparison);

        var earliestEndTime = int.MaxValue;

        for (var m = 0; m <= landStartTime.Length - 1; m++)
        {
            for (var n = 0; n <= waterStartTime.Length - 1; n++)
            {
                if (water[n][0] >= earliestEndTime) break;

                int[] ride1, ride2;

                if (land[m][0] <= water[n][0])
                {
                    ride1 = land[m];
                    ride2 = water[n];
                }
                else
                {
                    ride1 = water[n];
                    ride2 = land[m];
                }

                int endTime;
                if (ride2[0] < ride1[0] + ride1[1]) endTime = ride1[0] + ride1[1] + ride2[1];
                else endTime = ride2[0] + ride2[1];

                earliestEndTime = Math.Min(endTime, earliestEndTime);
            }

            if (land[m][0] >= earliestEndTime) break;
        }
        return earliestEndTime;
    }
}
