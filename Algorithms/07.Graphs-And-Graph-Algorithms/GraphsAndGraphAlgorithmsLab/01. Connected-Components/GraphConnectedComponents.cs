using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    static List<int>[] graph;
    static bool[] visited;

    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    private static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
        }
        return graph;
    }

    private static void FindGraphConnectedComponents()
    {
        visited = new bool[graph.Length];

        for (int node = 0; node < graph.Length; node++)
        {
            if (visited[node])
            {
                continue;
            }

            Console.Write("Connected component:");

            PerformDFSForCurrentNode(node);

            Console.WriteLine();
        }
    }

    private static void PerformDFSForCurrentNode(int node)
    {
        visited[node] = true;

        List<int> connections = graph[node];

        foreach (var connection in connections.Where(c => !visited[c]))
        {
            PerformDFSForCurrentNode(connection);
        }

        Console.Write($" {node}");
    }
}
