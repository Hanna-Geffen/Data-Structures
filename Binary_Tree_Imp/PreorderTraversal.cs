using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class PreorderTraversal
    {
        static TreeNode root;

        static IList<int> PreorderTraversalRecursion(TreeNode root, IList<int> traverse)
        {
            if (root == null) return new List<int>();

            traverse.Add(root.val);

            PreorderTraversalRecursion(root.left, traverse);

            PreorderTraversalRecursion(root.right, traverse);

            return traverse;
        }

        static IList<int> PreorderTraversalIterative(TreeNode root)
        {
            if (root == null) { return new List<int>(); }

            Stack<TreeNode> tree = new Stack<TreeNode>();
            IList<int> traversal = new List<int>();
            TreeNode curr = root;

            while (curr != null || tree.Count != 0)
            {
                while (curr != null)
                {
                    //Console.Write(curr.val + "--->");
                    traversal.Add(curr.val);
                    tree.Push(curr);
                    curr = curr.left;
                }

                curr = tree.Pop();
                curr = curr.right;
            }

            return traversal;
        }

        static void Main9(string[] args)
        {
            root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right = new TreeNode(3);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            IList<int> result = PreorderTraversalIterative(root);
            TreeNode.Print(result);

            result = new List<int>();
            result = PreorderTraversalRecursion(root, result);
            TreeNode.Print(result);
        }
    }
}
