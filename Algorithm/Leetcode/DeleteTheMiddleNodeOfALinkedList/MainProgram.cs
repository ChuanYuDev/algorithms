namespace Leetcode.DeleteTheMiddleNodeOfALinkedList;
//  Delete the Middle Node of a Linked List
//  Medium
//
//  You are given the head of a linked list.
//  Delete the middle node, and return the head of the modified linked list.
//
//  The middle node of a linked list of size n is the ⌊n / 2⌋th node from the start using 0-based indexing, where ⌊x⌋ denotes the largest integer less than or equal to x.
//  For n = 1, 2, 3, 4, and 5, the middle nodes are 0, 1, 1, 2, and 2, respectively.
//  
//  Example 1:
//  Input: head = [1,3,4,7,1,2,6]
//  Output: [1,3,4,1,2,6]
//
//  Example 2:
//  Input: head = [1,2,3,4]
//  Output: [1,2,4]
//
//  Input: head = [2,1]
//  Output: [2]
//
//  Constraints:
//      The number of nodes in the list is in the range [1, 10^5].
//      1 <= Node.val <= 10^5

// Definition for singly-linked list.
public class ListNode
{ 
    public int val;
    public ListNode? next; 
    public ListNode(int val=0, ListNode? next=null)
    { 
        this.val = val; 
        this.next = next; 
    }
}

public static class LinkedListHelper
{
    public static ListNode ConstructLinkedList(int[] nums)
    {
        var length = nums.Length;
        if (length == 0) throw new InvalidOperationException("Array length is 0");

        var head = new ListNode(nums[0]);
        ListNode node = head;

        for (var i = 1; i <= length - 1; i++)
        {
            node.next = new ListNode(nums[i]);
            node = node.next;
        }

        return head;
    }

    public static void PrintLinkedList(ListNode? head)
    {
        Console.WriteLine("Linked list is:");
        var node = head;
        while (node is not null)
        {
            Console.Write($"{node.val} ");
            node = node.next;
        }
        Console.WriteLine();
    }
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution3();
        int[] nums = [1, 3, 4, 7, 1, 2, 6];
        var head = LinkedListHelper.ConstructLinkedList(nums);
        LinkedListHelper.PrintLinkedList(sol.DeleteMiddle(head));
        //  Output: [1,3,4,1,2,6]

        nums = [1, 2, 3, 4];
        head = LinkedListHelper.ConstructLinkedList(nums);
        LinkedListHelper.PrintLinkedList(sol.DeleteMiddle(head));
        //  Output: [1,2,4]
        
        nums = [2, 1];
        head = LinkedListHelper.ConstructLinkedList(nums);
        LinkedListHelper.PrintLinkedList(sol.DeleteMiddle(head));
        //  Output: [2]
    }
}