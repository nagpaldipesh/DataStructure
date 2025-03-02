using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurePractice.Graph.Problems.Knight
{
    internal class Knight
    {
        public static void Execute()
        {
            int N = 30;
            int[] knightPos = { 1, 1 };
            int[] targetPos = { 30, 30 };
            Console.WriteLine(MinStepToReachTarget(knightPos, targetPos, N));
        }

        //https://www.geeksforgeeks.org/minimum-steps-reach-target-knight/
        //https://www.baeldung.com/cs/knights-shortest-path-chessboard
        //The "Brave Knight" problem in DSA usually involves a chessboard and a knight’s movement, requiring pathfinding or shortest path algorithms

        //Since this is an unweighted shortest path problem on a grid, we can use Breadth-First Search (BFS) to find the minimum number of moves.
        static int MinStepToReachTarget(int[] knightPos, int[] targetPos, int N)
        {
            //int[] dx = { -2, -1 - 1, -2, 2, 1, 2, 1 };
            //int[] dy = { -1, -2, 2, 1, 1, 2, -1, -2 };

            int[][] directions = new int[][]
            {
                new int[] {-2, -1 },
                new int[] {-1, -2 },
                new int[] { 1, -2 },
                new int[] {-1,  2 },
                new int[] {-2,  1 },
                new int[] { 2, -1 },
                new int[] { 1,  2 },
                new int[] { 2,  1 },
            };

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((knightPos[0], knightPos[1]));
            int[,] visited = new int[N + 1, N + 1];
            visited[knightPos[0], knightPos[1]] = 1;

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();

                if (x == targetPos[0] && y == targetPos[1])
                {
                    return visited[x, y] - 1;
                }

                foreach (var direction in directions)
                {
                    int nx = x + direction[0], ny = y + direction[1];

                    if (nx >= 1 && nx <= N && ny >= 1 && ny <= N && visited[nx, ny] == 0)
                    {
                        visited[nx, ny] = visited[x, y] + 1;
                        queue.Enqueue((nx, ny));
                    }
                }
            }
            return -1;
        }
        //static int MinStepToReachTarget(int[] knightPos, int[] targetPos, int N)
        //{
        //    int[] dx = { -2, -1, 1, 2, -2, -1, 1, 2 };
        //    int[] dy = { -1, -2, -2, -1, 1, 2, 2, 1 };

        //    Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
        //    q.Enqueue(new Tuple<int, int>(knightPos[0], knightPos[1]));
        //    int[,] visited = new int[N + 1, N + 1];
        //    for (int i = 0; i <= N; i++)
        //    {
        //        for (int j = 0; j <= N; j++)
        //        {
        //            visited[i, j] = 0;
        //        }
        //    }
        //    visited[knightPos[0], knightPos[1]] = 1;
        //    while (q.Count > 0)
        //    {
        //        Tuple<int, int> t = q.Dequeue();
        //        int x = t.Item1;
        //        int y = t.Item2;
        //        if (x == targetPos[0] && y == targetPos[1])
        //        {
        //            return visited[x, y] - 1;
        //        }
        //        for (int i = 0; i < 8; i++)
        //        {
        //            int x1 = x + dx[i];
        //            int y1 = y + dy[i];
        //            if (x1 >= 1 && x1 <= N && y1 >= 1 && y1 <= N && visited[x1, y1] == 0)
        //            {
        //                visited[x1, y1] = visited[x, y] + 1;
        //                q.Enqueue(new Tuple<int, int>(x1, y1));
        //            }
        //        }
        //    }
        //    return -1;
        //}
    }
}
