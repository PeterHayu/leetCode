using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Top_Interviewed.Tree
{
    public class N_ary_Tree_Preorder_Traversal
    {
        public IList<int> Preorder(Node root)
        {
            List<int> result = new List<int>();
            Traverse(root, result);
            return result;
        }

        private void Traverse(Node root, IList<int> l)
        {
            if (root == null)
                return;
            l.Add(root.val);
            foreach (var child in root.children)
            {
                Traverse(child, l);
            }
        }

        public IList<int> PreorderIterative(Node root)
        {
            List<int> result = new List<int>();
            var s = new Stack<Node>();

            if (root == null)
                return result;
            s.Push(root);

            while (s.Count != 0)
            {
                var t = s.Pop();
                result.Add(t.val);

                //if use queue and push element in usual order, it become Level Order Traversal
                //if use queue and push element in back order, it become reversed Level Order Traversal
                //if use stack and push element in usual order, it become reversed Post Order Traversal
                //if use stack and push element in back order, it become Pre Order Traversal = DFS
                //In order traversal use stack and push all left elements first, not applied in n-array tree
                for (int i = t.children.Count - 1; i >= 0; i--)
                {
                    s.Push(t.children[i]);
                }

            }

            return result;
        }
    }
}
