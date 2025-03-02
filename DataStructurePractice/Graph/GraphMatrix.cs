using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurePractice.Graph
{
    public class GraphMatrix
    {
        private int rows, columns;

        private int[,] adjMatrix;

        public GraphMatrix(int n, int m)
        {
            rows = n;
            columns = m;
            adjMatrix = new int[n,m];
        }

        public void AddEdge(int u, int v)
        {
            if (u < rows && v < columns)
            {
                adjMatrix[u, v] = 1;
                adjMatrix[v, u] = 1; // Ensure it's bidirectional
            }
        }

        //public void DFS(int row, int column, bool[,] visited, List<int> components )
        //{

        //}

        public void DFS(int node, bool[] visited, List<int> component)
        {
            visited[node] = true;
            component.Add(node);

            for (int neighbor = 0; neighbor < columns; neighbor++)
            {
                if (adjMatrix[node, neighbor] == 1 && !visited[neighbor])
                {
                    DFS(neighbor, visited, component);
                }
            }
        }

        public void BFS(int start, bool[] visited, List<int> component)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                component.Add(node);

                for (int neighbor = 0; neighbor < columns; neighbor++)
                {
                    if (adjMatrix[node, neighbor] == 1 && !visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        public List<List<int>> GetConnectedComponents()
        {
            bool[] visited = new bool[rows];
            List<List<int>> components = new List<List<int>>();

            for (int i = 0; i < rows; i++)
            {
                if (!visited[i])
                {
                    List<int> component = new List<int>();
                    BFS(i, visited, component);
                    component.Sort();
                    components.Add(component);
                }
            }

            return components;
        }
    }
}
