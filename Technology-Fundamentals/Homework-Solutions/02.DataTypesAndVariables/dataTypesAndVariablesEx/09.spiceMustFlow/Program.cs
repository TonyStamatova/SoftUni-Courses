using System;

namespace _09.spiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());

            int totalAmountExtracted = default(int);
            int daysCount = default(int);

            while (yield >= 100)
            {
                totalAmountExtracted += yield;

                if (totalAmountExtracted < 26)
                {
                    totalAmountExtracted = 0;
                }
                else
                {
                    totalAmountExtracted -= 26;
                }

                daysCount++;

                yield -= 10;
            }

            totalAmountExtracted -= 26;

            Console.WriteLine(daysCount);

            if (totalAmountExtracted > 0)
            {
                Console.WriteLine(totalAmountExtracted);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
