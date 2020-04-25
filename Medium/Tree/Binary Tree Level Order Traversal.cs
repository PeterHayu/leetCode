using System;
using System.Collections.Generic;

namespace Medium.Tree
{
    public class Medium
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var list = new List<IList<int>>();
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            if (root == null) return list;
            while (q.Count != 0)
            {
                var subL = new List<int>();
                var lv = q.Count;
                for (int i = 0; i < lv; i++)
                {
                    var t = q.Peek();
                    //should not pop the parent when the current level is not finished
                    if (t.left != null)
                        q.Enqueue(t.left);
                    if (t.right != null)
                        q.Enqueue(t.right);
                    //pop the value when added
                    subL.Add(q.Dequeue().val);
                }
                list.Add(subL);
            }
            return list;
        }


        public IList<IList<int>> LevelOrderRecursive(TreeNode root)
        {
            var l = new List<IList<int>>();
            Traverse(root, l, 0);
            return l;
        }


        public void Traverse(TreeNode root, List<IList<int>> l, int level)
        {
            if (root == null)
                return;
            //create new sublist if first time visit current level
            if (l.Count <= level)
                l.Add(new List<int>());
            //add to list with inward order
            l[level].Add(root.val);
            //tree traverse template
            Traverse(root.left, l, level + 1);
            Traverse(root.right, l, level + 1);
        }

    }
}
