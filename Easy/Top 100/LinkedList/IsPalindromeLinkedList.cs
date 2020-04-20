using System;
using System.Collections.Generic;
using System.Text;
using Easy.Class;

namespace Easy.Top_100.LinkedList
{
    public static class IsPalindromeLinkedList
    {
        public static bool IsPalindrome1(ListNode head)
        {
            if (head == null)
                return true;
            var slow = head;
            var fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            slow = ReverseLinkedList.reverseList(slow);
            while (slow != null && slow.next != null)
            {
                if (slow.val != head.val)
                    return false;
                slow = slow.next;
                head = head.next;
            }
            return true;
        }

        public static bool IsPalindrome2(ListNode head)
        {
            if (head == null)
                return true;
            var s = new Stack<ListNode>();
            var twice = head;
            while (head != null)
            {
                s.Push(head);
                head = head.next;
            }
            while (twice != null)
            {
                var node = s.Pop();
                if (twice.val != node.val)
                    return false;
                if (twice == node)
                    return true;
                twice = twice.next;
            }
            return true;
        }
    }
}
