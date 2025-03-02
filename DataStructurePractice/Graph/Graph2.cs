
namespace DataStructurePractice.Graph
{
    public class Graph2
    {
        private int vertices;
        private List<int>[] adjecentNodes;

        public Graph2(int vertices)
        {
            this.vertices = vertices;
            adjecentNodes = new List<int>[vertices];

            for (int i = 0; i < vertices; i++)
            {
                adjecentNodes[i] = new List<int>();
            }
        }

        public void AddEdge(int u, int v)
        {
            adjecentNodes[u].Add(v);
            adjecentNodes[v].Add(u);
        }

        public void DFS(int node, bool[] visited, List<int> component)
        {
            visited[node] = true;
            component.Add(node);
            var neighbors = adjecentNodes[node];

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
            visited[start] = true;

            while(queue.Count > 0)
            {
                int node = queue.Dequeue();
                component.Add(node);

                foreach (var neighor in adjecentNodes[node].OrderBy(item => item))
                {
                    if(!visited[neighor])
                    {
                        visited[neighor] = true;
                        queue.Enqueue(neighor);
                    }
                }
            }
        }

        public List<List<int>> GetConnectedComponents()
        {
            List<List<int>> components = new List<List<int>>();
            bool[] visited = new bool[vertices];

            for (int i = 0;i< vertices;i++)
            {
                if (!visited[i])
                {
                    List<int> component = new List<int>();

                    BFS(i, visited, component);
                    component.Sort((a,b) => a.CompareTo(b));
                    components.Add(component);
                }
            }

            return components;
        }
    }
}
