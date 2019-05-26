using System;

namespace _07.vendingMachine
{
    class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            decimal insertedCoin = default(decimal);
            decimal totMoneyInserted = default(decimal);

            while (input != "Start")
            {
                insertedCoin = decimal.Parse(input);

                switch (insertedCoin)
                {
                    case 0.1m:
                    case 0.2m:
                    case 0.5m:
                    case 1m:
                    case 2m:
                        totMoneyInserted += insertedCoin;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {insertedCoin}");
                        break;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            decimal singleItemCost = default(decimal);
            bool validProduct = true;

            while (input != "End")
            {
                //“Nuts”, “Water”, “Crisps”, “Soda”, “Coke”. 
                //The prices are: 2.0, 0.7, 1.5, 0.8, 1.0
                switch (input)
                {
                    case "Nuts":
                        singleItemCost = 2;
                        break;
                    case "Water":
                        singleItemCost = 0.7m;
                        break;
                    case "Crisps":
                        singleItemCost = 1.5m;
                        break;
                    case "Soda":
                        singleItemCost = 0.8m;
                        break;
                    case "Coke":
                        singleItemCost = 1;
                        break;
                    default:
                        validProduct = false;
                        Console.WriteLine("Invalid product");
                        break;
                }

                if (validProduct)
                {
                    if (totMoneyInserted >= singleItemCost)
                    {
                        totMoneyInserted -= singleItemCost;
                        Console.WriteLine($"Purchased {input.ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Change: {totMoneyInserted:f2}");
        }
    }
}
