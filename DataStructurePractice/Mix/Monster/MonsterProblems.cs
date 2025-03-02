using Shouldly;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructurePractice.Mix.Monster
{
    public class MonsterProblems
    {

        public static void Execute()
        {
            int[] h1 = { 2, 14, 28, 56 };
            MinFinalHealth(h1).ShouldBe(2); // Output: 2

            int[] h2 = { 7, 17, 9, 100, 25 };
            MinFinalHealth(h2).ShouldBe(1); // Output: 1

            int[] h3 = { 5, 5, 5 };
            MinFinalHealth(h3).ShouldBe(5); // Output: 5

            EliminateMaximum(new int[] { 4, 3, 4 }, new int[] { 1, 1, 2 }).ShouldBe(3);
        }

        static int MinFinalHealth(int[] health)
        {
            int result = health[0];

            for (int i = 1; i < health.Length; i++)
            {
                result = GCD(result, health[i]);
            }

            return result;
        }

        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        //        You are playing a video game where you are defending your city from a group of n monsters.You are given a 0-indexed integer array dist of size n,
        //        where dist[i] is the initial distance in kilometers of the ith monster from the city.

        //The monsters walk toward the city at a constant speed. The speed of each monster is given to you in an integer array speed of size n, where speed[i] is the speed of the
        // ith monster in kilometers per minute.

        //You have a weapon that, once fully charged, can eliminate a single monster.However, the weapon takes one minute to charge.The weapon is fully charged at the very start.

        //You lose when any monster reaches your city. If a monster reaches the city at the exact moment the weapon is fully charged, it counts as a loss, and the
        //game ends before you can use your weapon.

        //Return the maximum number of monsters that you can eliminate before you lose, or n if you can eliminate all the monsters before they reach the city.



        //Example 1:

        //Input: dist = [1, 3, 4], speed = [1, 1, 1]
        //Output: 3
        //Explanation:
        //In the beginning, the distances of the monsters are [1, 3, 4]. You eliminate the first monster.
        //        After a minute, the distances of the monsters are [X,2,3]. You eliminate the second monster.
        //        After a minute, the distances of the monsters are [X, X,2]. You eliminate the third monster.
        //All 3 monsters can be eliminated.
        //Example 2:

        //Input: dist = [1, 1, 2, 3], speed = [1, 1, 1, 1]
        //Output: 1
        //Explanation:
        //In the beginning, the distances of the monsters are [1, 1, 2, 3]. You eliminate the first monster.
        //After a minute, the distances of the monsters are [X,0,1,2], so you lose.
        //You can only eliminate 1 monster.
        //Example 3:

        //Input: dist = [3, 2, 4], speed = [5, 3, 2]
        //Output: 1
        //Explanation:
        //In the beginning, the distances of the monsters are [3, 2, 4]. You eliminate the first monster.
        //After a minute, the distances of the monsters are [X,0,2], so you lose.
        //You can only eliminate 1 monster.
        //https://leetcode.com/problems/eliminate-maximum-number-of-monsters/description/

        //        Algorithm:
        //Calculate the time for each monster to reach the city.
        //Sort these times in ascending order.
        //Try eliminating the monsters in sorted order and keep track of the time.
        //Return the number of monsters eliminated.

        static int EliminateMaximum(int[] dist, int[] speed)
        {
            double[] time = new double[dist.Length];

            for (int i = 0; i < dist.Length; i++)
            {
                time[i] = (double) dist[i] / (double) speed[i];
            }

            Array.Sort(time);

            int timeTaken = 0, eliminatedMonster = 0;

            foreach(double i in time)
            {
                if(i > timeTaken++)
                {
                    eliminatedMonster++;
                }
                else
                {
                    break;
                }
            }

            return eliminatedMonster;
        }
    }
}
