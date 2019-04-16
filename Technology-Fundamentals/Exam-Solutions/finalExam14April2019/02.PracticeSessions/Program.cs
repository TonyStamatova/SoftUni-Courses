using System;
using System.Collections.Generic;
using System.Linq;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> roads = new Dictionary<string, List<string>>();

            while (input != "END")
            {
                string[] data = input.Split("->");
                string command = data[0];
                string currentRoad = data[1];
                string racer = data[2];

                switch (command)
                {
                    case "Add":
                        if (!roads.ContainsKey(currentRoad))
                        {
                            roads.Add(currentRoad, new List<string>());
                        }
                        roads[currentRoad].Add(racer);
                        break;
                    case "Move":
                        if (roads.ContainsKey(currentRoad) && roads[currentRoad].Contains(racer))
                        {
                            roads[currentRoad].Remove(racer);
                            string newRoad = data[3];
                            roads[newRoad].Add(racer);
                        }
                        break;
                    case "Close":
                        if (roads.ContainsKey(currentRoad))
                        {
                            roads.Remove(currentRoad);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Practice sessions:");
            foreach (var road in roads.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine(road.Key);

                foreach (var racer in road.Value)
                {
                    Console.WriteLine($"++{racer}");
                }
            }
        }
    }
}
