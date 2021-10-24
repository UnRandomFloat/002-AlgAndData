using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    public class Edge
    {

        public GraphNode ConnectedNode { get; }
        public int EdgeWeight { get; }

        public Edge(GraphNode connectedVertex, int weight)
        {
            ConnectedNode = connectedVertex;
            EdgeWeight = weight;
        }
    }
    public class GraphNode
    {
        public bool isVisited { get; set; } = false;
        public int Name { get; }

        public List<Edge> Edges { get; }

        public GraphNode(int vertexName)
        {
            Name = vertexName;
            Edges = new List<Edge>();
        }

        public void AddEdge(Edge newEdge)
        {
            Edges.Add(newEdge);
        }

        public void AddEdge(GraphNode node, int edgeWeight)
        {
            AddEdge(new Edge(node, edgeWeight));
        }
        
    }

    public class Graph
    {
        public List<GraphNode> Nodes { get; }
        public Graph()
        {
            Nodes = new List<GraphNode>();
        }
        public void AddGraphNode(int vertexName)
        {
            Nodes.Add(new GraphNode(vertexName));
        }
        public GraphNode FindNode(int nodeName)
        {
            foreach (var v in Nodes)
            {
                if (v.Name.Equals(nodeName))
                {
                    return v;
                }
            }

            return null;
        }
        public void AddEdge(int firstName, int secondName, int weight)
        {
            var v1 = FindNode(firstName);
            var v2 = FindNode(secondName);
            if (v2 != null && v1 != null)
            {
                v1.AddEdge(v2, weight);
                v2.AddEdge(v1, weight);
            }
        }
        public Graph GraphCreator()
        {
            Graph GH = new Graph();
            for (int i = 1; i <= 10; i++)
            {
                GH.AddGraphNode(i);
            }
            Console.WriteLine($"Добавлено 10 узлов графа, для добавления ребер нажми Enter");
            Console.ReadLine();
            GH.AddEdge(1, 2, 1);
            GH.AddEdge(1, 3, 1);
            GH.AddEdge(2, 4, 1);
            GH.AddEdge(2, 5, 1);
            GH.AddEdge(4, 5, 1);
            GH.AddEdge(5, 6, 1);
            GH.AddEdge(3, 6, 1);
            GH.AddEdge(3, 7, 1);
            GH.AddEdge(6, 8, 1);
            GH.AddEdge(5, 8, 1);
            GH.AddEdge(5, 9, 1);
            GH.AddEdge(4, 9, 1);
            GH.AddEdge(6, 10, 1);
            Console.WriteLine($"Добавлены ребра графа, нажми Enter для выбора способа обхода");
            Console.ReadLine();
            return GH;
        }
    }
}