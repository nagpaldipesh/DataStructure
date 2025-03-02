using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurePractice.Graph.Problems
{
    public class OrangesRotting
    {
        public static void Execute()
        {
            int[][] grid = {
                new int[] {2, 1, 1},
                new int[] {1, 1, 0},
                new int[] {0, 1, 1}
            };
            Console.WriteLine(GetOrangesRotting(grid));

        }
        static int GetOrangesRotting(int[][] grid)
        {
            int rows = grid.Length, cols = grid[0].Length;

            Queue<(int, int)> queue = new Queue<(int, int)>();
            int freshOrgange = 0, minutes = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        queue.Enqueue((i, j));
                    }
                    else if (grid[i][j] == 1)
                    {
                        freshOrgange++;
                    }
                }
            }

            if (freshOrgange == 0)
                return 0;

            int[][] directions = new int[][] {
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { 0, -1 },
                new int[] { -1, 0 }
            };

            while (queue.Count > 0)
            {
                int size = queue.Count;
                bool hasRotten = false;

                for (int i = 0; i < size; i++)
                {
                    var (r, c) = queue.Dequeue();

                    foreach (var dir in directions)
                    {
                        int nr = r + dir[0], nc = c + dir[1];

                        if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == 1)
                        {
                            grid[nr][nc] = 2;
                            queue.Enqueue((nr, nc));
                            freshOrgange--;
                            hasRotten = true;
                        }
                    }
                }

                if (hasRotten)
                    minutes++;

                // Early exit if no fresh oranges remain
                if (freshOrgange == 0)
                    return minutes;
            }

            return -1;
        }
    }
}