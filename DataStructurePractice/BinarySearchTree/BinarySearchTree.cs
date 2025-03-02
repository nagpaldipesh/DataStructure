using DataStructurePractice.BinaryTree;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace DataStructurePractice.BinarySearchTree
{
    public class BinarySearchTree
    {
        public BinarySearchTreeNode Root;

        public BinarySearchTree()
        {
            Root = null;
        }

        public void Insert(int val)
        {
            if (Root == null)
            {
                Root = new BinarySearchTreeNode(val);
                return;
            }

            InsertHelper(Root, val);
        }

        public bool Search(int val)
        {
            if (Root == null)
                return false;

            return SearchHelper(Root, val);
        }

        public void Delete(int value)
        {
            Root = DeleteHelper(Root, value);
        }

        public List<LinkedList<BinarySearchTreeNode>> GetListOfDepths()
        {
            List<LinkedList<BinarySearchTreeNode>> result = new List<LinkedList<BinarySearchTreeNode>>();

            if (Root == null)
                return result;

            Queue<BinarySearchTreeNode> queue = new Queue<BinarySearchTreeNode>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;

                LinkedList<BinarySearchTreeNode> levelNodes = new LinkedList<BinarySearchTreeNode>();

                for (int i = 0; i < levelSize; i++)
                {
                    BinarySearchTreeNode node = queue.Dequeue();
                    levelNodes.AddLast(node);

                    if (node.Left != null)
                        queue.Enqueue(node.Left);
                    if (node.Right != null)
                        queue.Enqueue(node.Right);
                }
                result.Add(levelNodes);
            }

            return result;
        }

        public void PrintLevelLists(List<LinkedList<BinarySearchTreeNode>> levelNodesList)
        {
            foreach (var levelNodes in levelNodesList)
            {
                foreach (var node in levelNodes)
                {
                    Console.Write($" {node.Value} ");
                }

                Console.WriteLine();
            }
        }

        public bool IsBalancedTree()
        {
            //int leftHeight = FindTreeHeightBFS(Root?.Left);
            //int rightHeight = FindTreeHeightBFS(Root?.Right);

            //return Math.Abs(leftHeight - rightHeight) <= 1;

            return FindTreeHeightDFS(Root) != -1;
        }

        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTreeHelper(Root, int.MinValue, int.MaxValue);
        }

        public BinarySearchTreeNode FindSuccessorNode(int value)
        {
            var node = FindNodeRecursive(Root, value);

            if (node == null)
            {
                return null; 
            }

            // Case 1: Node has a right subtree -> Find the leftmost node in the right subtree
            if (node.Right != null)
            {
               return FindMinNode(node.Right);
            }

            // Case 2: No right subtree -> Find the first ancestor that is greater than the node
            BinarySearchTreeNode successor = null;
            BinarySearchTreeNode ancestor = Root;

            while (ancestor != null)
            {
                if (value < ancestor.Value)
                {
                    successor = ancestor;
                    ancestor = ancestor.Left;
                }
                else if (value > ancestor.Value)
                {
                    ancestor = ancestor.Right;
                }
                else
                {
                    break;
                }
            }

            return successor;
        }

        private BinarySearchTreeNode FindMinNode(BinarySearchTreeNode node)
        {
            if(node == null)
                return null;

            BinarySearchTreeNode currentNode = node;

            while (currentNode.Left != null)
            {
                currentNode = currentNode.Left;
            }

            return currentNode;
        }

        private BinarySearchTreeNode FindNodeRecursive(BinarySearchTreeNode  node, int value)
        {
            if (node == null)
                return null;

            if(node.Value == value)
                return node;

            if(value < node.Value)
                return FindNodeRecursive(node.Left, value);
            if(value > node.Value)
                return FindNodeRecursive(node.Right, value);

            return null;
        }

        private bool IsBinarySearchTreeHelper(BinarySearchTreeNode treeNode, int min, int max)
        {
            if (treeNode == null)
                return true;

            if (treeNode.Value < min || treeNode.Value > max)
                return false;

            return IsBinarySearchTreeHelper(treeNode.Left, min, treeNode.Value) &&
                IsBinarySearchTreeHelper(treeNode.Right, treeNode.Value, max);
        }
        //public bool IsBinarySearchTree()
        //{
        //    bool isBST = true;

        //    return isBST;
        //}

        //private bool IsBinarySearchTreeHelper(BinarySearchTreeNode treeNode, bool isBST)
        //{

        //}

        private int FindTreeHeightDFS(BinarySearchTreeNode treeNode)
        {
            if (treeNode == null)
                return 0;

            int leftHeight = FindTreeHeightDFS(treeNode.Left);
            if (leftHeight == -1) return -1;

            int rightHeight = FindTreeHeightDFS(treeNode.Right);
            if (rightHeight == -1) return -1;

            if (Math.Abs(leftHeight - rightHeight) > 1)
                return -1;

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        private int FindTreeHeightBFS(BinarySearchTreeNode treeNode)
        {
            if (treeNode == null)
                return 0;

            Queue<BinarySearchTreeNode> queue = new Queue<BinarySearchTreeNode>();
            queue.Enqueue(treeNode);
            int height = 0;

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    var node = queue.Dequeue();

                    if (node.Left != null)
                        queue.Enqueue(node.Left);

                    if (node.Right != null)
                        queue.Enqueue(node.Right);
                }

                height++;
            }

            return height;
        }

        private bool SearchHelper(BinarySearchTreeNode Node, int val)
        {
            if (Node == null)
            {
                return false;
            }

            if (Node.Value == val)
            {
                return true;
            }

            return val < Node.Value ? SearchHelper(Node.Left, val) : SearchHelper(Node.Right, val);
        }

        private void InsertHelper(BinarySearchTreeNode Node, int value)
        {
            if (value < Node.Value)
            {
                if (Node.Left != null)
                {
                    InsertHelper(Node.Left, value);
                    return;
                }
                Node.Left = new BinarySearchTreeNode(value);
            }
            else
            {
                if (Node.Right != null)
                {
                    InsertHelper(Node.Right, value);
                    return;
                }
                Node.Right = new BinarySearchTreeNode(value);
            }
        }

        private BinarySearchTreeNode DeleteHelper(BinarySearchTreeNode Node, int value)
        {
            if (Node == null)
                return null;

            if (value < Node.Value)
            {
                Node.Left = DeleteHelper(Node.Left, value);

            }
            else if (value > Node.Value)
            {
                Node.Right = DeleteHelper(Node.Right, value);
            }

            else
            {
                // No Children
                if (Node.Left == null && Node.Right == null)
                {
                    return null;
                }

                // 1 Children only
                if (Node.Left == null)
                    return Node.Right;
                if (Node.Right == null)
                    return Node.Left;

                //Both Children present
                var successor = FindMin(Node.Right);
                Node.Value = successor.Value;

                Node.Right = DeleteHelper(Node.Right, successor.Value);
            }

            return Node;
        }

        private BinarySearchTreeNode FindMin(BinarySearchTreeNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }
    }
    public class BinarySearchTreeNode
    {
        public int Value;

        public BinarySearchTreeNode Left;
        public BinarySearchTreeNode Right;

        public BinarySearchTreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
}
