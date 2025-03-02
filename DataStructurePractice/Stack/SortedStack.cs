namespace DataStructurePractice.Stack
{
    /// <summary>
    /// Sort Stack: Write a program to sort a stack such that the smallest items are on the top. You can use
    /// an additional temporary stack, but you may not copy the elements into any other data structure
    /// (such as an array). The stack supports the following operations: push, pop, peek, and is Empty.
    /// </summary>
    public class SortedStack
    {
        Stack<int> stack;

        public SortedStack()
        {
            stack = new Stack<int>();
        }


        public void Push(int value)
        {
            Stack<int> tempStack = new Stack<int> ();

            // Assending Order Top should have lowest number
            while (stack.Count > 0 && stack.Peek() < value)
            {
                tempStack.Push (stack.Pop());
            }

            stack.Push(value);

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }
        }

        public int Pop()
        {
            if(stack.Count == 0) 
                throw new InvalidOperationException("Stack is empty");
            
            return stack.Pop();
        }

        public int Peek()
        {
            if (stack.Count == 0)
                throw new InvalidOperationException("Stack is empty");

            return stack.Peek();
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }
    }
}
