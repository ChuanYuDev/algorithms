namespace Leetcode.DeleteTheMiddleNodeOfALinkedList;

//  There is no need to have preHead, we can only move to the previous node of mid

//  [1,2,3,4,5]
//  mid = 2
//  node = 1
//  node = 2
//  node.next = node.next.next

//  [2, 1]
//  mid = 1
//  node = 2
//  node.next = node.next.next

//  [1]
//  mid = 0
//  return null
public class LinkedList2
{
    private readonly ListNode _head;
    private int _length;

    public LinkedList2(ListNode head)
    {
        _head = head;
        GetLength();
    }

    public ListNode? DeleteMiddle()
    {
        if (_length == 1) return null;
        
        var mid = _length / 2;
        ListNode node = _head;

        for (var i = 1; i <= mid - 1; i++)
        {
            node = node.next!;
        }

        node.next = node.next!.next;

        return _head;
    }

    private void GetLength()
    {
        ListNode? node = _head;
        var length = 0;

        while (node is not null)
        {
            length++;
            node = node.next;
        }

        _length = length;
    }
}

public class Solution2
{
    public ListNode? DeleteMiddle(ListNode head)
    {
        var linkedList = new LinkedList2(head);

        return linkedList.DeleteMiddle();
    }
}
