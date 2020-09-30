using System;
namespace Medium.Tree
{
    public class LCR_for_Binary_Tree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;
            //when we found the node, return up to root of the tree
            if (root == p || root == q)
                return root;
            //recursively go to left and right
            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);
            //when p and q are on different side of a tree, return the LCR of the tree
            if (left != null && right != null)
                return root;
            //when p and q are on same side of tree, return root of the tree
            if (left == null)
                return right;
            if (right == null)
                return left;
            //when p and q are not found, return null
            return null;
        }

    }
}
}
