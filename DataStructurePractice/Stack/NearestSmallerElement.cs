using Shouldly;

namespace DataStructurePractice.Stack
{
    public class NearestSmallerElement
    {
        public static void Execute()
        {
            ExecuteNearestSmallerElementFromLeft();
            ExecuteNearestSmallerElementFromRight();
        }

        public static void ExecuteNearestSmallerElementFromRight()
        {
            int[] arr = { 1, 3, 0, 2, 5 };
            ExecuteNearestSmallestNumberFromRight(arr).ShouldBe(new int[] { 0, 0, -1, -1, -1 });

            //Test Case 2 (Strictly Increasing Order)
            int[] arr2 = { 1, 2, 3, 4, 5 };
            ExecuteNearestSmallestNumberFromRight(arr2).ShouldBe(new int[] { -1, -1, -1, -1, -1 });

            //Test Case 3 (Strictly Decreasing Order)
            int[] arr3 = { 5, 4, 3, 2, 1 };
            ExecuteNearestSmallestNumberFromRight(arr3).ShouldBe(new int[] { 4, 3, 2, 1, -1 });

            //Test Case 4 (Random Order)
            int[] arr4 = { 4, 5, 2, 10, 8, 1 };
            ExecuteNearestSmallestNumberFromRight(arr4).ShouldBe(new int[] { 2, 2, 1, 8, 1, -1 });
        }

        public static void ExecuteNearestSmallerElementFromLeft()
        {
            int[] arr = { 1, 3, 0, 2, 5 };
            NearestSmallerElementFromLeft(arr).ShouldBe(new int[] { -1, 1, -1, 0, 2 });

            //Test Case 2 (Strictly Increasing Order)
            int[] arr2 = { 1, 2, 3, 4, 5 };
            NearestSmallerElementFromLeft(arr2).ShouldBe(new int[] { -1, 1, 2, 3, 4 });

            //Test Case 3 (Strictly Decreasing Order)
            int[] arr3 = { 5, 4, 3, 2, 1 };
            NearestSmallerElementFromLeft(arr3).ShouldBe(new int[] { -1, -1, -1, -1, -1 });

            //Test Case 4 (Random Order)
            int[] arr4 = { 4, 5, 2, 10, 8, 1 };
            NearestSmallerElementFromLeft(arr4).ShouldBe(new int[] { -1, 4, -1, 2, 2, -1 });
        }

        static int[] NearestSmallerElementFromLeft(int[] arr)
        {
            int[] result = new int[arr.Length];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                while(stack.Count > 0 && stack.Peek() >= arr[i])
                {
                    stack.Pop();
                }

                result[i] = stack.Count == 0 ? -1 : stack.Peek();

                stack.Push(arr[i]);
            }

            return result;
        }

        static int[] ExecuteNearestSmallestNumberFromRight(int[] arr)
        {
            int[] result = new int[arr.Length];
            Stack<int> stack = new Stack<int>();

            for(int i = arr.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() >= arr[i])
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
