using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class GetHeight
    {
        static TreeNode root;

        //I decided to choose the convention in which the height of a tree is acording to the level.
        //for example 2^0 at level 0 where there is only 1 node(root) the height is 0.
        //since 2^0=1.
        //so 2^hight is the number of nodes in the acording level.

        static int FindHeightRecursion(TreeNode root)
        {
            //if counting edges:
            if ((root == null) || (root.left == null && root.right == null)) { return 0; }
            return 1 + Math.Max(FindHeightRecursion(root.left), FindHeightRecursion(root.right));
            //if counting nodes:
            //if (root == null) { return 0; }
            //if (root.left == null && root.right == null) { return 1; }
            //return 1 + Math.Max(FindHeightRecursion(root.left), FindHeightRecursion(root.right));
        }

        static int FindHeightIteration(TreeNode root)
        {
            if (root == null) { return 0; }

            Stack<TreeNode> s = new Stack<TreeNode>();
            TreeNode curr = root;
            int MaxHeight = 0;

            while (s.Count != 0 || curr != null)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    curr = curr.left;
                }

                if (s.Count - 1 > MaxHeight)//if counting nodes: s.Count
                {
                    MaxHeight = s.Count - 1;//if counting nodes: s.Count
                }

                if (s.Peek().right == null)
                {
                    TreeNode last = s.Pop();
                    while (s.Count > 0 && last == s.Peek().right)
                    {
                        last = s.Pop();
                    }
                }
                curr = s.Count == 0 ? null : s.Peek().right;

            }
            return MaxHeight;
        }

        static void Main8(string[] args)
        {
            root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.left.left = new TreeNode(6);
            root.left.left.left.right = new TreeNode(9);
            root.left.right = new TreeNode(5);
            root.left.right.left = new TreeNode(7);
            root.left.right.right = new TreeNode(8);
            root.left.right.right.right = new TreeNode(10);
            root.left.right.right.right.right = new TreeNode(11);

            int result = FindHeightIteration(root);//FindHeightRecursion(root);
            Console.WriteLine(result);
        }
    }
}
