using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class IsSymetricTree
    {
        static TreeNode root;

        static bool IsSymetric(TreeNode root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Queue<TreeNode> qp = new Queue<TreeNode>();

            if (root != null)
            {
                qp.Enqueue(root);
            }

            while (qp.Count > 0)
            {
                Queue<TreeNode> qc = new Queue<TreeNode>();
                list.Add(new List<int>());

                foreach (var parent in qp)
                {
                    if (parent != null)
                    {
                        list[list.Count - 1].Add(parent.val);
                        if (parent.left != null) { qc.Enqueue(parent.left); }
                        else { qc.Enqueue(null); }
                        if (parent.right != null) { qc.Enqueue(parent.right); }
                        else { qc.Enqueue(null); }
                    }
                    else { list[list.Count - 1].Add(-1); }
                }
                if (!IsPolindrom(list[list.Count - 1])) { return false; }
                qp = qc;
            }

            return true;
        }

        static bool IsPolindrom(IList<int> list)
        {
            Stack<int> stack = new Stack<int>();
            foreach (var val in list)
            {
                stack.Push(val);
            }
            foreach (var val in list)
            {
                if (val != stack.Pop()) { return false; }
            }

            return true;
        }

        static void Main8(string[] args)
        {
            root = new TreeNode(1);
            root.left = new TreeNode(0);
            //root.left.right = new Tree(3);
            //root.right = new Tree(2);
            //root.right.left = new Tree(3);

            Console.WriteLine(IsSymetric(root));

        }
    }
}
