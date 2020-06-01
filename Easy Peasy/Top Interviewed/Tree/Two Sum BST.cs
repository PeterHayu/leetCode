using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class Two_Sum_BST
    {
        //BST way
        public bool FindTarget(TreeNode root, int k)
        {
            return dfs(root, root, k);
        }

        private bool dfs(TreeNode root, TreeNode cur, int k)
        {
            if (cur == null)
                return false;
            var target = k - cur.val;

            return SearchBST(root, cur, target) || dfs(root, cur.left, k) || dfs(root, cur.right, k);

        }


        private bool SearchBST(TreeNode root, TreeNode cur, int target)
        {
            if (root == null)
                return false;

            if (root.val < target)
                return SearchBST(root.right, cur, target);
            if (root.val > target)
                return SearchBST(root.left, cur, target);

            return (root.val == target) && (root != cur);
        }



        //Two Sum way
        public bool FindTarget2(TreeNode root, int k)
        {
            if (root == null)
                return false;
            var d = new Dictionary<int, TreeNode>();
            Traverse(root, d);
            foreach (var c in d.Keys)
            {
                var diff = k - c;
                if (d.ContainsKey(diff) && d[diff] != d[c])
                    return true;
            }
            return false;
        }

        public void Traverse(TreeNode root, Dictionary<int, TreeNode> d)
        {
            if (root == null)
                return;

            d[root.val] = root;
            Traverse(root.left, d);
            Traverse(root.right, d);
        }
    }
}
