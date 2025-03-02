using Shouldly;

namespace DataStructurePractice.Stack
{
    public class StockProblem
    {
        public static void Execute()
        {
            GetStockSpan(new int[] { 100, 80, 60, 70, 60, 75, 80 }).ShouldBe(new int[] { 1, 1, 1, 2, 1, 4, 6 });

            //Console.WriteLine(string.Join(result, " ,"));
        }

        static int[] GetStockSpan(int[] arr)
        {
            int[] result = new int[arr.Length];
            Stack<int> greatestNumOnLeft = new Stack<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                while (greatestNumOnLeft.Count > 0 && arr[i] >= arr[greatestNumOnLeft.Peek()])
                {
                    greatestNumOnLeft.Pop();
                }

                result[i] = greatestNumOnLeft.Count == 0 ? 1 : i - greatestNumOnLeft.Peek();

                greatestNumOnLeft.Push(i);
            }

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    result[i] = i - result[i];
            //}

            return result;
        }
    }
}
