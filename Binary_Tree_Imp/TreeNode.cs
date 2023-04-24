using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public static void Print(IList<int> tree)
        {
            foreach (var val in tree)
            {
                Console.Write(val + "--->");
            }
            Console.WriteLine();
        }

        public static void Print(IList<IList<int>> tree)
        {
            foreach (var list in tree)
            {
                Print(list);
            }
            Console.WriteLine();
        }

        public static void Print(TreeNode root)//bfs
        {
            if (root == null) { return; }

            Queue<TreeNode> q = new Queue<TreeNode>();
            TreeNode curr = root;
            q.Enqueue(root);

            while (q.Count != 0)
            {
                curr = q.Dequeue();
                Console.Write(curr.val + " --->");
                if (curr.left != null) { q.Enqueue(curr.left); }
                if (curr.right != null) { q.Enqueue(curr.right); }
            }
            Console.WriteLine();
        }
    }
}
