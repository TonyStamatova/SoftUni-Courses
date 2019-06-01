namespace _06.Wardrobe
{
    using System;
    using System.Collections.Generic;

    public class Wardrobe
    {
        public static void Main()
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            var numberOfLines = int.Parse(Console.ReadLine());

            OrganiseWardrobe(wardrobe, numberOfLines);

            var searchParameters = Console.ReadLine().Split();
            var desiredColor = searchParameters[0];
            var desiredClothing = searchParameters[1];

            GoThroughWardrobe(wardrobe, desiredColor, desiredClothing);
        }

        private static void GoThroughWardrobe(
            Dictionary<string, Dictionary<string, int>> wardrobe, 
            string desiredColor, 
            string desiredClothing)
        {
            foreach (var colorSection in wardrobe)
            {
                Console.WriteLine($"{colorSection.Key} clothes:");

                foreach (var clothing in colorSection.Value)
                {
                    Console.Write($"* {clothing.Key} - {clothing.Value}");

                    if (colorSection.Key == desiredColor && clothing.Key == desiredClothing)
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                }
            }
        }

        private static void OrganiseWardrobe(
            Dictionary<string, Dictionary<string, int>> wardrobe, 
            int numberOfLines)
        {
            for (int i = 0; i < numberOfLines; i++)
            {
                var inputLine = Console.ReadLine().Split(" -> ");
                var color = inputLine[0];
                var clothes = inputLine[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                AddClothes(wardrobe, color, clothes);
            }
        }

        private static void AddClothes(
            Dictionary<string, Dictionary<string, int>> wardrobe, 
            string color, 
            string[] clothes)
        {
            foreach (var piece in clothes)
            {
                if (!wardrobe[color].ContainsKey(piece))
                {
                    wardrobe[color].Add(piece, 1);
                }
                else
                {
                    wardrobe[color][piece]++;
                }
            }
        }
    }
}
