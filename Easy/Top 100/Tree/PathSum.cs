using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_100.Tree
{
    public class PathSum
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;
            if (root.left == null && root.right == null)
                return sum == root.val; //This checks that, if we add this leaf node's value to our current sum, will it be equal to the target sum
            return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
        }

        public bool HasPathSumNonRecursive(TreeNode root, int sum)
        {
            if (root == null)
                return false;
            var s = new Stack<TreeNode>();
            var s2 = new Stack<int>();
            s.Push(root);
            s2.Push(sum - root.val);
            while (s.Count != 0)
            {
                var t = s.Pop();
                var count = s2.Pop();
                if (t.left != null)
                {
                    s.Push(t.left);
                    s2.Push(count - t.left.val);
                }
                if (t.right != null)
                {
                    s.Push(t.right);
                    s2.Push(count - t.right.val);
                }
                if (t.left == null && t.right == null && count == 0)
                {
                    return true;
                }
            }
            return false;

        }

        public int PathSumIII(TreeNode root, int sum)
        {
            if (root == null)
                return 0;
            int count = 0;
            if (sum == root.val)
                count++;
            return RootSum(root, sum) + PathSumIII(root.left, sum) +
                PathSumIII(root.right, sum);
        }

        private int RootSum(TreeNode root, int sum)
        {
            if (root == null)
                return 0;
            int count = 0;
            if (sum == root.val)
                count++;
            return count + RootSum(root.left, sum - root.val) + RootSum(root.right, sum - root.val);
        }
    }
}
