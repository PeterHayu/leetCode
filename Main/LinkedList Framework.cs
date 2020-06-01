using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    public class LinkedList_Framework
    {
        public ListNode LinkedListTemplate(ListNode l1, ListNode l2) {
            ListNode l3, result = new ListNode(0);
            //manipulate l3, return result / result.next;
            l3 = result;

            //  || can replaced by && based on condition, end when one of the input ends VS end when the longer end
            while (l1 != null || l2 != null) {
                //do sth, then move to the next element on l3
                l3 = l3.next;
                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }
            return result.next;
        }
    }
}
