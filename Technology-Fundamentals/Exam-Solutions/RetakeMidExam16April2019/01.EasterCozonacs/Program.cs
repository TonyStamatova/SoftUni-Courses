using System;

namespace _01.EasterCozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            decimal flourPrice = decimal.Parse(Console.ReadLine());

            decimal eggPrice = 0.75m * flourPrice;
            decimal milkPrice = 0.25m * (1.25m * flourPrice);

            decimal cozonacPrice = flourPrice + eggPrice + milkPrice;

            int cozonacs = (int)Math.Truncate(budget / cozonacPrice);

            int eggs = default(int);

            for (int i = 1; i <= cozonacs; i++)
            {
                eggs += 3;

                if (i % 3 == 0)
                {
                    eggs -= (i - 2);
                }
            }

            decimal moneyLeft = budget - cozonacs * cozonacPrice;
            Console.WriteLine($"You made {cozonacs} cozonacs! Now you have {eggs} eggs and {moneyLeft:f2}BGN left.");
        }
    }
}
