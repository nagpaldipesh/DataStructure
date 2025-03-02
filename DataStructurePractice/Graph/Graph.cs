
namespace DataStructurePractice.Graph
{
    public class Graph
    {
        private int vertices;
        private List<int>[] adjList;

        public Graph(int v)
        {
            vertices = v;
            adjList = new List<int>[vertices];

            for (int i = 0; i < vertices; i++)
            {
                adjList[i] = new List<int>();
            }
        }

        public void AddEdge(int u, int v)
        {
            adjList[u].Add(v);
            adjList[v].Add(u);
        }

        public void DFS(int node, bool[] visited, List<int> component)
        {
            visited[node] = true;
            var neighbors = adjList[node];
            component.Add(node);

//            Console.WriteLine()

            foreach (var neighbor in neighbors)
            {
                if (!visited[neighbor])
                {
                    DFS(neighbor, visited, component);
                }
            }
        }

        public void BFS(int start, bool[] visited, List<int> component)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                visited[node] = true;
                component.Add(node);

                foreach (var neighbor in adjList[node].OrderBy(item => item))
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        public List<List<int>> GetConnectedComponents()
        {
            bool[] visited = new bool[vertices];
            List<List<int>> components = new List<List<int>>();

            for (int i = 0; i < vertices; i++)
            {
                if (!visited[i])
                {
                    List<int> component = new List<int>();
                    BFS(i, visited, component);
                    component.Sort((a, b) => a.CompareTo(b));

                    components.Add(component);
                }
            }

            return components;
        }

        public bool IsCyclic()
        {
            bool[] visited = new bool[vertices];
            bool[] recStack = new bool[vertices];

            for(int i = 0; i < vertices; ++i)
            {
                if(IsCyclicUtil(i, visited, recStack))
                {
                    return true;
                }
            }

            return false;
        }

        bool IsCyclicUtil(int node, bool[] visited, bool[] recStack)
        {
            if(!visited[node])
            {
                visited[node] = true;
                recStack[node] = true;

                foreach(int neighbor in adjList[node])
                {
                    if (!visited[neighbor] && IsCyclicUtil(neighbor, visited, recStack))
                    {
                        return true;
                    }
                    else if (recStack[node])
                    {
                        return true;
                    }
                }
            }
            recStack[node] = false;

            return false;
        }

        // Left => Root => Right
        public static void InOrderBFS(List<int> component, bool[] isVisited, int start)
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(start);
        }

        //static List<List<int>> CreateGraph(int v, int[][] edges)
        //{
        //    List<List<int>> graph = new List<List<int>>();

        //    for (int i = 0; i < v; i++)
        //    {
        //        graph.Add(new List<int>());
        //    }

        //    foreach(var edge in edges)
        //    {
        //        int left = edge[0], right = edge[1];

        //        graph.
        //    }

        //}
    }
}
