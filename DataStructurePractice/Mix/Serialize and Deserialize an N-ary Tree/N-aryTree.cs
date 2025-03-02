
using DataStructurePractice.LinkedList;
using Shouldly;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace DataStructurePractice.Mix.Serialize_and_Deserialize_an_N_ary_Tree
{
    class Node
    {
        public int val;
        public List<Node> children;

        public Node(int value)
        {
            val = value;
            children = new List<Node>();
        }
    }

    //https://www.geeksforgeeks.org/serialize-deserialize-n-ary-tree/
    //    //Approach
    //Serialization(Convert Tree → String)

    //Use level-order traversal(BFS) with a queue.
    //Store node values and the number of children.
    //Separate values using delimiters.
    //Deserialization (Convert String → Tree)

    //Read the serialized string using a queue.
    //Reconstruct the tree using parent-child relationships.
    internal class N_aryTree
    {
        public static void Execute()
        {
            Serialize_Deserialize_ShouldReturnSameTree();
        }

        public static void Serialize_Deserialize_ShouldReturnSameTree()
        {
            Node root = new Node(1);
            root.children.Add(new Node(2));
            root.children.Add(new Node(3));
            root.children.Add(new Node(4));
            root.children[1].children.Add(new Node(5));
            root.children[1].children.Add(new Node(6));

            N_aryTree codec = new N_aryTree();
            string serialized = codec.Serialize(root);
            Node deserializedRoot = codec.Deserialize(serialized);

            deserializedRoot.ShouldNotBeNull();
            deserializedRoot.val.ShouldBe(1);
            deserializedRoot.children.Count.ShouldBe(3);
            deserializedRoot.children[0].val.ShouldBe(2);
            deserializedRoot.children[1].val.ShouldBe(3);
            deserializedRoot.children[2].val.ShouldBe(4);
            deserializedRoot.children[1].children.Count.ShouldBe(2);
            deserializedRoot.children[1].children[0].val.ShouldBe(5);
            deserializedRoot.children[1].children[1].val.ShouldBe(6);
        }

        //public string Serialize(Node root)
        //{
        //    if (root == null) return "";

        //    Queue<Node> queue = new Queue<Node>();
        //    queue.Enqueue(root);
        //    List<string> data = new List<string>();

        //    while (queue.Count > 0)
        //    {
        //        Node node = queue.Dequeue();
        //        data.Add(node.val.ToString());
        //        data.Add(node.children.Count.ToString());

        //        foreach (var child in node.children)
        //        {
        //            queue.Enqueue(child);
        //        }
        //    }

        //    return string.Join(",", data);
        //}


        public string Serialize(Node root)
        {
            if (root == null)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            SerializeHelper(root, sb);
            return sb.ToString();
        }

        private void SerializeHelper(Node node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            sb.Append(node.val).Append(' ');

            // Append number of children
            sb.Append(node.children.Count).Append(' ');

            foreach (var child in node.children)
            {
                SerializeHelper(child, sb);
            }
        }

        // Deserialize the encoded data to an N-ary tree
        public Node Deserialize(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            string[] tokens = data.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int index = 0;
            return DeserializeHelper(tokens, ref index);
        }

        private Node DeserializeHelper(string[] tokens, ref int index)
        {
            if (index >= tokens.Length)
            {
                return null;
            }

            int val = int.Parse(tokens[index++]);
            int size = int.Parse(tokens[index++]);

            Node node = new Node(val);

            for (int i = 0; i < size; i++)
            {
                node.children.Add(DeserializeHelper(tokens, ref index));
            }

            return node;
        }

        //public Node Deserialize(string data)
        //{
        //    if (string.IsNullOrEmpty(data)) return null;

        //    string[] values = data.Split(',');
        //    Queue<string> queue = new Queue<string>(values);

        //    Node root = new Node(int.Parse(queue.Dequeue()));
        //    Queue<Node> nodeQueue = new Queue<Node>();
        //    nodeQueue.Enqueue(root);

        //    while (queue.Count > 0)
        //    {
        //        Node parent = nodeQueue.Dequeue();
        //        int childrenCount = int.Parse(queue.Dequeue());

        //        for (int i = 0; i < childrenCount; i++)
        //        {
        //            Node child = new Node(int.Parse(queue.Dequeue()));
        //            parent.children.Add(child);
        //            nodeQueue.Enqueue(child);
        //        }
        //    }

        //    return root;
        //}

        //public string Serialize(Node head)
        //{
        //    if (head == null)
        //        return "";

        //    List<string> data = new List<string>();

        //    Queue<Node> queue = new Queue<Node>();
        //    queue.Enqueue(head);

        //    while (queue.Count > 0)
        //    {
        //        Node node = queue.Dequeue();
        //        data.Add(node.val.ToString());
        //        data.Add(node.children.Count.ToString());

        //        foreach (var child in node.children)
        //        {
        //            queue.Enqueue(child);
        //        }
        //    }


        //    return string.Join(",", data);
        //}

        //public Node Deserialize(string s)
        //{
        //    string[] data = s.Split(',');

        //    if (data.Length < 1)
        //    {
        //        return null;
        //    }

        //    Queue<string> queue = new Queue<string>(data);

        //    Node root = new Node(int.Parse(queue.Dequeue()));
        //    Queue<Node> queueNode = new Queue<Node>();
        //    queueNode.Enqueue(root);

        //    while (queue.Count > 0)
        //    {
        //        var parentNode = queueNode.Dequeue();

        //        int numOfChilds = int.Parse(queue.Dequeue());

        //        for (int i = 0; i < numOfChilds; i++)
        //        {
        //            var Node = new Node(int.Parse(queue.Dequeue()));
        //            parentNode.children.Add(Node);
        //            queueNode.Enqueue(Node);
        //        }
        //    }

        //    return root;
        //}
    }
}
