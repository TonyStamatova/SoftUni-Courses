using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.countCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] chars = Console.ReadLine()
                .Select(x => x)
                .Where(x => x != ' ')
                .ToArray();

            Dictionary<char, int> byOccurrences = new Dictionary<char, int>();

            foreach (var item in chars)
            {
                if (byOccurrences.ContainsKey(item))
                {
                    byOccurrences[item]++;
                }
                else
                {
                    byOccurrences.Add(item, 1);
                }
            }

            foreach (var item in byOccurrences)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
