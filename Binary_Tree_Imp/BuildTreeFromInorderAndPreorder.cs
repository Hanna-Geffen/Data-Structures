using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BuildTreeFromInorderAndPreorder
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
        static TreeNode BuildTreeInorderPreorder(int[] inorder, int[] preorder)
        {
            int length = inorder.Length;

            if (length == 0) { return null; }
            if (length == 1) { return new TreeNode(inorder[0]); }

            TreeNode root = new TreeNode(preorder[0]);
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
            int[] postorder = { 1, 2, 4, 8, 5, 3, 6, 7 };
            TreeNode result = BuildTreeInorderPreorder(inorder, postorder);
            TreeNode.Print(result);
        }
    }
}
