using System;
namespace Easy.Top100.LinkedList
{
    public class Delete_Node_in_a_Linked_List
    {
        public void DeleteNode(ListNode node)
        {
            //just update the value of the current node to the next node
            node.val = node.next.val;
            //delete the next node by pointing to next next
            node.next = node.next.next;
        }

    }
}
