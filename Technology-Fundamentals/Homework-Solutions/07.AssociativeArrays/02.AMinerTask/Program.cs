using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.aMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int newQuantity = default(int);
            Dictionary<string, int> byResource = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }

                newQuantity = int.Parse(Console.ReadLine());

                if (!byResource.ContainsKey(input))
                {
                    byResource.Add(input, newQuantity);
                    continue;
                }

                byResource[input] += newQuantity;
            }

            foreach (var item in byResource)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
