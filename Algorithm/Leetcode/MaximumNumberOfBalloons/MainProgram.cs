namespace Leetcode.MaximumNumberOfBalloons;

//  Maximum Number of Balloons
//  Easy
//
//  Given a string text, you want to use the characters of text to form as many instances of the word "balloon" as possible.
//  You can use each character in text at most once.
//  Return the maximum number of instances that can be formed.
//
//  Example 1:
//  Input: text = "nlaebolko"
//  Output: 1
//
//  Example 2:
//  Input: text = "loonbalxballpoon"
//  Output: 2
//
//  Example 3:
//  Input: text = "leetcode"
//  Output: 0
//
//  Constraints:
//      1 <= text.length <= 10^4
//      text consists of lower case English letters only.
//
//  Note: This question is the same as 2287: Rearrange Characters to Make Target String.

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution2();
        var text = "nlaebolko";
        Console.WriteLine(sol.MaxNumberOfBalloons(text));
        //  Output: 1

        text = "loonbalxballpoon";
        Console.WriteLine(sol.MaxNumberOfBalloons(text));
        //  Output: 2

        text = "leetcode";
        Console.WriteLine(sol.MaxNumberOfBalloons(text));
        //  Output: 0

        text = "lloo";
        Console.WriteLine(sol.MaxNumberOfBalloons(text));
        //  Output: 0
    }
}