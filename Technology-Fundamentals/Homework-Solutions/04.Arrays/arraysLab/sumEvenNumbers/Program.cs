using System;
using System.Linq;

namespace sumEvenNumbers
{
    class Program
    {
        static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sum = default(int);

            foreach (var number in nums)
            {
                if (number % 2 == 0)
                {
                    sum += number;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
