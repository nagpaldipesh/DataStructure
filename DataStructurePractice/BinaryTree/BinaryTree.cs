using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurePractice.BinaryTree
{
    public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree
    {
        public TreeNode Node { get; set; }

        public BinaryTree()
        {
            Node = null;
        }

        public void AddNode(int data)
        {
            Node = AddNodeRecursive(Node, data);
        }

        public void Insert(int data)
        {
            Node = AddNodeRecursive(Node, data);
        }

        #region DFS
        // Left Root Right
        // https://leetcode.com/problems/binary-tree-inorder-traversal/submissions/1545919360/
        public void InOrderTraversal()
        {
            InOrderTraversalRecursive(Node);
        }

        // Root Left Right
        public void PreOrderTraversal()
        {
            PreOrderTraversalRecursive(Node);
        }

        // Left Right Root
        public void PostOrderTraversal()
        {
            PostOrderTraversalRecursive(Node);
        }
        #endregion

        #region BFS

        public void LevelOrderTraversalBFS()
        {
            if (Node == null)
                return;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(Node);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.Write($"{node.Data} ");

                if (node.Left != null)
                    queue.Enqueue(node.Left);

                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }
        }

        #endregion

        #region DFS
        // Left Right Root
        public void PostOrderTraversalRecursive(TreeNode current)
        {
            if (current == null)
                return;

            PostOrderTraversalRecursive(current.Left);
            PostOrderTraversalRecursive(current.Right);
            Console.Write($"{current.Data} ");
        }

        // Root Left Right
        private void PreOrderTraversalRecursive(TreeNode current)
        {
            if (current == null)
                return;

            Console.Write($"{current.Data} ");

            PreOrderTraversalRecursive(current.Left);
            PreOrderTraversalRecursive(current.Right);
        }

        // Left Root Right
        private void InOrderTraversalRecursive(TreeNode current)
        {
            if (current == null)
                return;

            InOrderTraversalRecursive(current.Left);
            Console.Write($"{current.Data} ");

            InOrderTraversalRecursive(current.Right);
        }
        #endregion

        private TreeNode AddNodeRecursive(TreeNode current, int data)
        {
            if (current == null)
            {
                return new TreeNode(data);
            }

            if (data < current.Data)
            {
                current.Left = AddNodeRecursive(current.Left, data);
            }
            else if (data > current.Data)
            {
                current.Right = AddNodeRecursive(current.Right, data);
            }

            return current;
        }

        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTreeHelper(Node, int.MinValue, int.MaxValue);
        }

        private bool IsBinarySearchTreeHelper(TreeNode treeNode, int min, int max)
        {
            if (treeNode == null)
                return true;

            if(treeNode.Data < min || treeNode.Data > max)
                return false;

            return IsBinarySearchTreeHelper(treeNode.Left, min, treeNode.Data) && 
                IsBinarySearchTreeHelper(treeNode.Right, treeNode.Data, max);
        }
    }
}
