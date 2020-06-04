using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.LinkedList
{
    public class Merge_Sort_LinkedList
    {
        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode endOfLeft = head, fast = head, slow = head;

            while (fast != null && fast.next != null)
            {
                //endOfLeft will be one step slower then slow
                endOfLeft = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            //create a new end of left list
            endOfLeft.next = null;

            var left = SortList(head);
            var right = SortList(slow);

            return MergeSort(left, right);
        }




        public ListNode MergeSort(ListNode l1, ListNode l2)
        {
            ListNode l3, result = new ListNode(0);
            l3 = result;
            while (l1 != null & l2 != null)
            {
                if (l1.val < l2.val)
                {
                    l3.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    l3.next = l2;
                    l2 = l2.next;
                }
                //l3 pointer move fwd
                l3 = l3.next;
            }
            if (l1 == null)
                l3.next = l2;
            if (l2 == null)
                l3.next = l1;
            return result.next;
        }
    }
}
