namespace _02.StackSum
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StackSum
    {
        public static void Main()
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            string line = Console.ReadLine();

            while (line.ToLower() != "end")
            {
                string[] commandLine = line.Split();
                string command = commandLine[0].ToLower();

                switch (command)
                {
                    case "add":
                        for (int i = 1; i <= 2; i++)
                        {
                            numbers.Push(int.Parse(commandLine[i]));
                        }
                        break;

                    case "remove":
                        int elementsToRemove = int.Parse(commandLine[1]);

                        if (elementsToRemove <= numbers.Count)
                        {
                            for (int i = 0; i < elementsToRemove; i++)
                            {
                                numbers.Pop();
                            }
                        }

                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
