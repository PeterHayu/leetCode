using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.LinkedList
{
    public class Linked_List_Cycle_Return_Loop_Position
    {
        public ListNode DetectCycle(ListNode head)
        {
            //1, slow and fast always meet one node before the loop start
            //2, use another pointer to return the result
            if (head == null)
                return null;

            ListNode slow = head, fast = head, result = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    while (slow != result)
                    {
                        slow = slow.next;
                        result = result.next;
                    }
                    return result;
                }
            }
            return null;
        }
    }
}
