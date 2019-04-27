using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.EasterGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] gifts = Console.ReadLine().Split();
            string input = Console.ReadLine();

            while (input != "No Money")
            {
                string[] inputData = input.Split();
                string command = inputData[0];
                string gift = inputData[1];

                input = Console.ReadLine();

                switch (command)
                {
                    case "OutOfStock":
                        for (int i = 0; i < gifts.Length; i++)
                        {
                            if (gifts[i] == gift)
                            {
                                gifts[i] = "None";
                            }
                        }
                        break;

                    case "Required":
                        int index = int.Parse(inputData[2]);
                        if (index < 0 || index >= gifts.Length )
                        {
                            continue;
                        }
                        gifts[index] = gift;
                        break;

                    case "JustInCase":
                        gifts[gifts.Length - 1] = gift;
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", gifts.Where(x => x != "None")));
        }
    }
}
