namespace Leetcode.DeleteTheMiddleNodeOfALinkedList;

//  [1,3,4,7,1,2,6]
//  n = 7
//  mid = 3
//  node = 1
//  1

//  Time complexity
//      O(n)
//  Space complexity
//      O(1)

//  LinkedList
//  private head
//  private prevHead
//  private _n = 0
//  Constructor(head)
//      Head = head
//      preHead = new ListNode(0, Head)
//
//  GetLength()
//      node = Head
//      length = 0
//      while(node is not null)
//          length++
//          node = node.next
//      _n = length
//      
//  DeleteMiddle()
//      mid = _n / 2
//      node = Head
//      prevNode = preHead
//      for i from 1 to mid
//          node = node.next
//          prevNode = prevNode.next
//      
//      prevNode.next = node.next
//      return preHead.next

public class LinkedList
{
    private readonly ListNode _head;
    private readonly ListNode _prevHead;
    private int _length;

    public LinkedList(ListNode head)
    {
        _head = head;
        _prevHead = new ListNode(0, _head);
        GetLength();
    }

    public ListNode? DeleteMiddle()
    {
        var mid = _length / 2;
        ListNode node = _head, prevNode = _prevHead;

        for (var i = 1; i <= mid; i++)
        {
            node = node.next!;
            prevNode = prevNode.next!;
        }

        prevNode.next = node.next;
        return _prevHead.next;
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

public class Solution
{
    public ListNode? DeleteMiddle(ListNode head)
    {
        var linkedList = new LinkedList(head);

        return linkedList.DeleteMiddle();
    }
}
