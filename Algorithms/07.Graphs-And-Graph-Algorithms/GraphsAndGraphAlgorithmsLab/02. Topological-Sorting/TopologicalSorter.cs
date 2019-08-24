using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public ICollection<string> TopSort()
    {
        List<string> result = new List<string>();

        int previousGraphCount = graph.Count;

        while (graph.Count > 0)
        {
            HashSet<string> dependent = new HashSet<string>(
                graph
                .Values
                .SelectMany(x => x));

            List<string> nodesToRemove = new List<string>();

            foreach (var node in graph)
            {
                if (dependent.Contains(node.Key))
                {
                    continue;
                }

                result.Add(node.Key);
                nodesToRemove.Add(node.Key);
            }

            foreach (var node in nodesToRemove)
            {
                graph.Remove(node);
            }

            if (graph.Count == previousGraphCount)
            {
                throw new InvalidOperationException();
            }

            previousGraphCount = graph.Count;
        }

        return result;
    }
}
