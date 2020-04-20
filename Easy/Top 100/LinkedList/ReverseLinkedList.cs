using System;
using System.Collections.Generic;
using System.Text;
using Easy.Class;

namespace Easy.Top_100.LinkedList
{
    public static class ReverseLinkedList
    {
        public static ListNode reverseList(ListNode head)
        {
            if (head == null)
                return null;

            ListNode result = null;
            while (head != null)
            {
                //save next element of head
                var temp = head.next;
                //point to current result
                head.next = result;
                //move result to current head position
                result = head;
                //head point back to saved next element of head, head = head.next
                head = temp;
            }

            return result;
        }

        //recursive solution
        public static ListNode reverseListRecursive(ListNode head)
        {
            if (head == null || head.next == null) 
                return head;
            ListNode p = reverseList(head.next);
            head.next.next = head;
            head.next = null;
            return p;
        }
    }
}
