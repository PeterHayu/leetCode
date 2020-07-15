using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Tree
{
    class Connect_Level_Order_Nodes_in_Pefect_Binary_Tree
    {
        public Node Connect(Node root)
        {
            //preorder traversal
            Traverse(root);
            return root;
        }

        private void Traverse(Node root)
        {

            //empty tree
            if (root == null)
                return;

            //reach leaf 
            if (root.left == null && root.right == null)
                return;

            //since perfect binary, we dont need to check null for left and right children
            //simply connect left and right children from root
            //example: connect 2 to 3
            //add left check here if not perfect binary tree
            root.left.next = root.right;

            //second time visited, one of the sub root on left sub tree
            //example: connect 5 to 6
            //add right check here if not perfect binary tree
            if (root.next != null)
            {
                root.right.next = root.next.left;
            }

            Connect(root.left);
            Connect(root.right);
        }

        public Node Connect(Node root)
        {
            if (root == null)
                return null;

            // Run level by level order traversal
            // set a previous node in the same level
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var size = queue.Count;

                Node previous = null;
                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);

                    if (previous != null)
                        previous.next = node;

                    previous = node;
                }
            }

            return root;
        }
    }
}
