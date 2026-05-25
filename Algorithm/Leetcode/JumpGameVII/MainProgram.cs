namespace Leetcode.JumpGameVII;
//  Jump Game VII
//  Medium
//
//  You are given a 0-indexed binary string s and two integers minJump and maxJump.
//  In the beginning, you are standing at index 0, which is equal to '0'.
//
//  You can move from index i to index j if the following conditions are fulfilled:
//      i + minJump <= j <= min(i + maxJump, s.length - 1), and
//      s[j] == '0'.
//
//  Return true if you can reach index s.length - 1 in s, or false otherwise.
//
//  Example 1:
//  Input: s = "011010", minJump = 2, maxJump = 3
//  Output: true
//
//  Example 2:
//  Input: s = "01101110", minJump = 2, maxJump = 3
//  Output: false
//
//  Constraints:
//      2 <= s.length <= 10^5
//      s[i] is either '0' or '1'.
//      s[0] == '0'
//      1 <= minJump <= maxJump < s.length

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution3();

        string s = "011010";
        int minJump = 2, maxJump = 3;
        Console.WriteLine(sol.CanReach(s, minJump, maxJump));
        //  Output: true

        s = "01101110";
        minJump = 2;
        maxJump = 3;
        Console.WriteLine(sol.CanReach(s, minJump, maxJump));
        //  Output: false
        
        s = "0100110";
        minJump = 2;
        maxJump = 3;
        Console.WriteLine(sol.CanReach(s, minJump, maxJump));
        //  Output: true

        s = "00111010";
        minJump = 3;
        maxJump = 5;
        Console.WriteLine(sol.CanReach(s, minJump, maxJump));
        //  Output: false
    }
}