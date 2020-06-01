using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class IsSameLeave
    {
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var list1 = new List<int>();
            var list2 = new List<int>();
            Traverse(root1, list1);
            Traverse(root2, list2);
            return list2.SequenceEqual(list1);
        }

        private void Traverse(TreeNode root, List<int> l)
        {
            if (root == null)
                return;
            if (root.left == null && root.right == null)
            {
                l.Add(root.val);
            }
            Traverse(root.left, l);
            Traverse(root.right, l);
        }

    }
}
