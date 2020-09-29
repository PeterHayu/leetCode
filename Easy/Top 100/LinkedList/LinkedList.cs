using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public static class LinkedList
    {
        //note: l3 is pointing to result, result is the new list
        //note: l3.next should be pointing to l1 and l2
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            //creating two pointer pointing to a same new list with one element, 0
            ListNode l3, result = new ListNode(0);
            //l3 and result both pointing to same location
            l3 = result;
            //while l1 and l2 pointer havent reach the end of their list
            while (l1 != null & l2 != null)
            {
                //if the value l1 points to less then l2
                if (l1.val < l2.val)
                {
                    //l3 should link to l1
                    l3.next = l1;
                    //l1 move fwd
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
            //when loop breaks, l1 reaches the end
            if (l1 == null)
                l3.next = l2; //l3 link to l2
            if (l2 == null)
                l3.next = l1;
            return result.next; //skip the current value
        }

        public static ListNode MergeTwoListsRecursive(ListNode l1, ListNode l2) {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val < l2.val)
            {
                l1.next = MergeTwoListsRecursive(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoListsRecursive(l1, l2.next);
                return l2;
            }
        }
    }
}
