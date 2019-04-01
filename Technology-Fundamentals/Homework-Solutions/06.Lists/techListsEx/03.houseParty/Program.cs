using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.houseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (command.Length == 3)
                {
                    if (guests.Contains(command[0]))
                    {
                        Console.WriteLine($"{command[0]} is already in the list!");
                        continue;
                    }

                    guests.Add(command[0]);
                    continue;
                }

                if (guests.Contains(command[0]))
                {
                    guests.Remove(command[0]);
                    continue;
                }

                Console.WriteLine($"{command[0]} is not in the list!");
            }

            foreach (var item in guests)
            {
                Console.WriteLine(item);
            }
        }
    }
}
