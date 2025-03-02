
namespace DataStructurePractice.Stack
{
    public class MinStack
    {
        private readonly Stack<int> stack;
        private readonly Stack<int> minStack;

        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int item)
        {
            stack.Push(item);

            if(minStack.Count == 0 || minStack.Peek() >= item)
            {
                minStack.Push(item);
            }
        }

        public int Pop()
        {
            if(stack.Count == 0)
                throw new InvalidOperationException("Stack is already empty");

            var poppedItem = stack.Pop();

            if(minStack.Count > 0 && poppedItem == minStack.Peek())
            {
                minStack.Pop();
            }

            return poppedItem;
        }

        public int Peek()
        {
            if (stack.Count == 0)
                throw new InvalidOperationException("Stack is already empty");

            return stack.Peek();
        }

        public int GetMinimum()
        {
            if (minStack.Count == 0) // Check minStack, not stack
                throw new InvalidOperationException("MinStack is empty. No minimum value available.");

            return minStack.Peek();
        }
    }
}
