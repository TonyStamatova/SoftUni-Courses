namespace _05.BreakCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private static List<Edge> edges;
        private static List<Edge> removedEdges;

        public static void Main()
        {
            edges = new List<Edge>();
            BuildGraph();

            removedEdges = new List<Edge>();

            IOrderedEnumerable<Edge> orderedEdges = edges
                .OrderBy(e => e.Nodes[0])
                 .ThenBy(e => e.Nodes[1]);

            foreach (var edge in orderedEdges)
            {
                edges.Remove(edge);
                TryFindPathBetweenVertices(edge);
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Edges to remove: {removedEdges.Count}");

            foreach (var edge in removedEdges)
            {
                sb.AppendLine(edge.ToString());
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static void TryFindPathBetweenVertices(Edge edgeToCheck)
        {
            string start = edgeToCheck.Nodes[0];
            string end = edgeToCheck.Nodes[1];

            Queue<Edge> children = new Queue<Edge>(edges.Where(e => e.Nodes.Contains(start)));
            HashSet<Edge> visited = new HashSet<Edge>();

            while (children.Count > 0)
            {
                Edge nextEdge = children.Dequeue();
                visited.Add(nextEdge);

                if (nextEdge.Nodes.Contains(end))
                {
                    removedEdges.Add(edgeToCheck);
                    break;
                }

                foreach (var edge in edges
                    .Where(e => !visited.Contains(e)
                        && (e.Nodes.Contains(nextEdge.Nodes[0]) || e.Nodes.Contains(nextEdge.Nodes[1]))))
                {
                    children.Enqueue(edge);
                }
            }
        }

        private static void BuildGraph()
        {
            string input = Console.ReadLine();

            while (input != null && input != string.Empty)
            {
                string[] edgeInfo = input
                    .Split(new char[] { '-', '>' })
                    .Select(s => s.Trim())
                    .ToArray();

                string start = edgeInfo[0];
                string[] connections = edgeInfo[2].Split(' ');

                List<Edge> newEdges = new List<Edge>();

                foreach (var node in connections)
                {
                    Edge newEdge = new Edge(start, node);

                    if (!edges.Contains(newEdge))
                    {
                        newEdges.Add(newEdge);
                    }
                }

                foreach (var edge in newEdges)
                {
                    edges.Add(edge);
                }

                input = Console.ReadLine();
            }
        }
    }

    public class Edge
    {
        public Edge(string firstNode, string secondNode)
        {
            this.Nodes = new string[] { firstNode, secondNode };
            Array.Sort(Nodes);
        }

        public string[] Nodes { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Edge edge &&
                   this.Nodes[0] == edge.Nodes[0] &&
                   this.Nodes[1] == edge.Nodes[1];
        }

        public override int GetHashCode()
        {
            return this.Nodes[0].GetHashCode() + this.Nodes[1].GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.Nodes[0]} - {this.Nodes[1]}";
        }
    }
}
