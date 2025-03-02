using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurePractice.Recursion.Problems
{
    internal class TowerOfHanoi
    {

        //        The Towers of Hanoi is a mathematical puzzle.It consists of three rods(or pegs or
        //        towers), and a number of disks of different sizes which can slide onto any rod.The puzzle starts
        //        with the disks on one rod in ascending order of size, the smallest at the top, thus making a conical
        //        shape.The objective of the puzzle is to move the entire stack to another rod, satisfying the
        //        following rules:
        //        • Only one disk may be moved at a time.
        //        • Each move consists of taking the upper disk from one of the rods and sliding it onto
        //        another rod, on top of the other disks that may already be present on that rod.
        //        • No disk may be placed on top of a smaller disk.

        public static void Execute()
        {
            RunTowerOfHanoi(3, "Source", "Aux", "Destination");
        }

        static void RunTowerOfHanoi(int num, string source, string helper, string dest)
        {
            if (num > 0)
            {
                RunTowerOfHanoi(num - 1, source, dest, helper);
                Console.WriteLine($"Disk {num} moved from {source} to {dest}");

                RunTowerOfHanoi(num - 1, helper, source, dest);
            }
        }
    }
}
