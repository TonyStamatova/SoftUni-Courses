using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.FeedTheAnimals
{
    class Program
    {
        static void Main(string[] args)
        {
            var areas = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "Last Info")
            {
                string[] data = input.Split(":");
                string command = data[0];
                string animalName = data[1];
                int foodKg = int.Parse(data[2]);
                string area = data[3];

                switch (command)
                {
                    case "Add":
                        AddNewAnimal(areas, animalName, foodKg, area);
                        break;

                    case "Feed":
                        if (areas.ContainsKey(area) && areas[area].ContainsKey(animalName))
                        {
                            areas[area][animalName] -= foodKg;

                            if (areas[area][animalName] <= 0)
                            {
                                areas[area].Remove(animalName);
                                Console.WriteLine($"{animalName} was successfully fed");
                            }
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Dictionary<string, int> animalsByName = new Dictionary<string, int>(areas.Values
               .SelectMany(x => x))
               .ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine("Animals:");

            foreach (var animal in animalsByName.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{animal.Key} -> {animal.Value}g");
            }

            Console.WriteLine("Areas with hungry animals:");

            foreach (var area in areas.Where(x => x.Value.Count != 0)
                .OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{area.Key} : {area.Value.Count}");
            }
        }

        private static void AddNewAnimal(Dictionary<string,
            Dictionary<string, int>> areas, string name, int foodLimit, string area)
        {
            if (!areas.ContainsKey(area))
            {
                areas.Add(area, new Dictionary<string, int>());
            }

            if (!areas[area].ContainsKey(name))
            {
                areas[area].Add(name, foodLimit);
            }
            else
            {
                areas[area][name] += foodLimit;
            }
        }
    }
}
