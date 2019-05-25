namespace _02.SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetsOfElements
    {
        public static void Main()
        {
            var elementsCountInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var firstSetCount = elementsCountInfo[0];
            var secondSetCount = elementsCountInfo[1];

            var firstSet = new HashSet<string>();
            var secondSet = new HashSet<string>();

            AddItemsToSet(firstSetCount, firstSet);
            AddItemsToSet(secondSetCount, secondSet);

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }

        private static void AddItemsToSet(int count, HashSet<string> set)
        {
            for (int i = 0; i < count; i++)
            {
                set.Add(Console.ReadLine());
            }
        }
    }
}
