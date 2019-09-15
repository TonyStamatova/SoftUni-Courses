namespace _03.Lumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static bool[] visited;
        private static List<int>[] graph;
        private static int currentComponent;
        private static int[] components;

        public static void Main()
        {
            int[] queriesInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int logsCount = queriesInfo[0];
            int queries = queriesInfo[1];

            BuildGraph(logsCount);
            FindConnectedComponents(logsCount);
            ExecuteQueries(queries);
        }

        private static void FindConnectedComponents(int logsCount)
        {
            visited = new bool[logsCount + 1];
            components = new int[logsCount + 1];

            for (int i = 1; i <= logsCount; i++)
            {
                if (!visited[i])
                {
                    Dfs(i);
                    currentComponent++;
                }
            }
        }

        private static void BuildGraph(int logsCount)
        {
            Log[] logs = new Log[logsCount + 1];
            graph = new List<int>[logsCount + 1];

            for (int i = 1; i <= logsCount; i++)
            {
                logs[i] = new Log(
                    Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToArray());
                graph[i] = new List<int>();

                for (int j = 1; j < i; j++)
                {
                    if (logs[i].IntersectsWith(logs[j]))
                    {
                        graph[j].Add(i);
                        graph[i].Add(j);
                    }
                }
            }
        }

        private static void ExecuteQueries(int queries)
        {
            for (int i = 0; i < queries; i++)
            {
                int[] newQuery = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int first = newQuery[0];
                int second = newQuery[1];

                if (components[first] == components[second])
                {
                    Console.WriteLine("YES");
                    continue;
                }

                Console.WriteLine("NO");
            }
        }

        private static void Dfs(int log)
        {
            components[log] = currentComponent;

            if (visited[log])
            {
                return;
            }

            visited[log] = true;

            foreach (var child in graph[log])
            {
                Dfs(child);
            }
        }
    }

    public class Log
    {
        public Log(params int[] coordinates)
        {
            this.Ax = coordinates[0];
            this.Ay = coordinates[1];
            this.Bx = coordinates[2];
            this.By = coordinates[3];
        }

        public int Ax { get; private set; }
        public int Ay { get; private set; }
        public int Bx { get; private set; }
        public int By { get; private set; }

        public bool IntersectsWith(Log other)
        {
            return this.Ax <= other.Bx && this.Bx >= other.Ax
                    && this.Ay >= other.By && this.By <= other.Ay;
        }
    }
}
