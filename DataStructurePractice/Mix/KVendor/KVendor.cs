using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataStructurePractice.Mix.KVendor
{
    public class KVendor
    {

        public static void Execute()
        {
            int[] arr = { 20, 10, 50, 30, 40 };
            MinCostSelection(arr, 1).ShouldBe(10);
            MinCostSelection(arr, 2).ShouldBe(30);
            MinCostSelection(arr, 3).ShouldBe(60);

            int[] arr2 = { 5, 15, 25, 35, 45, 55 };
            MinCostSelection(arr2, 2).ShouldBe(20);

            int[] arr3 = { 1, 2, 3, 4, 5 };
            MinCostSelection(arr3, 4).ShouldBe(10);

            int[] arr4 = { 100, 200, 300, 400, 500 };
            MinCostSelection(arr4, 1).ShouldBe(100);
            MinCostSelection(arr4, 3).ShouldBe(600);

            int[] arr5 = { -5, -10, -3, -1, -7 };
            MinCostSelection(arr5, 2).ShouldBe(-17);

            int[] sameNumbers = { 10, 10, 10, 10, 10 };
            MinCostSelection(sameNumbers, 3).ShouldBe(30);

            MinimumCostToSticks(new int[] { 2, 4, 3 }).ShouldBe(14);

            MinimumCostToSticks(new int[] { 1, 8, 3, 5 }).ShouldBe(30);
            MinimumCostToSticks(new int[] { 5 }).ShouldBe(0);
        }

        //The K Vendor Problem(Minimum Cost Selection of Vendors) is an optimization problem where we aim to select K vendors from a given set while minimizing the total cost.

        //Problem Statement:
        //Given N vendors, each offering a product at different prices, we must select exactly K vendors such that the total cost is minimized.
        static int MinCostSelection(int[] arr, int K)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();


            for (int i = 0; i < arr.Length; i++)
            {
                pq.Enqueue(arr[i], arr[i]);
            }

            int minCost = 0;

            for (int i = 0; i < K; i++)
            {
                minCost += pq.Dequeue();
            }
            return minCost;
        }

        //        You have some number of sticks with positive integer lengths.These lengths are given as an array sticks, where sticks[i] is the length of the ith stick.

        //You can connect any two sticks of lengths x and y into one stick by paying a cost of x + y.You must connect all the sticks until there is only one stick remaining.

        //Return the minimum cost of connecting all the given sticks into one stick in this way.



//        Example 1
//Input:
//plaintext
//Copy
//Edit
//sticks = [2, 4, 3]
//Process of Combining:
//Choose the two smallest sticks: 2 and 3
//Merge them: 2 + 3 = 5
//The total cost so far: 5
//Remaining sticks: [5, 4]
//Choose the two smallest sticks: 4 and 5
//Merge them: 4 + 5 = 9
//The total cost so far: 5 + 9 = 14
//Remaining sticks: [9] (Only one stick left)
//Final Output:
//plaintext
//Copy
//Edit
//Total minimum cost = 14
//Example 2
//Input:
//plaintext
//Copy
//Edit
//sticks = [1, 8, 3, 5]
//Process of Combining:
//Choose the two smallest sticks: 1 and 3

//Merge them: 1 + 3 = 4
//Cost so far: 4
//Remaining sticks: [4, 8, 5]
//Choose the two smallest sticks: 4 and 5

//Merge them: 4 + 5 = 9
//Cost so far: 4 + 9 = 13
//Remaining sticks: [9, 8]
//Choose the two smallest sticks: 8 and 9

//Merge them: 8 + 9 = 17
//Cost so far: 4 + 9 + 17 = 30
//Remaining sticks: [17] (Only one stick left)
//Final Output:
//plaintext
//Copy
//Edit
//Total minimum cost = 30

//Input: sticks = [5]
//Output: 0
//Explanation: There is only one stick, so you don't need to do anything. The total cost is 0.

        static int MinimumCostToSticks(int[] sticks)
        {
            int minCost = 0;

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            foreach(int stick in sticks)
            {
                pq.Enqueue(stick, stick);
            }

            while (pq.Count > 1)
            {
                int stick1 = pq.Dequeue();
                int stick2 = pq.Dequeue();
                int sum = stick1 + stick2;
                minCost += sum;
                pq.Enqueue(sum, sum);
            };

            return minCost;
        }
    }
}
