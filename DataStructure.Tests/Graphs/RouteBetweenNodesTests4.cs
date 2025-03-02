using DataStructurePractice.Graph.Problems;
using Shouldly;

namespace DataStructure.Tests.Graphs
{
    internal class RouteBetweenNodesTests
    {
        private List<int>[] graph;
        
        [SetUp]
        public void SetUp()
        {
            graph = new List<int>[7];
            for (int i = 0; i < 6; i++)
                graph[i] = new List<int>();

            graph[1].Add(2);
            graph[1].Add(3);
            graph[2].Add(4);
            graph[4].Add(5);
        }

        [Test]
        public void RouteExists_ShouldReturnTrue()
        {
            RouteBetweenNodes.FindRouteBetweenNodes(graph, 1, 5).ShouldBeTrue(); // Path: 1 → 2 → 4 → 5
        }

        [Test]
        public void RouteDoesNotExist_ShouldReturnFalse()
        {
            RouteBetweenNodes.FindRouteBetweenNodes(graph, 3, 5).ShouldBeFalse(); // No path from 3 to 5
        }

        [Test]
        public void SameNode_ShouldReturnTrue()
        {
            RouteBetweenNodes.FindRouteBetweenNodes(graph, 2, 2).ShouldBeTrue(); // A node is always reachable from itself
        }

        [Test]
        public void DisconnectedGraph_ShouldReturnFalse()
        {
            graph[6] = new List<int> { 7 }; // Separate component (6 → 7)
            RouteBetweenNodes.FindRouteBetweenNodes(graph, 1, 7).ShouldBeFalse(); // No path from 1 to 7
        }
    }
}
