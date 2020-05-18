using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.LinkedList
{
    class Remove_Nth_Node_From_End_of_List
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //to remove the Nth Node from the end
            //we need to reach one node before, which is N+1 th from the end
            //so we start from a node before head.
            var result = new ListNode(0);
            result.next = head;
            var fast = result;
            var slow = result;

            while (n-- > 0)
                fast = fast.next;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next;
            }

            slow.next = slow.next.next;
            return result.next;
        }

    }
}
