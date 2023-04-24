using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BuildTreeFromInorderAndPostorder
    {
        static TreeNode root;

        // ConstrainedCopy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length);
        //    Copies a range of elements from an System.Array starting at the specified source
        //    index and pastes them to another System.Array starting at the specified destination
        //    index.Guarantees that all changes are undone if the copy does not succeed completely.
        //      
        //    Parameters:
        //      sourceArray: The System.Array that contains the data to copy.
        //      sourceIndex: A 32-bit integer that represents the index in the sourceArray at which copying begins.
        //      destinationArray: The System.Array that receives the data.
        //      destinationIndex: A 32-bit integer that represents the index in the destinationArray at which storing begins.
        //      length: A 32-bit integer that represents the number of elements to copy.
        static TreeNode BuildTreeInorderPostorder(int[] inorder, int[] postorder)
        {
            int length = inorder.Length;

            if (length == 0) { return null; }
            if (length == 1) { return new TreeNode(inorder[0]); }

            TreeNode root = new TreeNode(postorder[length - 1]);
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

        static void Main5(string[] args)
        {
            root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);
            root.left.left.right = new TreeNode(8);

            int[] inorder = { 4, 8, 2, 5, 1, 6, 3, 7 };
            int[] postorder = { 8, 4, 5, 2, 6, 7, 3, 1 };
            TreeNode result = BuildTreeInorderPostorder(inorder, postorder);
            TreeNode.Print(result);
        }
    }
}
