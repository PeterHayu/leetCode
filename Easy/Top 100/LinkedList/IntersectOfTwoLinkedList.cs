using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100.LinkedList
{
    public static class IntersectOfTwoLinkedList
    {
        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var s = new Stack<ListNode>();
            while (headA != null)
            {
                s.Push(headA);
                headA = headA.next;
            }
            while (headB != null)
            {
                if (s.Contains(headB))
                {
                    return headB;
                }
                headB = headB.next;
            }

            return null;
        }

        public static ListNode GetIntersectionNodeFast(ListNode headA, ListNode headB)
        {
            var p1 = headA;
            var p2 = headB;



            while (p1 != p2)
            {
                if (p1 == null)
                {
                    p1 = headB;
                }
                else
                {
                    p1 = p1.next;
                }
                if (p2 == null)
                {
                    p2 = headA;
                }
                else
                {

                    p2 = p2.next;
                }
            }
            return p1;
        }

        public static ListNode GetIntersectionNodeAnswer(ListNode headA, ListNode headB)
        {
            ListNode a = headA;
            ListNode b = headB;

            // continue until a and b are equal.
            while (a != b)
            {
                // If one reaches end first then move a|b to the head of b|a
                // This handles case if both have different lengths. No need to
                // count length of A and B. If there is no overlap both A and B ends with null.
                a = a != null ? a.next : headB;
                b = b != null ? b.next : headA;
            }

            return a;
        }
    }
}
