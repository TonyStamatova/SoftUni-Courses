namespace _01.SpaceshipCrafting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, int> materials = new Dictionary<string, int> {
                { "Glass", 25 },
                { "Aluminium", 50 },
                { "Lithium", 75 },
                { "Carbon fiber", 100 }
            };

            Queue<int> liquids = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            Stack<int> items = new Stack<int>(
                 Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> createdItems = new Dictionary<string, int> {
                { "Glass", 0 },
                { "Aluminium", 0 },
                { "Lithium", 0 },
                { "Carbon fiber", 0 }
            };

            while (liquids.Count > 0 && items.Count > 0)
            {
                int currentLiquid = liquids.Dequeue();
                int currentItem = items.Pop();

                int sum = currentItem + currentLiquid;

                if (materials.Any(m => m.Value == sum) && sum != 0)
                {
                    string itemName = materials
                        .Where(m => m.Value == sum)
                        .First()
                        .Key;
                    createdItems[itemName]++;
                }
                else
                {
                    currentItem += 3;
                    items.Push(currentItem);
                }
            }

            if (!createdItems.Any(i => i.Value == 0))
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (items.Count == 0)
            {
                Console.WriteLine("Physical items left: none");
            }
            else
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", items)}");
            }

            foreach (var item in createdItems.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
