namespace _04.Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static List<int>[] graph;
        private static long[] salaries;

        public static void Main()
        {
            int employees = int.Parse(Console.ReadLine());

            graph = new List<int>[employees];
            salaries = new long[employees];

            BuildGraph();

            List<int> topManagers = FindTopManagers();

            foreach (var manager in topManagers)
            {
                salaries[manager] = CalculateSalaries(manager);
            }

            Console.WriteLine(salaries.Sum());
        }

        private static List<int> FindTopManagers()
        {
            List<int> result = new List<int>();

            for (int manager = 0; manager < graph.Length; manager++)
            {
                if (!graph.Any(m => m.Contains(manager)))
                {
                    result.Add(manager);
                }
            }

            return result;
        }

        private static long CalculateSalaries(int managerIndex)
        {
            if (salaries[managerIndex] != 0)
            {
                return salaries[managerIndex];
            }

            if (graph[managerIndex].Count == 0)
            {
                salaries[managerIndex] = 1;
                return 1;
            }

            foreach (var employee in graph[managerIndex])
            {
                salaries[managerIndex] += CalculateSalaries(employee);
            }

            return salaries[managerIndex];
        }

        private static void BuildGraph()
        {
            for (int i = 0; i < graph.Length; i++)
            {
                string managerInfo = Console.ReadLine();

                graph[i] = new List<int>();

                for (int j = 0; j < managerInfo.Length; j++)
                {
                    if (managerInfo[j] == 'Y')
                    {
                        graph[i].Add(j);
                    }
                }
            }
        }
    }
}
