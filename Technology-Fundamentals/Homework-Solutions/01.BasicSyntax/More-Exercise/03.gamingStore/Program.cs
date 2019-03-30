using System;

namespace _03.gamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal balance = decimal.Parse(Console.ReadLine());

            string input = string.Empty;
            decimal price = default(decimal);
            decimal totMoneySpent = default(decimal);

            while ((input = Console.ReadLine()) != "Game Time")
            {
                switch (input)
                {
                    case "OutFall 4":
                        price = 39.99m;
                        break;
                    case "CS: OG":
                        price = 15.99m;
                        break;
                    case "Zplinter Zell":
                        price = 19.99m;
                        break;
                    case "Honored 2":
                        price = 59.99m;
                        break;
                    case "RoverWatch":
                        price = 29.99m;
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99m;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }

                if (price > balance)
                {
                    Console.WriteLine("Too Expensive");
                    continue;
                }

                balance -= price;
                Console.WriteLine($"Bought {input}");
                totMoneySpent += price;

                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
            }

            Console.WriteLine($"Total spent: ${totMoneySpent}. Remaining: ${balance}");
        }
    }
}
