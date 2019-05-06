using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.legendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = default(int);
            Dictionary<string, int> quantitiesByMaterial = new Dictionary<string, int>();
            Dictionary<string, string> legendaryItemsByKeyMaterials = new Dictionary<string, string>
            {
                { "shards", "Shadowmourne" },
                { "fragments", "Valanyr" },
                { "motes", "Dragonwrath" }
            };
            bool reachedGoal = false;


            while (true)
            {
                string[] input = Console.ReadLine().Split();

                for (int i = 0; i < input.Length; i += 2)
                {

                    quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (!quantitiesByMaterial.ContainsKey(material))
                    {
                        quantitiesByMaterial.Add(material, quantity);
                    }
                    else
                    {
                        quantitiesByMaterial[material] += quantity;
                    }

                    if (quantitiesByMaterial[material] >= 250 && legendaryItemsByKeyMaterials.ContainsKey(material))
                    {
                        Console.WriteLine($"{legendaryItemsByKeyMaterials[material]} obtained!");
                        quantitiesByMaterial[material] -= 250;
                        reachedGoal = true;
                        break;
                    }
                }

                if (reachedGoal)
                {
                    break;
                }
            }

            Dictionary<string, int> keyMaterials = quantitiesByMaterial
                 .Where(x => legendaryItemsByKeyMaterials.ContainsKey(x.Key))
                 .ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in legendaryItemsByKeyMaterials)
            {
                if (!keyMaterials.ContainsKey(item.Key))
                {
                    keyMaterials.Add(item.Key, 0);
                }
            }

            keyMaterials = keyMaterials
                 .OrderByDescending(x => x.Value)
                 .ThenBy(x => x.Key)
                 .ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in keyMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Dictionary<string, int> junk = quantitiesByMaterial
                 .Where(x => !legendaryItemsByKeyMaterials.ContainsKey(x.Key))
                 .OrderBy(x => x.Key)
                 .ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in junk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
