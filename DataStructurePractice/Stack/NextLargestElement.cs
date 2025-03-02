using Shouldly;

namespace DataStructurePractice.Stack
{
    public class NextLargestElement
    {
        public static void Execute()
        {
            ExecuteGetNextLargestElementToRight();

            ExecuteGetNextLargestElementToLeft();
        }

        static void ExecuteGetNextLargestElementToLeft()
        {
            int[] arr = new int[] { 1, 3, 0, 0, 1, 2, 4 };
            GetNextLargestElementToLeft(arr).ShouldBe(new int[] { -1, -1, 3, 3, 3, 3, -1 });

            //Test Case 2 (Strictly Increasing Order)
            int[] arr2 = { 1, 2, 3, 4, 5 };
            GetNextLargestElementToLeft(arr2).ShouldBe(new int[] { -1, -1, -1, -1, -1 });

            //Test Case 3 (Strictly Decreasing Order)
            int[] arr3 = { 5, 4, 3, 2, 1 };
            GetNextLargestElementToLeft(arr3).ShouldBe(new int[] { -1, 5, 4, 3, 2 });

            //Test Case 4 (Random Order)
            int[] arr4 = { 4, 5, 2, 25, 7, 8 };
            GetNextLargestElementToLeft(arr4).ShouldBe(new int[] { -1, -1, 5, -1, 25, 25 });
        }

        static void ExecuteGetNextLargestElementToRight()
        {
            int[] arr = new int[] { 1, 3, 0, 0, 1, 2, 4 };
            GetNextLargestElementToRight(arr).ShouldBe(new int[] { 3, 4, 1, 1, 2, 4, -1 });

            //Test Case 2 (Strictly Increasing Order)
            int[] arr2 = { 1, 2, 3, 4, 5 };
            GetNextLargestElementToRight(arr2).ShouldBe(new int[] { 2, 3, 4, 5, -1 });

            //Test Case 3 (Strictly Decreasing Order)
            int[] arr3 = { 5, 4, 3, 2, 1 };
            GetNextLargestElementToRight(arr3).ShouldBe(new int[] { -1, -1, -1, -1, -1 });

            //Test Case 4 (Random Order)
            int[] arr4 = { 4, 5, 2, 25, 7, 8 };
            GetNextLargestElementToRight(arr4).ShouldBe(new int[] { 5, 25, 25, -1, 8, -1 });
        }

        static int[] GetNextLargestElementToRight(int[] arr)
        {
            Stack<int> stack = new Stack<int>();
            int[] result = new int[arr.Length];

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() <= arr[i])
                {
                    stack.Pop();
                }

                result[i] = stack.Count > 0 ? stack.Peek() : -1;

                stack.Push(arr[i]);
            }

            return result;
        }

        static int[] GetNextLargestElementToLeft(int[] arr)
        {
            int[] result = new int[arr.Length];
            Stack<int> stack = new Stack<int>();
            // 1, 3, 0, 0, 1, 2, 4
            for (int i = 0; i< arr.Length; i++)
            {
                while(stack.Count > 0 && arr[i] >= stack.Peek())
                {
                    stack.Pop();
                }

                result[i] = stack.Count == 0 ? -1 : stack.Peek();

                stack.Push(arr[i]);
            }

            return result;
        }
    }
}
