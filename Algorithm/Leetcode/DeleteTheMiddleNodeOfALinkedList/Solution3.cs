namespace Leetcode.DeleteTheMiddleNodeOfALinkedList;

//  We can only traverse the linked list once and get previous node of mid and length simultaneously

//  [0, 1, 2, 3, 4, 5]
//  node    n   prevMid
//  1       2   0
//  2       3   0
//  3       4   1
//  4       5   1       
//  5       6   2

//  head.next is null return null
//  node = head.next
//  prevMid = head
//  length = true
//  while (node.next is not null)
//      length = !length
//      node = node.next
//      if (length) prevMid = prevMid.next
//  prevMid.next = prevMid.next.next
//  return head

public class Solution3
{
    public ListNode? DeleteMiddle(ListNode head)
    {
        if (head.next is null) return null;

        ListNode? node = head.next;
        ListNode prevMid = head;
        bool move = true;

        while (node.next is not null)
        {
            move = !move;
            node = node.next;
            if (move) prevMid = prevMid.next!;
        }

        prevMid.next = prevMid.next!.next;

        return head;
    }
}