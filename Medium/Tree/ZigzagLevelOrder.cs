using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Tree
{
    class ZigzagLevelOrder
    {
        public IList<IList<int>> ZigzagLevelOrderBFS(TreeNode root)
        {
            var result = new List<IList<int>>();
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            if (root == null)
                return result;

            var zigzag = false;

            while (q.Count != 0)
            {

                var subL = new List<int>();
                var lv = q.Count;
                for (int i = 0; i < lv; i++)
                {
                    var t = q.Dequeue();

                    if (zigzag)
                    {
                        //reverse the order add to subL
                        subL.Insert(0, t.val);
                    }
                    else
                    {
                        subL.Add(t.val);
                    }


                    //same as traverse in recursion
                    if (t.left != null)
                        q.Enqueue(t.left);
                    if (t.right != null)
                        q.Enqueue(t.right);


                }
                result.Add(subL);
                zigzag = !zigzag;
            }

            return result;
        }
    }
}
