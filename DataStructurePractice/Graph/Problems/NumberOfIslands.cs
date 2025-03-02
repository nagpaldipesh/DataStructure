
using Microsoft.Win32.SafeHandles;
using Shouldly;
using System.Data;

namespace DataStructurePractice.Graph.Problems
{
    public class NumberOfIslands
    {
        public static void Execute()
        {
            int[][] grid = {
                new int[] {0, 1},
                new int[] {1, 0},
                new int[] {1, 1},
                new int[] {1, 0}
            };

            BFS(grid).ShouldBe(1);

            int[][] grid2 = {
                new int[] {0,1,1,1,0,0,0},
                new int[] {0,0,1,1,0,1,0},
            };

            BFS(grid2).ShouldBe(2);
        }

        static int GetNumberOfIslands(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int islandsCount = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        islandsCount++;
                        DFS(grid, rows, cols, i, j);
                    }
                }
            }

            return islandsCount;
        }

        static void DFS(int[][] grid, int rows, int columns, int r, int c)
        {
            if (r >= rows || r < 0 || c >= columns || c < 0 || grid[r][c] == 0)
            {
                return;
            }

            grid[r][c] = 0;

            int[][] directions = new int[][]
            {
                new int[] { 0, -1 }, //Left
                new int[] { 0, 1 }, //Right
                new int[] { -1, 0 }, //Up
                new int[] { 1, 0 }, //Down
                new int[] { -1, -1 }, //Diagonal
                new int[] { -1, 1 }, //Diagonal
                new int[] { 1, -1 }, //Diagonal
                new int[] { 1, 1 }, //Diagonal
            };

            foreach (int[] direction in directions)
            {
                DFS(grid, rows, columns, r + direction[0], c + direction[1]);
            }
        }

        static int BFS(int[][] grid)
        {
            int islandCount = 0;
            int rows = grid.Length;
            int columns = grid[0].Length;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {

                    if (grid[r][c] == 1)
                    {
                        islandCount++;

                        Queue<(int, int)> queue = new Queue<(int, int)>();
                        queue.Enqueue((r, c));

                        while (queue.Count > 0)
                        {
                            var (i, j) = queue.Dequeue();
                            grid[i][j] = 0;

                            int[][] directions = {
                            new int[] {-1, 0}, new int[] {1, 0}, new int[] {0, -1}, new int[] {0, 1},
                            new int[] {-1, -1}, new int[] {1, -1}, new int[] {-1, 1}, new int[] {1, 1}
                            };

                            foreach (var direction in directions)
                            {
                                int nr = i + direction[0], nc = j + direction[1];

                                if (nr >= 0 && nr < rows && nc >= 0 && nc < columns && grid[nr][nc] == 1)
                                {
                                    queue.Enqueue((nr, nc));
                                }
                            }
                        }

                    }
                }
            }

            return islandCount;
        }
    }
}
