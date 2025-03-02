using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurePractice.Graph.Problems
{
    public class FloodFill
    {
        //https://leetcode.com/problems/flood-fill/
        public int[][] SolveFloodFill(int[][] image, int sr, int sc, int color)
        {
            if (image == null || image.Length == 0)
                return image;

            int currentColor = image[sr][sc];

            if (currentColor == color)
                return image;

            int rows = image.Length, columns = image[0].Length;

            int[][] directions = new int[][]
            {
            new int[] {0, 1},
            new int[] {1, 0},
            new int[] {0, -1},
            new int[] {-1, 0}
            };

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((sr, sc));
            image[sr][sc] = color;

            while (queue.Count > 0)
            {
                var (r,c) = queue.Dequeue();

                foreach (var direction in directions)
                {
                    int nr = r + direction[0], nc = c + direction[1];

                    if(nr >= 0 && nr < rows && nc >= 0 && nc < columns && image[nr][nc] == currentColor)
                    {
                        image[nr][nc] = color;
                        queue.Enqueue((nr, nc));
                    }
                }
            }

            return image;
        }
    }
}
