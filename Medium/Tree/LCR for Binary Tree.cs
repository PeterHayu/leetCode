using System;
namespace Medium.Tree
{
    public class LCR_for_Binary_Tree
    {
        //both O(N)
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;
            //when we found the node, return up to root of the tree
            if (root == p || root == q)
                return root;
            //recursively go to left and right to find p or q. If found it will be a node, if not its null
            //use this to identify which sides p and q are on
            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);
            //when p and q are on different side of a tree, return root of the tree
            if (left != null && right != null)
                return root;
            //when p and q are on same side of tree, return the LCR of the tree, which is the root of either p or q, whichever on a higher level 
            if (left == null)
                return right;
            if (right == null)
                return left;
            //when p and q are not found, return null
            return null;
        }

    }
}

