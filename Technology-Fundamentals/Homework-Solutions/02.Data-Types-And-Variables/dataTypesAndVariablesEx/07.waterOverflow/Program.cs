using System;

namespace _07.waterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            int capacity = 255;
            int litersPouredOnThisRound = default(int);
            int allLitersPoured = default(int);

            for (int i = 0; i < numberOfLines; i++)
            {
                litersPouredOnThisRound = int.Parse(Console.ReadLine());

                if (litersPouredOnThisRound > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    capacity -= litersPouredOnThisRound;
                    allLitersPoured += litersPouredOnThisRound;
                }
            }

            Console.WriteLine(allLitersPoured);
        }
    }
}
