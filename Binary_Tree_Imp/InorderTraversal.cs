using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class InorderTraversal
    {
        static TreeNode root;

        static IList<int> InorderTraversalRecursion(TreeNode root, IList<int> traverse)
        {
            if (root == null) return new List<int>();

            InorderTraversalRecursion(root.left, traverse);

            traverse.Add(root.val);

            InorderTraversalRecursion(root.right, traverse);

            return traverse;
        }

        static IList<int> InorderTraversalIterative(TreeNode root)
        {
            if (root == null) return new List<int>();

            Stack<TreeNode> tree = new Stack<TreeNode>();
            IList<int> traversal = new List<int>();
            TreeNode curr = root;

            while (curr != null || tree.Count != 0)
            {
                while (curr != null)
                {
                    tree.Push(curr);
                    curr = curr.left;
                }

                curr = tree.Pop();
                //Console.Write(curr.val + "--->");
                traversal.Add(curr.val);
                curr = curr.right;
            }

            return traversal;
        }

        static void Main1(string[] args)
        {
            root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right = new TreeNode(3);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            IList<int> result = InorderTraversalIterative(root);
            TreeNode.Print(result);

            result = new List<int>();
            result = InorderTraversalRecursion(root, result);
            TreeNode.Print(result);
        }
    }
}
