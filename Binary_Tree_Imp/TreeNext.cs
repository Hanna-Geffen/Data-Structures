using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class TreeNext
    {
        public int val;
        public TreeNext left;
        public TreeNext right;
        public TreeNext next;

        public TreeNext(int val = 0, TreeNext left = null, TreeNext right = null, TreeNext next = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
            this.next = next;
        }

        public static void Print(TreeNext root)//bfs
        {
            if (root == null) { return; }

            Queue<TreeNext> q = new Queue<TreeNext>();
            TreeNext curr = root;
            q.Enqueue(root);

            while (q.Count != 0)
            {
                curr = q.Dequeue();
                if (curr.next != null) { Console.Write(curr.val + " --->"); }
                else { Console.Write(curr.val + " ---> null --->"); }
                if (curr.left != null) { q.Enqueue(curr.left); }
                if (curr.right != null) { q.Enqueue(curr.right); }
            }
            Console.WriteLine();
        }
    }
}
