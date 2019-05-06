using System;

namespace orders
{
    class Program
    {
        public static void Main()
        {
            CalculateTotal(Console.ReadLine(), int.Parse(Console.ReadLine()));
        }

        private static void CalculateTotal(string product, int quantity)
        {
            double total = default(double);

            switch (product)
            {
                case "coffee":
                    total = 1.5 * quantity;
                    break;
                case "water":
                    total = 1 * quantity;
                    break;
                case "coke":
                    total = 1.40 * quantity;
                    break;
                default:
                    total = 2 * quantity;
                    break;
            }

            Console.WriteLine($"{total:f2}");
        }
    }
}
