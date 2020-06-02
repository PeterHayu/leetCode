using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.LinkedList
{
    class Copy_List_with_Random_Pointer
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return head;
            var p = head;
            //1. create a duplicate element and connect to next
            while (p != null)
            {
                //temp point to original next
                var temp = p.next;
                //original next point to new copied node
                p.next = new Node(p.val);
                //copied node next point to original next
                p.next.next = temp;
                //advance to original next
                p = temp;
            }

            p = head;
            //2. set random of the copied node
            while (p != null)
            {
                //if its original node
                //set the next node(copied node)'s random to the orginal node's random's copied
                if (p.random != null)
                    p.next.random = p.random.next;
                //advance to next random
                p = p.next.next;
            }

            p = head;
            //3.return the result by seperating the copied from original
            var result = p.next;
            var r = result;
            while (r.next != null)
            {
                //resetting orignal, have to perform first
                //becauase p starts from head
                //and r starts from head.next
                p.next = p.next.next;
                p = p.next;

                //retrieving the copied 
                r.next = r.next.next;
                r = r.next;

            }
            //one more step to finish resetting because the loop end early
            p.next = p.next.next;

            return result;
        }
    }
}
