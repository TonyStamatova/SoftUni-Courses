using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.EasterShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shops = Console.ReadLine().Split().ToList();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                switch (command)
                {
                    case "Include":
                        shops.Add(input[1]);
                        break;

                    case "Visit":
                        int number = int.Parse(input[2]);
                        if (number > shops.Count)
                        {
                            continue;
                        }
                        switch (input[1])
                        {
                            case "first":
                                shops.RemoveRange(0, number);
                                break;
                            case "last":
                                shops = shops.SkipLast(number).ToList();
                                break;
                        }
                        break;

                    case "Prefer":
                        int firstIndex = int.Parse(input[1]);
                        int secondIndex = int.Parse(input[2]);
                        if (IndexExists(firstIndex, shops.Count) && IndexExists(secondIndex, shops.Count))
                        {
                            string temp = shops[firstIndex];
                            shops[firstIndex] = shops[secondIndex];
                            shops[secondIndex] = temp;
                        }
                        break;

                    case "Place":
                        string newShop = input[1];
                        int index = int.Parse(input[2]) + 1;
                        if (!IndexExists(index, shops.Count + 1))
                        {
                            continue;
                        }
                        shops.Insert(index, newShop);
                        break;
                }
            }

            Console.WriteLine("Shops left:"
                + Environment.NewLine + string.Join(" ", shops));
        }

        private static bool IndexExists(int index, int lastIndex)
        {
            if (index >= 0 && index < lastIndex)
            {
                return true;
            }

            return false;
        }
    }
}
