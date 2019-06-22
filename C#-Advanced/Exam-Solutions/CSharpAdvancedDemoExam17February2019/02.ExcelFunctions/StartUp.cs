namespace _02.ExcelFunctions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            List<List<string>> table = new List<List<string>>();

            for (int i = 0; i < rows; i++)
            {
                table.Add(
                    Console.ReadLine()
                    .Split(", ")
                    .ToList());
            }

            string[] commandLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = commandLine[0];
            string header = commandLine[1];

            int index = table[0].IndexOf(header);

            switch (command)
            {
                case "hide":
                    table.ForEach(l => l.RemoveAt(index));
                    break;

                case "sort":
                    List<string> headerRow = table.FirstOrDefault();
                    table = table
                        .Skip(1)
                        .ToList();
                    table = table
                        .OrderBy(l => l.ElementAt(index))
                        .ToList();
                    table.Insert(0, headerRow);
                    break;

                case "filter":
                    string value = commandLine[2];
                    headerRow = table.FirstOrDefault();
                    table = table
                        .Where(l => l.ElementAt(index) == value)
                        .ToList();
                    table.Insert(0, headerRow);
                    break;
            }

            if (table.Count != 0 && table[0].Count != 0)
            {
                foreach (var row in table)
                {
                    Console.WriteLine(string.Join(" | ", row));
                }
            }
        }
    }
}
