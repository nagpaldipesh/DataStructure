using Shouldly.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Runtime.Versioning;

namespace DataStructurePractice.LinkedList
{

    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int data)
        {
            this.Data = data;
            Next = null;
        }
    }

    public class LinkedList
    {

        private int size;
        public int Length { get { return size; } set { size = value; } }
        public Node Head { get; set; }

        public LinkedList()
        {
            Head = null;
            size = 0;
        }

        public void InsertOnBeginning(int num)
        {
            var node = new Node(num);
            node.Next = Head;
            Head = node;
            size++;
        }

        public void InsertAt(int num, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException("Index is greater than List Length");
            }

            if (index == 0)
            {
                InsertOnBeginning(num);
                return;
            }

            int currentIndex = 1;
            var currentNode = Head;

            while (currentNode.Next != null && currentIndex < index)
            {
                currentIndex++;
                currentNode = currentNode.Next;
            }

            var node = new Node(num);
            node.Next = currentNode.Next;

            currentNode.Next = node;
            size++;
        }

        public void Insert(int num)
        {
            if (Head == null)
            {
                Head = new Node(num);
                size++;
                return;
            }

            var current = Head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = new Node(num);
            size++;
        }

        public int Remove()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("List is empty.");
            }

            if (Head.Next == null)
            {
                int removedItem = Head.Data;
                Head = null;
                size--;
                return removedItem;
            }

            var current = Head;

            while (current.Next != null && current.Next.Next != null)
            {
                current = current.Next;
            }

            var removedData = current.Next.Data;
            current.Next = null;
            size--;

            return removedData;
        }

        public int RemoveAt(int index)
        {
            if (Head == null)
            {
                throw new InvalidOperationException("List is empty");
            }

            if (size <= index || index < 0)
            {
                throw new InvalidOperationException("Given index is invalid");
            }

            int removedItem = -1, currentIndex = 1;

            if (index == 0)
            {
                removedItem = Head.Data;
                Head = Head.Next;
                --size;
                return removedItem;
            }

            Node currentNode = Head;

            while (currentNode.Next != null && currentIndex < index)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }

            Node temp = currentNode.Next;
            currentNode.Next = temp.Next;
            --size;

            return temp.Data;
        }

        public int Peek()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("List is empty");
            }

            var lastNode = Head;

            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }

            return lastNode.Data;
        }

        // returns the number of elements in the list
        public int Count()
        {
            return Length;
        }

        // removes all elements of the list (disposes the list)
        public void RemoveAll()
        {
            Head = null;
            Length = 0;
        }

        //Find nth node from the start of the list

        public int FindAt(int index)
        {
            var currentNode = Head;

            if (index < 0 || index >= Length)
            {
                return -1;
            }

            int currentIndex = 0;

            while (currentNode != null)
            {
                if (index == currentIndex)
                {
                    return currentNode.Data;
                }

                currentIndex++;
                currentNode = currentNode.Next;
            }

            return -1;
        }

        public bool IsCyclic()
        {
            Node slow = Head, fast = Head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }

        //public bool IsCyclic()
        //{
        //    HashSet<Node> nodes = new HashSet<Node>();

        //    Node temp = Head;

        //    while (temp != null)
        //    {
        //        if (nodes.Contains(temp))
        //        {
        //            return true;
        //        }

        //        nodes.Add(temp);
        //        temp = temp.Next;
        //    }

        //    return false;
        //}

        public Node DetectCyclc()
        {
            if (Head == null)
            {
                return null;
            }

            Node slow = Head, fast = Head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    slow = Head;

                    while (slow != fast)
                    {
                        slow = slow.Next;
                        fast = fast.Next;
                    }

                    return slow; // Cycle detected
                }
            }

            return null; // No cycle
        }

        public void CreateCycle(int index)
        {
            if (Head == null) return;

            Node temp = Head;
            Node cycleNode = null;
            int count = 0;

            if (index == 0)
            {
                cycleNode = Head;
            }

            while (temp.Next != null)
            {
                if (count == index)
                {
                    cycleNode = temp;
                }
                temp = temp.Next;
                count++;
            }

            // Create cycle by pointing last node to cycleNode
            if (cycleNode != null)
            {
                temp.Next = cycleNode;
            }
        }

        public void Reverse()
        {
            Node prev = null, currentNode = Head, next = null;

            while (currentNode != null)
            {
                next = currentNode.Next;

                currentNode.Next = prev;
                prev = currentNode;
                currentNode = next;
            }

            Head = prev;
        }

        public void ReverseRecursive()
        {
            ReverseRecursiveHelper(Head);
        }

        public Node ReverseRecursiveHelper(Node node)
        {
            if (node == null || node.Next == null)
                return node;

            Node newNode = ReverseRecursiveHelper(node.Next);
            node.Next.Next = node;
            node.Next = null;

            return newNode;
        }

        public Node IntersectionPoint(Node node, Node node2)
        {
            if (node == null || node2 == null)
            {
                return null;
            }

            HashSet<Node> visited = new HashSet<Node>();

            var currentNode = node;

            while (currentNode != null)
            {
                visited.Add(currentNode);
                currentNode = currentNode.Next;
            }

            currentNode = node2;


            while (currentNode != null)
            {
                if (visited.Contains(currentNode))
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            return null;
        }

        public Node IntersectionPoint2(Node node, Node node2)
        {
            if (node == null || node2 == null)
            {
                return null;
            }

            Node ptr1 = node, ptr2 = node2;

            while (ptr1 != ptr2)
            {
                ptr1 = (ptr1 == null) ? ptr2 : ptr1;
                ptr2 = (ptr2 == null) ? ptr1 : ptr2;
            }

            return ptr1;
        }
    }

}
