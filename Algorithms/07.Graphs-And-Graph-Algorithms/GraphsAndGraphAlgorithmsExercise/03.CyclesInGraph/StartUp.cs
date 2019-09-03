namespace _03.CyclesInGraph
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static HashSet<string> visited;
        private static Dictionary<string, HashSet<string>> graph;

        public static void Main()
        {
            string input = Console.ReadLine();

            graph = new Dictionary<string, HashSet<string>>();
            visited = new HashSet<string>();

            while (input != null)
            {
                string[] edgeInfo = input.Split('–');

                string start = edgeInfo[0];
                string end = edgeInfo[1];

                if (visited.Contains(end))
                {
                    Console.WriteLine("Acyclic: No");
                    return;
                }

                if (!graph.ContainsKey(start))
                {
                    graph.Add(start, new HashSet<string>());
                    visited.Add(start);
                }                

                graph[start].Add(end);

                input = Console.ReadLine();
            }

            Console.WriteLine("Acyclic: Yes");
        }
    }
}
