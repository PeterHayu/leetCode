
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
            //create new list if no element in the list(current level) 
            if (lv >= l.Count)
                l.Insert(0, new List<int>());
            Traverse(l, root.left, lv + 1);
            Traverse(l, root.right, lv + 1);
            l[l.Count - lv - 1].Add(root.val);
        }

        public IList<IList<int>> LevelOrderBottomIterative(TreeNode root)
        {
            var list = new List<IList<int>>();
            var q = new Queue<TreeNode>();

            if (root == null)
                return list;

            //list.Add(new List<int>());
            q.Enqueue(root);


            while (q.Count != 0)
            {
                var subL = new List<int>();
                int level = q.Count;
                for (int i = 0; i < level; i++)
                {
                    //should not pop the parent when the current level is not finished
                    if (q.Peek().left != null)
                        q.Enqueue(q.Peek().left);
                    if (q.Peek().right != null)
                        q.Enqueue(q.Peek().right);
                    //pop the value when added
                    subL.Add(q.Dequeue().val);
                }
                list.Insert(0, subL);
            }
            return list;
        }
    }
}
