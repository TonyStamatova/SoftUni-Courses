using System.Collections.Generic;
using System.Linq;

public static class DijkstraWithPriorityQueue
{
    private static int[] previous;

    public static List<int> DijkstraAlgorithm(
        Dictionary<Node, Dictionary<Node, int>> graph,
        Node sourceNode,
        Node destinationNode)
    {
        PriorityQueue<Node> children = new PriorityQueue<Node>();

        PopulateQueueWithAllNodes(graph, children);

        previous = new int[graph.Count];

        CalculateDistances(graph, sourceNode, children);

        if (destinationNode.DistanceFromStart == double.PositiveInfinity)
        {
            return null;
        }

        return ReconstructSolution(sourceNode, destinationNode);
    }

    private static List<int> ReconstructSolution(
        Node sourceNode,
        Node destinationNode)
    {
        int current = destinationNode.Id;

        List<int> result = new List<int> { destinationNode.Id };

        while (current != sourceNode.Id)
        {
            int previousNode = previous[current];
            result.Add(previousNode);
            current = previousNode;
        }

        result.Reverse();
        return result;
    }

    private static void PopulateQueueWithAllNodes(
        Dictionary<Node, Dictionary<Node, int>> graph,
        PriorityQueue<Node> children)
    {
        foreach (var node in graph.Keys)
        {
            children.Enqueue(node);
        }
    }

    private static void CalculateDistances(
        Dictionary<Node, Dictionary<Node, int>> graph,
        Node sourceNode,
        PriorityQueue<Node> children)
    {
        sourceNode.DistanceFromStart = 0;
        children.DecreaseKey(sourceNode);

        while (children.Count > 0)
        {
            Node parent = children.ExtractMin();

            foreach (var child in graph[parent])
            {
                double newlyCalculatedDistance
                    = parent.DistanceFromStart + child.Value;

                if (newlyCalculatedDistance < child.Key.DistanceFromStart)
                {
                    child.Key.DistanceFromStart = newlyCalculatedDistance;
                    children.DecreaseKey(child.Key);
                    previous[child.Key.Id] = parent.Id;
                }
            }
        }
    }
}

