namespace Leetcode.MaximumTwinSumOfALinkedList;

//  Maximum Twin Sum of a Linked List
//  Medium
//
//  In a linked list of size n, where n is even, the ith node (0-indexed) of the linked list is known as the twin of the (n-1-i)th node, if 0 <= i <= (n / 2) - 1.
//  For example, if n = 4, then node 0 is the twin of node 3, and node 1 is the twin of node 2.
//  These are the only nodes with twins for n = 4.
//  The twin sum is defined as the sum of a node and its twin.
//
//  Given the head of a linked list with even length, return the maximum twin sum of the linked list.
//
//  Example 1:
//  Input: head = [5,4,2,1]
//  Output: 6
//
//  Example 2:
//  Input: head = [4,2,2,3]
//  Output: 7
//
//  Example 3:
//  Input: head = [1,100000]
//  Output: 100001
//
//  Constraints:
//  The number of nodes in the list is an even integer in the range [2, 10^5].
//  1 <= Node.val <= 10^5

//  idx 0 1 2 3 4 5
//      4,2,2,3,1,2

//  Find prevMid 
//  node    prevMid
//  1       0
//  3       1
//  5       2

//  Reverse second half
//  prevNode    node    nextNode
//              3       4
//
//  3           4       5
//  4           5       null

//  idx 0 1
//      4,2
//  prevMid = 0
//  prevNode    node    nextNode
//              1       null
//  

//  Time complexity
//      O(n)
//  Space complexity
//      O(1)

//  // Find prevMid 
//  node = head.next
//  prevMid = head
//  while(node.next is not null)
//      node = node.next.next
//      prevMid = prevMid.next
//
//  // Reverse second half
//  node = prevMid.next
//  nextNode = node.next
//  node.next = null
//  while(nextNode is not null)
//      prevNode = node
//      node = nextNode
//      nextNode = node.next
//      node.next = prevNode
//
//  // Maximum value
//  node1 = head
//  node2 = node
//  value = int.MinValue
//  while (node1 is not null)
//      value = Math.Max(value, node1.val + node2.val)
//      node1 = node1.next
//      node2 = node2.next
//  return value


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

public class Solution
{
    public int PairSum(ListNode head)
    {
        // Find prevMid
        ListNode? node = head.next!;
        ListNode prevMid = head;

        while (node!.next is not null)
        {
            node = node.next.next;
            prevMid = prevMid.next!;
        }
        
        // Reverse second half
        node = prevMid.next;
        prevMid.next = null;
        var nextNode = node!.next;
        node.next = null;
        ListNode prevNode;
        while (nextNode is not null)
        {
            prevNode = node;
            node = nextNode;
            nextNode = node.next;
            node.next = prevNode;
        }
        
        // Maximum value
        ListNode? node1 = head;
        ListNode? node2 = node;
        var value = int.MinValue;
        while (node1 is not null)
        {
            value = Math.Max(value, node1.val + node2!.val);
            node1 = node1.next;
            node2 = node2.next;
        }

        return value;
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
}

public class MainProgram
{
    static void Main()
    {
        var sol = new Solution();

        int[] nums = [5, 4, 2, 1];
        var head = LinkedListHelper.ConstructLinkedList(nums);
        Console.WriteLine(sol.PairSum(head));
        // Output: 6

        nums = [4, 2, 2, 3];
        head = LinkedListHelper.ConstructLinkedList(nums);
        Console.WriteLine(sol.PairSum(head));
        // Output: 7

        nums = [1, 100000];
        head = LinkedListHelper.ConstructLinkedList(nums);
        Console.WriteLine(sol.PairSum(head));
        // Output: 100001
    }
}