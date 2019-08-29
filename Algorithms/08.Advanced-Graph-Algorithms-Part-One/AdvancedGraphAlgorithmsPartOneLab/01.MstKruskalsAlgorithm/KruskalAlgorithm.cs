    using System.Collections.Generic;
    using System.Linq;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            List<Edge> forest = new List<Edge>();

            int[] parentsInfo = new int[numberOfVertices];
            FillInInitialValues(parentsInfo);

            Queue<Edge> remaining = new Queue<Edge>(edges.OrderBy(e => e.Weight));

            while (remaining.Count > 0)
            {
                Edge current = remaining.Dequeue();

                int startNodeRoot = FindRoot(current.StartNode, parentsInfo);
                int endNodeRoot = FindRoot(current.EndNode, parentsInfo);

                if (startNodeRoot == endNodeRoot)
                {
                    continue;
                }

                forest.Add(current);
                parentsInfo[endNodeRoot] = startNodeRoot;
            }

            return forest;
        }

        public static int FindRoot(int node, int[] parent)
        {
            int parentNode = parent[node];

            if (parentNode == -1)
            {
                return node;
            }

            return FindRoot(parentNode, parent);
        }

        private static void FillInInitialValues(int[] parentsInfo)
        {
            for (int i = 0; i < parentsInfo.Length; i++)
            {
                parentsInfo[i] = -1;
            }
        }
    }
