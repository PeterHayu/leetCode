using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class N_ary_Tree_Postorder_Traverse
    {
        public IList<int> Postorder(Node root)
        {
            var result = new List<int>();
            Traverse(root, result);
            return result;
        }

        private void Traverse(Node root, IList<int> result)
        {
            if (root == null)
                return;
            foreach (var child in root.children)
            {
                Traverse(child, result);
            }
            result.Add(root.val);
        }

        public IList<int> PostorderIterative(Node root)
        {
            var result = new List<int>();
            if (root == null)
                return result;
            var s = new Stack<Node>();
            s.Push(root);

            while (s.Count>0)
            {
                var c = s.Pop();
                for (int i = 0; i < c.children.Count; i++)
                {
                    s.Push(c.children[i]);
                }
                result.Insert(0, c.val);
            }

            return result;

        }
    }
}
