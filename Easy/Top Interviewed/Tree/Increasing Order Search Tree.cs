using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class Increasing_Order_Search_Tree
    {
        TreeNode headPointer = null;
        TreeNode result = null;
        public TreeNode IncreasingBST(TreeNode root)
        {
            if (root == null)
                return null;
            Traverse(root);
            return result;
        }

        private void Traverse(TreeNode root)
        {
            if (root == null)
                return;

            Traverse(root.left);

            //only when the first node is visited
            if (result == null)
            {
                result = new TreeNode(root.val);
                //point to head
                headPointer = result;
            }
            else
            {
                //use pointer to traverse and update
                headPointer.right = new TreeNode(root.val);
                headPointer = headPointer.right;
            }
            Traverse(root.right);
        }
    }
}
