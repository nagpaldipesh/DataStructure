﻿using Shouldly;

namespace DataStructurePractice.Stack
{
    internal class StockSpanProblem
    {

        //https://www.geeksforgeeks.org/the-stock-span-problem/

        //The stock span problem is a financial problem where we have a series of n daily price quotes for a stock and we need to calculate the span of stock’s price for all n days.

        //The span Si of the stock’s price on a given day i is defined as the maximum number of consecutive days just before the given day, for which the price of the stock on the current day is less than or equal to its price on the given day.

        //For example, if an array of 7 days prices is given as {100, 80, 60, 70, 60, 75, 85}, then the span values for corresponding 7 days are {1, 1, 1, 2, 1, 4, 6}

        public static void Execute()
        {
            int[] stockSpans = { 100, 80, 60, 70, 60, 75, 85 };

            StockSpanSolution(stockSpans).ShouldBe(new int[] { 1, 1, 1, 2, 1, 4, 6});
        }

        static int[] StockSpanSolution(int[] stockSpan)
        {
            int[] result = new int[stockSpan.Length];
            Stack<int> stack = new Stack<int>();
            
            for (int i = 0; i < stockSpan.Length; i++)
            {
                while (stack.Count > 0 && stockSpan[stack.Peek()] <= stockSpan[i])
                {
                    stack.Pop();
                }

                result[i] = stack.Count == 0 ? i + 1 : i - stack.Peek() ;
                stack.Push(i);
            }

            return result;
        }
    }
}
