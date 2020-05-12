using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.LinkedList
{
    class AddTwoNumber
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode l3, result = new ListNode(0);
            l3 = result;
            while (l1 != null || l2 != null)
            {

                var val1 = l1 == null ? 0 : l1.val;
                var val2 = l2 == null ? 0 : l2.val;

                if (l3.next == null)
                    l3.next = new ListNode(val1 + val2);
                else
                    l3.next.val += (val1 + val2);


                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
                l3 = l3.next;
                if (l3.val > 9)
                {
                    l3.val %= 10;
                    l3.next = new ListNode(1);
                }

            }
            return result.next;
        }
    }
}
