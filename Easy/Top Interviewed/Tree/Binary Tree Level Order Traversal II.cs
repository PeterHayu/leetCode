using Easy.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class Binary_Tree_Level_Order_Traversal_II
    {
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            var list = new List<IList<int>>();
            Traverse(list, root, 0);
            return list;
        }

        private void Traverse(IList<IList<int>> l, TreeNode root, int lv)
        {
            if (root == null)
                return;
            if (lv >= l.Count)
                l.Insert(0, new List<int>());
            Traverse(l, root.left, lv + 1);
            Traverse(l, root.right, lv + 1);
            l[l.Count - lv - 1].Add(root.val);
        }
    }
}
