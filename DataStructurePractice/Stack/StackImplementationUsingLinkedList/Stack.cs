
using DataStructurePractice.LinkedList;

namespace DataStructurePractice.Stack.StackImplementationUsingLinkedList
{
    public class Stack
    {
        private Node top;
        private int size;
        public int Count { get { return size; } }
        public Stack()
        {
            top = null;
            size = 0;
        }

        public void Push(int x)
        {
            Node newNode = new Node(x);
            newNode.Next = top;
            top = newNode;
            size++;
        }

        public void Clear()
        {
            top = null;
            size = 0;
        }

        public int Peek()
        {
            if(size == 0)
                throw new InvalidOperationException("Stack is empty.");

            return top.Data;
        }

        public int Pop()
        {
            if (size == 0)
                throw new InvalidOperationException("Stack is empty.");

            int poppedData = top.Data;
            top = top.Next;
            size--;
            return poppedData;
        }

        public bool IsCyclic()
        {
            Node slow = top , fast = top;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if(slow == fast)
                {
                    return true;
                }
            }

            return false;
        }

        public int Size()
        {
            return size;
        }

        public bool IsEmptyStack()
        {
            if (size == 0)
                return true;

            return false;
        }
    }
}
