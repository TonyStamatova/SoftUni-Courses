using System;

namespace _12.refactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int finalNumber = int.Parse(Console.ReadLine());            

            for (int i = 1; i <= finalNumber; i++)
            {
                int current = i;
                int sum = 0;

                while (current > 0)
                {
                    sum += current % 10;
                    current /= 10;
                }

                bool isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", i, isSpecial);
            }
        }
    }
}
