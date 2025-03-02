using DataStructurePractice.Graph.Problems.Knight;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurePractice.Mix.TrappingRainWater
{
    public class TrappingRainWater
    {
        public static void Execute()
        {
            Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }).ShouldBe(6);
            Trap(new int[] { 4, 2, 0, 3, 2, 5 }).ShouldBe(9);
            TrapWater(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }).ShouldBe(6);
            TrapWater(new int[] { 4, 2, 0, 3, 2, 5 }).ShouldBe(9);
        }

        static int Trap(int[] height)
        {
            int trapWater = 0;

            if (height.Length < 1)
            {
                return trapWater;
            }

            Stack<int> maxHeight = new Stack<int>();

            maxHeight.Push(height[0]);

            for (int i = 1; i < height.Length; i++)
            {
                if (height[i] >= maxHeight.Peek())
                {
                    maxHeight.Push(height[i]);
                }
            }

            int maxHeightFromRight = height[height.Length - 1];

            for (int i = height.Length - 1; i > 0; i--)
            {
                if (height[i] == maxHeight.Peek())
                {
                    maxHeight.Pop();
                }

                if (maxHeightFromRight < height[i])
                {
                    maxHeightFromRight = height[i];
                }
                else if (height[i] < maxHeight.Peek() && height[i] < maxHeightFromRight)
                {
                    trapWater += Math.Min(maxHeight.Peek(), maxHeightFromRight) - height[i];
                }
            }

            return trapWater;
        }

        static int TrapWater(int[] height)
        {
            int trapWater = 0;

            // If the height array is empty, no water can be trapped
            if (height.Length == 0)
            {
                return trapWater;
            }

            Stack<int> stack = new Stack<int>();  // Stack to store indices of the bars
            int i = 0;

            // Iterate through the heights to find trapped water
            while (i < height.Length)
            {
                // If the stack is empty or current height is greater than the height of the bar at stack top
                // Push current index to the stack
                if (stack.Count == 0 || height[i] <= height[stack.Peek()])
                {
                    stack.Push(i++);
                }
                else
                {
                    // Pop from the stack and calculate trapped water
                    int top = stack.Pop();

                    if (stack.Count == 0) continue; // No left boundary for the current top bar

                    int distance = i - stack.Peek() - 1; // Distance between current bar and the bar at stack's new top
                    int boundedHeight = Math.Min(height[i], height[stack.Peek()]) - height[top]; // Minimum of left and right heights

                    // If the bounded height is positive, water can be trapped
                    if (boundedHeight > 0)
                    {
                        trapWater += distance * boundedHeight;
                    }
                }
            }
            return trapWater;
        }
    }
}
