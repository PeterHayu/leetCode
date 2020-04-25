
using System.Collections.Generic;

namespace Easy.Top_Interviewed.Tree
{
    public class Sum_Of_Left_Leaf
    {
        public int SumOfLeftLeaves(TreeNode root)
        {
            //initial input be false, because we dont add root value 
            return addLeft(root, false);
        }

        private int addLeft(TreeNode root, bool isLeft)
        {
            //framework
            if (root == null)
                return 0;
            //found, do sth
            if (root.left == null && root.right == null && isLeft)
            {
                return root.val;
            }
            //return needed result
            return addLeft(root.left, true) + addLeft(root.right, false);
        }


        public int sumOfLeftLeaves(TreeNode root)
        {
            if (root == null || root.left == null && root.right == null) return 0;

            int res = 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count!=0)
            {
                var curr = queue.Dequeue();

                if (curr.left != null && curr.left.left == null && curr.left.right == null) res += curr.left.val;
                if (curr.left != null) queue.Enqueue(curr.left);
                if (curr.right != null) queue.Enqueue(curr.right);
            }
            return res;
        }
    }
}
