using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class Average_Leveral_Order_Traversal_of_Binary_Tree
    {
        public IList<double> AverageOfLevels(TreeNode root)
        {
            var result = new List<double>();
            if (root == null)
                return result;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Any())
            {
                var lv = q.Count;
                var avg = 0.0;

                for (int i = 0; i < lv; i++)
                {
                    var t = q.Dequeue();
                    avg += t.val;
                    if (t.left != null)
                        q.Enqueue(t.left);
                    if (t.right != null)
                        q.Enqueue(t.right);
                }
                result.Add((double)avg / lv);
            }

            return result;
        }
    }
}
