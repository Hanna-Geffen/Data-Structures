using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Populating_Next_Right_PointersII
    {
        static TreeNext root;

        static TreeNext Connect(TreeNext root)
        {
            Queue<TreeNext> qparent = new Queue<TreeNext>();

            if (root != null)
            {
                qparent.Enqueue(root);
            }

            while (qparent.Count > 0)
            {
                Queue<TreeNext> qchild = new Queue<TreeNext>();
                TreeNext previous = null;
                foreach (var parent in qparent)
                {
                    if (previous != null) { previous.next = parent; }
                    previous = parent;
                    if (parent.left != null) { qchild.Enqueue(parent.left); }
                    if (parent.right != null) { qchild.Enqueue(parent.right); }
                }
                qparent = qchild;
            }

            return root;
        }

        static void Main9(string[] args)
        {
            //root = new TreeNext(1);
            //root.left = new TreeNext(2);
            //root.right = new TreeNext(3);
            //root.left.left = new TreeNext(4);
            //root.left.right = new TreeNext(5);
            //root.right.left = new TreeNext(6);
            //root.right.right = new TreeNext(7);

            root = new TreeNext(3);
            root.left = new TreeNext(9);
            root.right = new TreeNext(20);
            root.right.left = new TreeNext(15);
            root.right.right = new TreeNext(7);

            TreeNext.Print(root);
            TreeNext result = Connect(root);
            TreeNext.Print(result);
        }
    }
}
