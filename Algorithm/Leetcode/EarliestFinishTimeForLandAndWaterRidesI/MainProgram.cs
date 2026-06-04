namespace Leetcode.EarliestFinishTimeForLandAndWaterRidesI;

//  Earliest Finish Time for Land and Water Rides I
//  Easy
//  You are given two categories of theme park attractions: land rides and water rides.
//
//  Land rides
//  landStartTime[i] – the earliest time the ith land ride can be boarded.
//  landDuration[i] – how long the ith land ride lasts.
//
//  Water rides
//  waterStartTime[j] – the earliest time the jth water ride can be boarded.
//  waterDuration[j] – how long the jth water ride lasts.
//
//  A tourist must experience exactly one ride from each category, in either order.
//
//  A ride may be started at its opening time or any later moment.
//  If a ride is started at time t, it finishes at time t + duration.
//  Immediately after finishing one ride the tourist may board the other (if it is already open) or wait until it opens.
//
//  Return the earliest possible time at which the tourist can finish both rides.
//
//  Example 1:
//  Input: landStartTime = [2,8], landDuration = [4,1], waterStartTime = [6], waterDuration = [3]
//  Output: 9
//
//  Example 2:
//  Input: landStartTime = [5], landDuration = [3], waterStartTime = [1], waterDuration = [10]
//  Output: 14
//
//  Constraints:
//      1 <= n, m <= 100
//      landStartTime.length == landDuration.length == n
//      waterStartTime.length == waterDuration.length == m
//      1 <= landStartTime[i], landDuration[i], waterStartTime[j], waterDuration[j] <= 1000

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution2();
        int[] landStartTime = [2, 8], landDuration = [4, 1], waterStartTime = [6], waterDuration = [3];
        Console.WriteLine(sol.EarliestFinishTime(landStartTime, landDuration, waterStartTime, waterDuration));
        //  Output: 9

        landStartTime = [5];
        landDuration = [3];
        waterStartTime = [1];
        waterDuration = [10];
        Console.WriteLine(sol.EarliestFinishTime(landStartTime, landDuration, waterStartTime, waterDuration));
        //  Output: 14
    }
}