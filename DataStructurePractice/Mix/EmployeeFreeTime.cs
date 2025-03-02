using Shouldly;
using System.Collections.Generic;

namespace DataStructurePractice.Mix
{
    internal class EmployeeFreeTime
    {

        public static void Execute()
        {
            // Three employees with the following busy intervals:
            List<List<int[]>> schedules = new List<List<int[]>>
            {
                // Employee 1
                new List<int[]> { new int[] {1, 3}, new int[] {6, 7} },
                
                // Employee 2
                new List<int[]> { new int[] {2, 4} },
                
                // Employee 3
                new List<int[]> { new int[] {2, 5}, new int[] {9, 12} }
            };


            var freeTime = GetEmployeeFreeTime(schedules);

            // Free time intervals
            List<int[]> expectedFreeTime = new List<int[]>
            {
                new int[] {0, 1},
                new int[] {5, 6},
                new int[] {7, 9}
            };

            freeTime.ShouldBe(expectedFreeTime);

            // Three employees with the following busy intervals:
            List<List<int[]>> schedules2 = new List<List<int[]>>
            {
                // Employee 1
                new List<int[]> { new int[] {1, 2}, new int[] {5, 6} },
                
                // Employee 2
                new List<int[]> { new int[] {1, 3} },
                
                // Employee 3
                new List<int[]> { new int[] {4, 10} }
            };

            List<int[]> expectedFreeTime2 = new List<int[]>
            {
                new int[] {0, 1},
                new int[] {3, 4}
            };

            var freeTime2 = GetEmployeeFreeTime(schedules2);
            freeTime2.ShouldBe(expectedFreeTime2);

            // ---------------------------------------------------------------

            var schedules3 = new List<List<int>> {
                new List<int> { 10, 20 }
            };

            var schedules4 = new List<List<int>> {
                new List<int> { 1, 2, 5, 6 },
                new List<int> { 1, 2 },
                new List<int> { 5, 10 }
            };

            var result3 = GetEmployeeFreeTime(schedules3);  // Output: 0 9 21 100000000

            List<int> expectedFreeTime3 = new List<int>
            {
                0, 9, 21, 100000000
            };

            var result4 = GetEmployeeFreeTime(schedules4); // Output: 0 0 3 4 11 100000000

            var expectedFreeTime4 = new List<int>
            {
                0, 3, 4,11, 100000000
            };

        }

        static List<int[]> GetEmployeeFreeTime(List<List<int[]>> schedules)
        {
            List<int[]> intervals = new List<int[]>();
            foreach (var schedule in schedules)
            {
                intervals.AddRange(schedule);
            }

            //Sort the intervals in accending order
            intervals.Sort((a, b) => a[0].CompareTo(b[0]));

            List<int[]> result = new List<int[]>();
            int end = 0;

            foreach (var schedule in intervals)
            {
                if (schedule[0] > end)
                {
                    result.Add(new int[] { end, schedule[0] });
                }

                end = Math.Max(end, schedule[1]);
            }

            return result;
        }

        //Type 2
        static List<int> GetEmployeeFreeTime(List<List<int>> schedules)
        {
            List<int[]> intervals = new List<int[]>();

            foreach (var schedule in schedules)
            {
                for (int i = 0; i < schedule.Count; i += 2)
                {
                    intervals.Add(new int[] { schedule[i], schedule[i + 1] });
                }
            }

            intervals.Sort((a, b) => a[0].CompareTo(b[0]));

            List<int> result = new List<int>();
            int end = 0;

            foreach (var schedule in intervals)
            {
                if (schedule[0] > end)
                {
                    result.Add(end);
                    result.Add(schedule[0] - 1);
                }

                end = Math.Max(end, schedule[1] + 1);
            }

            if (end < 100000000)
            {
                result.Add(end);
                result.Add(100000000);
            }

            return result;
        }
    }
}
