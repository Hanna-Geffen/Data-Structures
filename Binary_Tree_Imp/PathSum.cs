using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class PathSum
    {
        static TreeNode root;

        static bool HasPathSumRecursion(TreeNode root, int Target)
        {
            if (root == null) { return false; }
            if (root.left == null && root.right == null) { return (root.val == Target) ? true : false; }
            return HasPathSumRecursion(root.left, Target - root.val) || (HasPathSumRecursion(root.right, Target - root.val));
        }

        static bool HasPathSum(TreeNode root, int Target)
        {
            if (root == null) { return false; }

            Stack<TreeNode> s = new Stack<TreeNode>();
            TreeNode curr = root;
            int Sum = 0;

            while (s.Count != 0 || curr != null)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    Sum += curr.val;
                    curr = curr.left;
                }

                if (Sum == Target && s.Peek().right == null && s.Peek().left == null)
                {
                    return true;
                }

                if (s.Peek().right == null)
                {
                    TreeNode last = s.Pop();
                    Sum -= last.val;
                    while (s.Count > 0 && last == s.Peek().right)
                    {
                        last = s.Pop();
                        Sum -= last.val;
                    }
                }
                curr = s.Count == 0 ? null : s.Peek().right;

            }
            return false;
        }

        static void Main7(string[] args)
        {
            root = new TreeNode(1);
            root.left = new TreeNode(-2);
            root.right = new TreeNode(-3);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);
            root.right.left = new TreeNode(-2);
            root.left.left.left = new TreeNode(-1);
            //root.right = new TreeNode(3);
            //root.left.left = new TreeNode(4);
            //root.left.left.left = new TreeNode(6);
            //root.left.left.left.right = new TreeNode(9);
            //root.left.right = new TreeNode(5);
            //root.left.right.left = new TreeNode(7);
            //root.left.right.right = new TreeNode(8);
            //root.left.right.right.right = new TreeNode(10);
            //root.left.right.right.right.right = new TreeNode(11);

            bool result = HasPathSum(root, -4);//FindHeightRecursion(root);
            Console.WriteLine(result);
        }
    }
}
