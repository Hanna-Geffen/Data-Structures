using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BFSTraversal
    {
        static TreeNode root;

        static IList<IList<int>> LevelOrderTraversalUsingTwoQueues(TreeNode root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Queue<TreeNode> qp = new Queue<TreeNode>();

            if (root != null)
            {
                qp.Enqueue(root);
            }

            while (qp.Count > 0)
            {
                Queue<TreeNode> qc = new Queue<TreeNode>();
                list.Add(new List<int>());

                foreach (var parent in qp)
                {
                    list[list.Count - 1].Add(parent.val);
                    if (parent.left != null) { qc.Enqueue(parent.left); }
                    if (parent.right != null) { qc.Enqueue(parent.right); }
                }
                qp = qc;
            }

            return list;
        }
        static TreeNode[] IterativeLevelOrderTraversalUsingArray(TreeNode root)
        {
            if (root == null) { return new TreeNode[0]; }

            TreeNode[] array = new TreeNode[100];
            array[0] = root;
            TreeNode curr = root;
            int read = 0, write = 0;

            while (curr != null)
            {
                if (curr.left != null) { array[++write] = curr.left; }
                if (curr.right != null) { array[++write] = curr.right; }
                curr = array[++read];
            }

            return array;
        }

        static TreeNode LevelOrderTraversalInsertionUsingArray(TreeNode root, int key)
        {
            if (root == null) { root = new TreeNode(key); }
            TreeNode curr = root;

            TreeNode[] array = new TreeNode[100];
            array[0] = root;
            int read = 0, write = 0;

            while (curr != null)
            {
                if (curr.left != null) { array[++write] = curr.left; }
                else { curr.left = new TreeNode(key); break; }
                if (curr.right != null) { array[++write] = curr.right; }
                else { curr.right = new TreeNode(key); break; }
                curr = array[++read];
            }
            return root;
        }

        static void IterativeLevelOrderTraversalUsingQueue(TreeNode root)
        {
            if (root == null) { return; }

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                TreeNode curr = q.Dequeue();
                Console.Write(curr.val + "--->");
                if (curr.left != null) { q.Enqueue(curr.left); }
                if (curr.right != null) { q.Enqueue(curr.right); }
            }
            Console.WriteLine();
        }

        static void LevelOrderTraversalInsertionUsingQueue(TreeNode root, int key)
        {
            if (root == null) { root = new TreeNode(key); return; }

            Queue<TreeNode> q = new Queue<TreeNode>();
            TreeNode curr = root;
            q.Enqueue(root);

            while (q.Count != 0)
            {
                curr = q.Dequeue();
                if (curr.left == null) { curr.left = new TreeNode(key); return; }
                else { q.Enqueue(curr.left); }
                if (curr.right == null) { curr.right = new TreeNode(key); return; }
                else { q.Enqueue(curr.right); }
            }
        }

        static void Main8(string[] args)
        {
            root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(4);
            root.left.left.left = new TreeNode(8);
            root.left.left.right = new TreeNode(9);
            root.left.right = new TreeNode(5);
            root.right = new TreeNode(3);
            root.right.left = new TreeNode(6);
            root.right.left.left = new TreeNode(12);
            root.right.left.right = new TreeNode(13);
            root.right.right = new TreeNode(7);

            IList<IList<int>> result = LevelOrderTraversalUsingTwoQueues(root);
            TreeNode.Print(result);
        }
    }
}
