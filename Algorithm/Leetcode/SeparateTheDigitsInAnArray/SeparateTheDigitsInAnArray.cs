namespace Leetcode.SeparateTheDigitsInAnArray;

//  Given an array of positive integers nums, return an array answer that consists of the digits of each integer in nums after separating them in the same order they appear in nums.
//  To separate the digits of an integer is to get all the digits it has in the same order.
//  For example, for the integer 10921, the separation of its digits is [1,0,9,2,1].

public class Solution
{
    public int[] SeparateDigits(int[] nums)
    {
        List<int> answerList = new List<int>();
        
        var length = nums.Length;
        
        for (var i = 0; i < length; i++)
        {
            var num = nums[length - 1 - i];

            while (num > 0)
            {
                answerList.Add(num % 10);
                num /= 10;
            }
        }

        answerList.Reverse();

        return answerList.ToArray();
    }
}

public class SeparateTheDigitsInAnArray
{
    static void Main()
    {
        Solution sol = new Solution();

        int[] nums = [13, 25, 83, 77];

        int[] answer = sol.SeparateDigits(nums);

        foreach (var element in answer)
        {
            Console.Write(element);
            Console.Write(" ");
        }
        
        Console.WriteLine();
        // Output: [1,3,2,5,8,3,7,7]
    }
}