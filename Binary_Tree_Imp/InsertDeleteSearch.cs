using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class InsertDeleteSearch
    {
        static TreeNode root;

        static void Insert(TreeNode root, int x)//using bfs to insert without affecting the height hopefully
        {
            if (root == null) { root = new TreeNode(x); return; }

            Queue<TreeNode> q = new Queue<TreeNode>();
            TreeNode curr = root;
            q.Enqueue(curr);

            while (q.Count != 0)
            {
                curr = q.Dequeue();
                if (curr.left == null) { curr.left = new TreeNode(x); return; }
                else { q.Enqueue(curr.left); }
                if (curr.right == null) { curr.right = new TreeNode(x); return; }
                else { q.Enqueue(curr.right); }
            }
        }

        static IList<IList<int>> LevelOrderUsingTwoQueues(TreeNode root)
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
                    list[list.Count - 1].Add(parent.val);
                    if (parent.left != null) { qc.Enqueue(parent.left); }
                    if (parent.right != null) { qc.Enqueue(parent.right); }
                }
                qp = qc;
            }

            return list;
        }

        static int RightestandDeepestNode(TreeNode root)
        {
            IList<IList<int>> l = LevelOrderUsingTwoQueues(root);
            return l[l.Count - 1][l[l.Count - 1].Count - 1];
        }

        static void Delete_X(TreeNode root, int x)//
        {
            if (root == null) { return; }

            Stack<TreeNode> s = new Stack<TreeNode>();
            TreeNode curr = root;


            while (s.Count != 0 || curr != null)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    curr = curr.left;
                }

                curr = s.Pop();
                if (curr.val == x)
                {
                    int rightMost = RightestandDeepestNode(root);
                    DeleteRightMost(root, rightMost);
                    curr.val = rightMost;
                    return;
                }
                curr = curr.right;
            }
        }

        static void DeleteRightMost(TreeNode root, int x)//delete the rightmost node
        {
            if (root == null) { return; }

            Stack<TreeNode> s = new Stack<TreeNode>();
            TreeNode curr = root;


            while (s.Count != 0 || curr != null)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    curr = curr.left;
                }

                curr = s.Pop();
                if (curr.val == x)
                {
                    TreeNode parent = s.Pop();
                    if (parent.left == curr) { parent.left = null; }
                    if (parent.right == curr) { parent.right = null; }
                    return;
                }
                curr = curr.right;
            }
        }

        static TreeNode Search(TreeNode root, int x)//inorder search
        {
            if (root == null) { return null; }

            Stack<TreeNode> s = new Stack<TreeNode>();
            TreeNode curr = root;
            TreeNode found = null;

            while (s.Count != 0 || curr != null)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    curr = curr.left;
                }

                curr = s.Pop();
                if (curr.val == x) { return curr; }
                curr = curr.right;
            }

            return found;
        }

        static bool Contains(TreeNode root, int x)//inorder search
        {
            if (root == null) { return false; }

            Stack<TreeNode> s = new Stack<TreeNode>();
            TreeNode curr = root;

            while (s.Count != 0 || curr != null)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    curr = curr.left;
                }

                curr = s.Pop();
                if (curr.val == x) { return true; }
                curr = curr.right;
            }

            return false;
        }

        static void Main(string[] args)
        {
            root = new TreeNode(1);

            Insert(root, 2);
            Insert(root, 3);
            Insert(root, 4);
            Insert(root, 5);
            Insert(root, 6);
            //Insert(root, 7);

            TreeNode.Print(root);

            Console.WriteLine(Search(root, 2).val);
            Console.WriteLine(Contains(root, 5));
            Delete_X(root, 4);
            TreeNode.Print(root);
        }
    }
}
