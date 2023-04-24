using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class DFSTraversal
    {
        static TreeNode root;

        static void DepthFirstSearchUsingStack(TreeNode root)
        {
            if (root == null) { return; }

            Stack<TreeNode> s = new Stack<TreeNode>();
            TreeNode curr = root;

            while (s.Count != 0 || curr != null)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    Console.Write(curr.val + "--->");
                    curr = curr.left;
                }
                curr = s.Pop().right;
            }
        }

        static void Main4(string[] args)
        {
            root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(3);
            root.left.left.left = new TreeNode(4);
            root.left.left.right = new TreeNode(5);
            root.left.right = new TreeNode(6);
            root.right = new TreeNode(8);
            root.right.left = new TreeNode(9);
            root.right.left.left = new TreeNode(10);
            root.right.left.right = new TreeNode(11);
            root.right.right = new TreeNode(12);
            //root.left.right.right = new TreeNode(8);

            DepthFirstSearchUsingStack(root);
        }
    }
}
