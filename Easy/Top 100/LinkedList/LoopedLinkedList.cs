using System;
using System.Collections.Generic;
using System.Text;
using Easy.Class;

namespace Easy.Top_100.LinkedList
{
    public static class LoopedLinkedList { 

        public static bool HasCycle(ListNode head)
    {
        var s = new HashSet<ListNode>();
        while (head != null)
        {
            if (s.Contains(head))
            {
                return true;
            }
            else
            {
                s.Add(head);
            }
            head = head.next;
        }
        return false;
    }

        public static bool HasCycleTwoPointers(ListNode head)
        {
            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    return true;
            }

            return false;
        }
    }
}
