using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurePractice.Graph
{
    internal class GraphExecute
    {
        public static void Execute()
        {
            int V = 7;
            //var graph = new GraphMatrix(6,2);

            // Adding edges
            //graph.AddEdge(0, 1);
            //graph.AddEdge(0, 6);
            //graph.AddEdge(1, 6);
            //graph.AddEdge(2, 3);
            //graph.AddEdge(2, 4);
            //graph.AddEdge(3, 4);
            //graph.AddEdge(0, 1);
            //graph.AddEdge(1, 2);
            //graph.AddEdge(2, 3);
            Graph graph = new Graph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0); // This edge creates a cycle
            graph.AddEdge(2, 3);

            graph.IsCyclic();

            // Finding connected components
            List<List<int>> connectedComponents = graph.GetConnectedComponents();

            // Printing the components
            Console.WriteLine("Connected Components:");
            foreach (var component in connectedComponents)
            {
                Console.WriteLine(string.Join(" ", component));
            }
        }
    }
}
