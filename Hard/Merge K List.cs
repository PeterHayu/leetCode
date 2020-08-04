using System;
using System.Collections.Generic;
using System.Text;

namespace Hard
{
    class Merge_K_List
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
                return null;
            //merge 1,2 to 1, 3,4 to 3, 
            for (int i = 1; i < lists.Length; i *= 2)
            {
                for (int j = 0; i + j < lists.Length; j += i * 2)
                {
                    lists[j] = MergeTwoLists(lists[j], lists[i + j]);
                }
            }

            return lists[0];
        }

        //exactly the same as Merge Two Linked List
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
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
    }
}
