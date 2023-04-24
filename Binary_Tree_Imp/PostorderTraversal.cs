using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class PostorderTraversal
    {
        static TreeNode root;

        static IList<int> PostorderTraversalRecursion(TreeNode root, IList<int> traverse)
        {
            if (root == null) return new List<int>();

            PostorderTraversalRecursion(root.left, traverse);

            PostorderTraversalRecursion(root.right, traverse);

            traverse.Add(root.val);

            return traverse;
        }

        static IList<int> PostorderTraversalIterative(TreeNode root)
        {
            if (root == null) { return new List<int>(); }

            Stack<TreeNode> TreeNode = new Stack<TreeNode>();
            IList<int> traversal = new List<int>();
            TreeNode curr = root;

            while (curr != null || TreeNode.Count != 0)
            {
                while (curr != null)
                {
                    TreeNode.Push(curr);
                    TreeNode.Push(curr);
                    curr = curr.left;
                }

                curr = TreeNode.Pop();
                if (TreeNode.Count != 0 && curr == TreeNode.Peek())
                {
                    curr = curr.right;
                }
                else
                {
                    //Console.Write(curr.val + "--->");
                    traversal.Add(curr.val);
                    curr = null;
                }
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

            IList<int> result = PostorderTraversalIterative(root);
            TreeNode.Print(result);

            result = new List<int>();
            result = PostorderTraversalRecursion(root, result);
            TreeNode.Print(result);
        }
    }
}
