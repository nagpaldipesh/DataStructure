
namespace DataStructurePractice.Graph.Problems
{
    public class RouteBetweenNodes
    {
        //Route Between Nodes: Given a directed graph, design an algorithm to find out whether there is a
        //route between two nodes.

        public static bool FindRouteBetweenNodes(List<int>[] adjList, int src, int dest)
        {
            if (adjList.Length == 0)
                return false;

            if (src == dest)
                return true;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(src);
            bool[] visited = new bool[adjList.Length];
            visited[src] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                var adjNodes = adjList[node];

                if (adjNodes == null)
                    continue;

                foreach (int adjNode in adjNodes)
                {
                    if (adjNode == dest)
                        return true;

                    if (!visited[adjNode])
                    {
                        visited[node] = true;
                        queue.Enqueue(adjNode);
                    }
                }
            }

            return false;
        }
    }
}
