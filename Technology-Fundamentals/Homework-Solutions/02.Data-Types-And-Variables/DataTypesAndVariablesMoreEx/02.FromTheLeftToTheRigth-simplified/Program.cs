using System;
using System.Linq;

namespace _02.FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                long[] input = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                long maxNum = Math.Abs(input.Max());
                int sum = default(int);

                while (maxNum != 0)
                {
                    int digit = (int)(maxNum % 10);
                    sum += digit;
                    maxNum /= 10;
                }

                Console.WriteLine(sum);
            }
        }
    }
}
