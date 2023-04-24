using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class PopulatingNextRightPointers
    {
        static TreeNext root;

        static TreeNext Connect(TreeNext root)
        {
            if (root == null) { return null; }

            Queue<TreeNext> q = new Queue<TreeNext>();
            TreeNext curr = root;
            q.Enqueue(curr);

            while (q.Count != 0)
            {
                curr = q.Dequeue();
                q.Enqueue(curr.left);
                q.Enqueue(curr.right);
                if (q.Peek() == null) { break; }
                curr.next = q.Peek();
            }

            curr = root;

            while (curr != null)
            {
                curr.next = null;
                curr = curr.right;
            }

            return root;
        }

        static void Main5(string[] args)
        {
            root = new TreeNext(1);
            root.left = new TreeNext(2);
            root.right = new TreeNext(3);
            root.left.left = new TreeNext(4);
            root.left.right = new TreeNext(5);
            root.right.left = new TreeNext(6);
            root.right.right = new TreeNext(7);

            TreeNext.Print(root);
            TreeNext result = Connect(root);
            TreeNext.Print(result);
        }
    }
}
