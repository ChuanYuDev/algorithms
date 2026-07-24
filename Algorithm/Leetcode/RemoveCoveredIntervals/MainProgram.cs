namespace Leetcode.RemoveCoveredIntervals;

/*
Remove Covered Intervals
Medium

Given an array intervals where intervals[i] = [li, ri] represent the interval [li, ri), remove all intervals that are covered by another interval in the list.

The interval [a, b) is covered by the interval [c, d) if and only if c <= a and b <= d.

Return the number of remaining intervals.

Example 1:
Input: intervals = [[1,4],[3,6],[2,8]]
Output: 2
Explanation: Interval [3,6] is covered by [2,8], therefore it is removed.

Example 2:
Input: intervals = [[1,4],[2,3]]
Output: 1

Constraints:
    1 <= intervals.length <= 1000
    intervals[i].length == 2
    0 <= li < ri <= 10^5
    All the given intervals are unique.
*/

/*
Input: intervals = [[1,4],[3,6],[2,8]]
Output: 2

x:  0 1 2 3 4 5 6 7 8 9 0
      1     4
          3     6 
        2           8
        
x:  0 1 2 3 4 5 6 7 8 9 0
      1         6
        2       6
          3     6 

Sort intervals
    intervals[i][0] small -> large
    intervals[i][1] large -> small
   
After sorting, the key step is if (intervals[i-1][1] >= intervals[i][1]), intervals[i][1] = intervals[i-1][1]
    So that intervals[j][1] <= intervals[i][1], j < i 
    
    In this case, we only need to compare with the previous interval
    
if (intervals[i-1][1] < intervals[i][1])
    Because intervals[i-1][1] >= intervals[j][1], j <= i-1 
    The intervals[j] cannot cover i, j < i
    
if (intervals[i-1][1] >= intervals[i][1])
    Interval i is covered by modified i-1, but we can find the real interval before i-1
*/

/* Pseudocode
Sort intervals

result = 0 
if (intervals[i-1][1] < intervals[i][1])
    result++    
else
    intervals[i][1] = intervals[i-1][1]

return result
*/

/* Complexity
Time complexity: O(nlogn)
Space complexity: O(1)
*/

public class Solution
{
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (interval1, interval2) =>
        {
            var compareX = interval1[0].CompareTo(interval2[0]);

            if (compareX != 0) return compareX;

            return -interval1[1].CompareTo(interval2[1]);
        });

        var result = 1;
        
        for (var i = 1; i <= intervals.Length - 1; i++)
        {
            if (intervals[i - 1][1] < intervals[i][1]) result++;
            else intervals[i][1] = intervals[i - 1][1];
        }

        return result;
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        int[][] intervals = [[1, 4], [3, 6], [2, 8]];
        Console.WriteLine(sol.RemoveCoveredIntervals(intervals));
        // Output: 2

        intervals = [[1, 4], [2, 3]];
        Console.WriteLine(sol.RemoveCoveredIntervals(intervals));
        // Output: 1
    }
}