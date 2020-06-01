using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class TrimBinaryTree
    {
        public TreeNode TrimBST(TreeNode root, int L, int R)
        {
            if (root == null)
                return root;
            TreeNode result = root;
            var temp = new List<TreeNode>();
            var intTemp = new List<int>();
            temp = Traverse(root, temp);


            foreach (var t in temp)
            {
                intTemp.Add(t.val);
            }

            foreach (var i in intTemp.Except(Enumerable.Range(L, L + R - 1)))
            {
                result = DeleteNode(root, i);
            }
            return result;
        }


        private TreeNode DeleteNode(TreeNode root, int val)
        {
            if (root == null)
                return root;
            /*
            if (root.left == null && root.right == null)
                return null;
            */
            if (root.val == val)
            {
                if (root.left == null) return root.right;
                if (root.right == null) return root.left;
                //have both left and right children
                /*
                TreeNode maxNode = GetMax(root.left);
                root.val = maxNode.val;
                //delete the max node
                root.left = DeleteNode(root.left,maxNode.val);  
                */
                TreeNode minNode = GetMin(root.right);
                root.val = minNode.val;
                root.right = DeleteNode(root.right, minNode.val);
            }
            else if (root.val < val)
                root.right = DeleteNode(root.right, val);
            else if (root.val > val)
                root.left = DeleteNode(root.left, val);
            return root;
        }

        private TreeNode GetMax(TreeNode root)
        {
            if (root == null)
                return null;
            var list = new List<TreeNode>();
            return Traverse(root, list)[list.Count - 1];
        }

        private TreeNode GetMin(TreeNode root)
        {
            if (root == null)
                return null;
            while (root.left != null)
            {
                root = root.left;
            }
            return root;
        }

        private List<TreeNode> Traverse(TreeNode root, List<TreeNode> result)
        {
            if (root == null)
                return null;
            Traverse(root.left, result);
            result.Add(root);
            Traverse(root.right, result);
            return result;
        }

        //Recursive 
        public TreeNode TrimBST2(TreeNode root, int L, int R)
        {
            if (root == null)
                return root;
            if (root.val > R) return TrimBST2(root.left, L, R);
            if (root.val < L) return TrimBST2(root.right, L, R);

            root.left = TrimBST2(root.left, L, R);
            root.right = TrimBST2(root.right, L, R);

            return root;
        }
    }
}
