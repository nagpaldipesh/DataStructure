using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurePractice.LinkedList
{
    public class DoublyNode
    {
        public int Data { get; set; }
        public DoublyNode Next { get; set; }
        public DoublyNode Prev { get; set; }

        public DoublyNode(int data, DoublyNode prev)
        {
            Data = data;
            Prev = prev;
            Next = null;
        }
    }

    public class DoublyLinkedList
    {
        private int size;
        public DoublyNode Head { get; set; }
        public int Length { get { return size; } }
        public DoublyLinkedList()
        {
            Head = null;
        }

        //Inserting a new node before the head
        public void InsertAtBeginning(int data)
        {
            if (size == 0)
            {
                Head = new DoublyNode(data, null);
                size++;
                return;
            }

            DoublyNode node = new DoublyNode(data, prev: null);
            node.Next = Head;
            Head.Prev = node;

            Head = node;
            size++;
        }

        //Inserting a new node after the tail (at the end of the list).
        public void Insert(int data)
        {
            if (size == 0)
            {
                InsertAtBeginning(data);
                return;
            }

            var currentNode = Head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            var node = new DoublyNode(data, currentNode);
            currentNode.Next = node;
            size++;
        }

        //Inserting a new node at the given index of the list.
        public void InsertAt(int data, int index)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                InsertAtBeginning(data);
                return;
            }

            if (index == size)
            {
                Insert(data);
                return;
            }

            var currentNode = Head;
            int currentIndex = 1;

            while (currentIndex < index)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }

            var temp = currentNode.Next;
            var newNode = new DoublyNode(data, currentNode);
            newNode.Next = temp;

            if (temp != null) // ✅ Fix: Prevent null reference error when inserting at the end
            {
                temp.Prev = newNode;
            }

            currentNode.Next = newNode;
            size++;
        }

        public int FindAt(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }

            if (size == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            int currentIndex = 0;
            var currentNode = Head;

            while (currentIndex < index)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }

            return currentNode.Data;
        }

        // Deleting the first node
        public int RemoveFromBeginning()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            int removedNum = Head.Data;

            if (size == 1)
            {
                Head = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }

            size--;
            return removedNum;
        }

        //Deleting the last node
        public int RemoveFromEnd()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("List is empty");
            }
            if(size == 1)
            {
                return RemoveFromBeginning();
            }

            var currentNode = Head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            int removedNum = currentNode.Data;
            var prevNode = currentNode.Prev;
            prevNode.Next = null;
            size--;
            return removedNum;
        }

        //Deleting an intermediate node
        public int RemoveAt(int index)
        {
            if (size == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                return RemoveFromBeginning();
            }

            if (index == size - 1)
            {
                return RemoveFromEnd();
            }

            int currentIndex = 0;
            var currentNode = Head;

            while (currentIndex < index - 1)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }

            var nodeToRemove = currentNode.Next;
            int removedNum = nodeToRemove.Data;

            currentNode.Next = nodeToRemove.Next;

            if (nodeToRemove.Next != null) // ✅ Fix: Avoid null reference when removing last element
            {
                nodeToRemove.Next.Prev = currentNode;
            }

            size--;

            return removedNum;
        }
    }
}
