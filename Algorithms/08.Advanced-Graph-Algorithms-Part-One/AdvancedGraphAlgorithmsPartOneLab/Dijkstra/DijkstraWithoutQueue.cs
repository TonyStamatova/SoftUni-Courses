using System.Collections.Generic;

public static class DijkstraWithoutQueue
{
    private static int nodesCount;

    private static int[] shortest;
    private static int[] previous;
    private static bool[] visited;

    public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
    {
        nodesCount = graph.GetLength(0);
        shortest = new int[nodesCount];
        previous = new int[nodesCount];
        visited = new bool[nodesCount];

        PopulateShortestLengthsArray();
        PopulatePreviousNodesArray();
        shortest[sourceNode] = 0;

        TreverseNodes(sourceNode, destinationNode, graph);

        return ReconstructSolution(sourceNode, destinationNode);
    }

    private static void PopulatePreviousNodesArray()
    {
        for (int i = 0; i < previous.Length; i++)
        {
            previous[i] = -1;
        }
    }

    private static List<int> ReconstructSolution(int sourceNode, int destinationNode)
    {
        List<int> path = new List<int>();
        path.Add(destinationNode);

        int currentNode = destinationNode;

        while (currentNode != sourceNode)
        {
            if (currentNode == -1)
            {
                return null;
            }

            currentNode = previous[currentNode];
            path.Add(currentNode);
        }

        path.Reverse();
        return path;
    }

    private static void PopulateShortestLengthsArray()
    {
        for (int i = 0; i < shortest.Length; i++)
        {
            shortest[i] = int.MaxValue;
        }
    }

    private static void TreverseNodes(int sourceNode, int destinationNode, int[,] graph)
    {
        if (sourceNode == destinationNode)
        {
            return;
        }

        visited[sourceNode] = true;

        for (int child = 0; child < nodesCount; child++)
        {
            int currentLength = graph[sourceNode, child];

            if (currentLength == 0 || visited[child])
            {
                continue;
            }

            int sumLength = currentLength + shortest[sourceNode];

            if (sumLength < shortest[child])
            {
                shortest[child] = sumLength;
                previous[child] = sourceNode;
            }

            TreverseNodes(child, destinationNode, graph);
        }

        visited[sourceNode] = false;
    }
}
