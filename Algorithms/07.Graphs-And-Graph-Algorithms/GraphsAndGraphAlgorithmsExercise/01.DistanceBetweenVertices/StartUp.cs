namespace _01.DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static Dictionary<int, List<int>> graph;
        private static Dictionary<int, bool> visited;
        private static int distance;
        private static int shortestDistance;

        public static void Main()
        {
            int numberOfVertices = int.Parse(Console.ReadLine());
            int numberOfPairs = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();

            BuildGraph(numberOfVertices);

            for (int i = 0; i < numberOfPairs; i++)
            {
                int[] nodesInfo = Console.ReadLine()
                    .Split('-')
                    .Select(int.Parse)
                    .ToArray();
                int start = nodesInfo[0];
                int end = nodesInfo[1];

                distance = default(int);
                shortestDistance = int.MaxValue;
                visited = new Dictionary<int, bool>();

                PopulateVisitedDictionary();

                FindDistance(start, end);

                if (shortestDistance == int.MaxValue)
                {
                    shortestDistance = -1;
                }

                Console.WriteLine("{" + $"{start}, {end}" + "} -> " + $"{shortestDistance}");
            }
        }

        private static void PopulateVisitedDictionary()
        {
            foreach (var node in graph)
            {
                visited.Add(node.Key, false);
            }
        }

        private static void FindDistance(int current, int end)
        {
            visited[current] = true;
            distance++;

            foreach (var child in graph[current])
            {
                if (visited[child])
                {
                    continue;
                }

                if (child == end)
                {
                    shortestDistance = Math.Min(distance, shortestDistance);
                    break;
                }

                FindDistance(child, end);
            }

            visited[current] = false;
            distance--;
        }

        private static void BuildGraph(int numberOfVertices)
        {
            for (int i = 0; i < numberOfVertices; i++)
            {
                string[] nodeInfo = Console.ReadLine()
                    .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                int node = int.Parse(nodeInfo[0]);
                graph.Add(node, new List<int>());

                if (nodeInfo.Length < 2)
                {
                    continue;
                }

                int[] children = nodeInfo[1]
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                foreach (var child in children)
                {
                    graph[node].Add(child);
                }
            }
        }
    }
}
