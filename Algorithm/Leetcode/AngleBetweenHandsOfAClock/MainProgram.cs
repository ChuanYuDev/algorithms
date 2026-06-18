namespace Leetcode.AngleBetweenHandsOfAClock;

//  Angle Between Hands of a Clock
//  Medium
//  Given two numbers, hour and minutes, return the smaller angle (in degrees) formed between the hour and the minute hand.
//
//  Answers within 10^-5 of the actual value will be accepted as correct.
//
// `Example 1:
//  Input: hour = 12, minutes = 30
//  Output: 165
//
//  Example 2:
//  Input: hour = 3, minutes = 30
//  Output: 75
//
//  Example 3:
//  Input: hour = 3, minutes = 15
//  Output: 7.5
//  
//  Constraints:
//      1 <= hour <= 12
//      0 <= minutes <= 59

//  Angle between 0 and minute hand
//  angleMinute = 360 / 60 * minutes

//  Angle between 12 and hour hand
//  if (hour = 12), hour -= 12
//  angleHour = 360 / 12 * (hour + minutes/60)

//  angle = Math.Abs(angleMinute - angleHour)
//  return Math.Min(angle, 360 - angle)

public class Solution
{
    public double AngleClock(int hour, int minutes)
    {
        var angleMinute = (double)360 / 60 * minutes;

        if (hour == 12) hour -= 12;
        var angleHour = (double)360 / 12 * (hour + (double)minutes / 60);
        var angle = Math.Abs(angleHour - angleMinute);

        return Math.Min(angle, 360 - angle);
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();
        int hour = 12, minutes = 30;
        Console.WriteLine(sol.AngleClock(hour, minutes));
        //  Output: 165

        hour = 3; 
        minutes = 30;
        Console.WriteLine(sol.AngleClock(hour, minutes));
        //  Output: 75

        hour = 3;
        minutes = 15;
        Console.WriteLine(sol.AngleClock(hour, minutes));
        //  Output: 7.5
    }
}