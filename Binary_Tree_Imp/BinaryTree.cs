using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Tree
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;

            public Node(int _val = 0, Node _left = null, Node _right = null)
            {
                val = _val;
                left = _left;
                right = _right;
            }
        }

        public Node root = null;

        public Tree()
        {

        }

        public Tree(int _val)
        {
            root = new Node(_val);
        }

        //constructor of tree from inorder and postorder traversal arrays
        public Tree(int[] inorder, int[] postorder)
        {
            root = BuildTreeInorderPostorder(inorder, postorder);
        }

        //constructor of tree from inorder and preorder traversal arrays
        //public Tree(int[] inorder, int[] preorder)
        //{
        //    root = root.BuildTreeInorderPreorder(inorder, preorder);
        //}

        private static Node BuildTreeInorderPostorder(int[] inorder, int[] postorder)
        {
            int length = inorder.Length;

            if (length == 0) { return null; }
            if (length == 1) { return new Node(inorder[0]); }

            Node root = new Node(postorder[length - 1]);
            int StartIndex = Array.IndexOf(inorder, root.val);

            int[] InorderLeftSubTree = new int[StartIndex];
            int[] InorderRightSubTree = new int[length - (StartIndex + 1)];
            Array.ConstrainedCopy(inorder, 0, InorderLeftSubTree, 0, InorderLeftSubTree.Length);
            Array.ConstrainedCopy(inorder, StartIndex + 1, InorderRightSubTree, 0, InorderRightSubTree.Length);

            int[] PostLeftSubTree = new int[StartIndex];
            int[] PostRightSubTree = new int[length - (StartIndex + 1)];
            Array.ConstrainedCopy(postorder, 0, PostLeftSubTree, 0, PostLeftSubTree.Length);
            Array.ConstrainedCopy(postorder, StartIndex, PostRightSubTree, 0, PostRightSubTree.Length);

            root.left = BuildTreeInorderPostorder(InorderLeftSubTree, PostLeftSubTree);
            root.right = BuildTreeInorderPostorder(InorderRightSubTree, PostRightSubTree);

            return root;
        }

        //constructor of tree from inorder and preorder traversal arrays
        private static Node BuildTreeInorderPreorder(int[] inorder, int[] preorder)
        {
            int length = inorder.Length;

            if (length == 0) { return null; }
            if (length == 1) { return new Node(inorder[0]); }

            Node root = new Node(preorder[0]);
            int startIndex = Array.IndexOf(inorder, root.val);

            int[] InorderLeftSubTree = new int[startIndex];
            int[] InorderRightSubTree = new int[length - (startIndex + 1)];
            Array.ConstrainedCopy(inorder, 0, InorderLeftSubTree, 0, InorderLeftSubTree.Length);
            Array.ConstrainedCopy(inorder, startIndex + 1, InorderRightSubTree, 0, InorderRightSubTree.Length);

            int[] PreLeftSubTree = new int[startIndex];
            int[] PreRightSubTree = new int[length - (startIndex + 1)];
            Array.ConstrainedCopy(preorder, 1, PreLeftSubTree, 0, PreLeftSubTree.Length);
            Array.ConstrainedCopy(preorder, startIndex + 1, PreRightSubTree, 0, PreRightSubTree.Length);

            root.left = BuildTreeInorderPreorder(InorderLeftSubTree, PreLeftSubTree);
            root.right = BuildTreeInorderPreorder(InorderRightSubTree, PreRightSubTree);

            return root;
        }
//=======Print=========================================================================================================================

        //Depth First Search Traversal
        public void Print_DFS()
        {
            if (root == null) { return; }

            Stack<Node> s = new Stack<Node>();
            Node curr = root;

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

        //Breadth First Search Traversal
        public void PrintBFS()
        {
            if (root == null) { return; }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                Node curr = q.Dequeue();
                Console.Write(curr.val + "--->");
                if (curr.left != null) { q.Enqueue(curr.left); }
                if (curr.right != null) { q.Enqueue(curr.right); }
            }
            Console.WriteLine();
        }

        public void PrintPreorder()
        {
            if (root == null) { return; }

            Stack<Node> s = new Stack<Node>();
            Node curr = root;

            while (curr != null || s.Count != 0)
            {
                while (curr != null)
                {
                    Console.Write(curr.val + "--->");
                    s.Push(curr);
                    curr = curr.left;
                }

                curr = s.Pop();
                curr = curr.right;
            }
            Console.WriteLine();
        }

        public void PrintInorder()
        {
            if (root == null) return;

            Stack<Node> s = new Stack<Node>();
            Node curr = root;

            while (curr != null || s.Count != 0)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    curr = curr.left;
                }

                curr = s.Pop();
                Console.Write(curr.val + "--->");
                curr = curr.right;
            }
            Console.WriteLine();
        }

        public void PrintPostorder()
        {
            if (root == null) { return; }

            Stack<Node> s = new Stack<Node>();
            Node curr = root;

            while (curr != null || s.Count != 0)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    s.Push(curr);
                    curr = curr.left;
                }

                curr = s.Pop();
                if (s.Count != 0 && curr == s.Peek())
                {
                    curr = curr.right;
                }
                else
                {
                    Console.Write(curr.val + "--->");
                    curr = null;
                }
            }
            Console.WriteLine();
        }

//=======GetList=========================================================================================================================
        //Get Preorder list traversal in recursion
        //public IList<int> GetPreorderRecList(IList<int> traverse)
        //{
        //    if (this == null) return new List<int>();

        //    traverse.Add(this.val);

        //    this.left.GetPreorderRecList(traverse);

        //    this.right.GetPreorderRecList(traverse);

        //    return traverse;
        //}

        public IList<int> GetPreorderList()
        {
            if (root == null) { return new List<int>(); }

            Stack<Node> s = new Stack<Node>();
            IList<int> traversal = new List<int>();
            Node curr = root;

            while (curr != null || s.Count != 0)
            {
                while (curr != null)
                {
                    traversal.Add(curr.val);
                    s.Push(curr);
                    curr = curr.left;
                }

                curr = s.Pop();
                curr = curr.right;
            }

            return traversal;
        }

        //Get Inorder list traversal in recursion
        //public IList<int> GetInorderRecList(IList<int> traverse)
        //{
        //    if (this == null) return new List<int>();

        //    this.left.GetInorderRecList(traverse);

        //    traverse.Add(this.val);

        //    this.right.GetInorderRecList(traverse);

        //    return traverse;
        //}

        public IList<int> GetInorderList()
        {
            if (root == null) return new List<int>();

            Stack<Node> s = new Stack<Node>();
            IList<int> traversal = new List<int>();
            Node curr = root;

            while (curr != null || s.Count != 0)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    curr = curr.left;
                }

                curr = s.Pop();
                traversal.Add(curr.val);
                curr = curr.right;
            }

            return traversal;
        }

        //Get Postorder list traversal in recursion
        //public IList<int> GetPostorderRecList(IList<int> traverse)
        //{
        //    if (this == null) return new List<int>();

        //    this.left.GetPostorderRecList(traverse);

        //    this.right.GetPostorderRecList(traverse);

        //    traverse.Add(this.val);

        //    return traverse;
        //}

        public IList<int> GetPostorderList()
        {
            if (root == null) { return new List<int>(); }

            Stack<Node> s = new Stack<Node>();
            IList<int> traversal = new List<int>();
            Node curr = root;

            while (curr != null || s.Count != 0)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    s.Push(curr);
                    curr = curr.left;
                }

                curr = s.Pop();
                if (s.Count != 0 && curr == s.Peek())
                {
                    curr = curr.right;
                }
                else
                {
                    traversal.Add(curr.val);
                    curr = null;
                }
            }

            return traversal;
        }      

        //returns List[][] - BFS traversal where each Level is in a seperate List
        public IList<IList<int>> GetBFSList()
        {
            IList<IList<int>> list = new List<IList<int>>();
            Queue<Node> qp = new Queue<Node>();

            if (root != null)
            {
                qp.Enqueue(root);
            }

            while (qp.Count > 0)
            {
                Queue<Node> qc = new Queue<Node>();
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

        public int[] GetInorderArray()
        {
            if (root == null) return new int[0];

            Stack<Node> s = new Stack<Node>();
            int size = Count();
            int[] traversal = new int[size];
            Node curr = root;

            for (int i = 0; curr != null || s.Count != 0; i++)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    curr = curr.left;
                }

                curr = s.Pop();
                traversal[i] = curr.val;
                curr = curr.right;
            }

            return traversal;
        }

        //returns Tree[] - BFS traversal
        public Node[] GetBFSArray()
        {
            if (root == null) { return new Node[0]; }

            Node[] array = new Node[100];
            array[0] = root;
            Node curr = root;
            int read = 0, write = 0;

            while (curr != null)
            {
                if (curr.left != null) { array[++write] = curr.left; }
                if (curr.right != null) { array[++write] = curr.right; }
                curr = array[++read];
            }

            return array;
        }

//=======Insert=========================================================================================================================

        //Insertion in BFS order
        public void InsertBFS(int _val)
        {
            if (root == null) { root = new Node(_val); return; }

            Queue<Node> q = new Queue<Node>();
            Node curr = root;
            q.Enqueue(curr);

            while (q.Count != 0)
            {
                curr = q.Dequeue();
                if (curr.left == null) { curr.left = new Node(_val); return; }
                else { q.Enqueue(curr.left); }
                if (curr.right == null) { curr.right = new Node(_val); return; }
                else { q.Enqueue(curr.right); }
            }
        }

//=======Delete=========================================================================================================================
        
        //delete node with val=_val
        public void Delete(int _val) 
        {
            if (root == null) { return; }
            if (root.val == _val && root.left == null && root.right == null) { root = null; return; }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            Node curr = root, toDelete = null;

            while (q.Count != 0)//do level order to find: 1)the node to delete 2)the last node inlevel order
            {
                curr = q.Dequeue();
                if (curr.val == _val)
                {
                    toDelete = curr;//the node we want to delete is curr
                }
                if (curr.left != null) { q.Enqueue(curr.left); }
                if (curr.right != null) { q.Enqueue(curr.right); }
            }

            if (toDelete != null)
            {
                int rightmostVal = curr.val;//curr is the last node in the level order we just did
                DeleteRightMost(rightmostVal);
                toDelete.val = rightmostVal;
            }
        }

        //delete the rightmost node - postorder traversal
        private void DeleteRightMost(int _val)
        {
            if (root == null) { return; }

            Stack<Node> s = new Stack<Node>();
            Node curr = root;

            while (s.Count != 0 || curr != null)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    s.Push(curr);
                    curr = curr.left;
                }

                curr = s.Pop();
                if (s.Count != 0 && curr == s.Peek())
                {
                    curr = curr.right;
                }
                else
                {
                    if (curr.val == _val)
                    {
                        Node parent = s.Peek();
                        if (parent.left == curr) { parent.left = null; }
                        if (parent.right == curr) { parent.right = null; }
                        return;
                    }
                    curr = null;
                }
            }
            //Queue<Node> q = new Queue<Node>();
            //q.Enqueue(this);
            //while (q.Count != 0)
            //{
            //    curr = q.Peek();
            //    q.Dequeue();

            //    if (curr.val == x)
            //    {
            //        curr = null;
            //        return;
            //    }
            //    if (curr.left != null)
            //    {
            //        if (curr.left.val == x)
            //        {
            //            curr.left = null;
            //            return;
            //        }
            //        else
            //            q.Enqueue(curr.left);
            //    }
            //    if (curr.right != null)
            //    {
            //        if (curr.right.val == x)
            //        {
            //            curr.right = null;
            //            return;
            //        }
            //        else
            //            q.Enqueue(curr.right);
            //    }
            //}
        }

//=======Search=========================================================================================================================
        
        //inorder search
        public Node Search(int _val)
        {
            if (root == null) { return null; }

            Stack<Node> s = new Stack<Node>();
            Node curr = root;

            while (s.Count != 0 || curr != null)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    curr = curr.left;
                }

                curr = s.Pop();
                if (curr.val == _val) { return curr; }
                curr = curr.right;
            }

            return null;
        }

//=======Contains=========================================================================================================================

        public bool Contains(int x)//inorder search
        {
            if (root == null) { return false; }

            Stack<Node> s = new Stack<Node>();
            Node curr = root;

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

//=======GetHeight=========================================================================================================================

        public int GetHeightRec()
        {
            //if counting edges:
            if ((root == null) || (root.left == null && root.right == null)) { return 0; }
            Tree lst = new Tree(), rst = new Tree();
            lst.root = root.left;
            rst.root = root.right;
            return 1 + Math.Max(lst.GetHeightRec(), rst.GetHeightRec());
            //if counting nodes:
            //if (this == null) { return 0; }
            //if (this.left == null && this.right == null) { return 1; }
            //return 1 + Math.Max(root.left.GetHeightRec(), root.right.GetHeightRec());
        }

        public int GetHeight()
        {
            if (root == null) { return 0; }

            Stack<Node> s = new Stack<Node>();
            Node curr = root;
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
                    Node last = s.Pop();
                    while (s.Count > 0 && last == s.Peek().right)
                    {
                        last = s.Pop();
                    }
                }
                curr = s.Count == 0 ? null : s.Peek().right;

            }
            return MaxHeight;
        }

//=======IsSymetric=========================================================================================================================

        public bool IsSymetric()
        {
            int[] tree = GetInorderArray();
            if (tree.Length % 2 == 0) { return false; }
            for (int i = 0; i < tree.Length / 2; i++)
            {
                if (tree[i] != tree[tree.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
            //IList<IList<int>> tree = GetBFSList();
            //foreach (var level in tree)
            //{
            //    Stack<int> s = new Stack<int>();
            //    foreach (var val in level)
            //    {
            //        s.Push(val);
            //    }
            //    foreach (var val in level)
            //    {
            //        if (val != s.Pop()) { return false; }
            //    }
            //}
            //return true;
        }

//=======Count=========================================================================================================================

        public int Count()
        {
            if (root == null) return 0;

            Stack<Node> s = new Stack<Node>();
            Node curr = root;
            int counter = 0;

            while (curr != null || s.Count != 0)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    counter++;
                    curr = curr.left;
                }

                curr = s.Pop();
                curr = curr.right;
            }

            return counter;
        }

        static bool HasPathSumRecursion(Node root, int Target)
        {
            if (root == null) { return false; }
            if (root.left == null && root.right == null) { return (root.val == Target) ? true : false; }
            return HasPathSumRecursion(root.left, Target - root.val) || (HasPathSumRecursion(root.right, Target - root.val));
        }

        static bool HasPathSum(Node root, int Target)
        {
            if (root == null) { return false; }

            Stack<Node> s = new Stack<Node>();
            Node curr = root;
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
                    Node last = s.Pop();
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
    }
}
