using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evenOddSubstraction
{
    class Program
    {
        static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int evenSum = default(int);
            int oddSum = default(int);

            foreach (var item in nums)
            {
                if (item % 2 == 0)
                {
                    evenSum += item;
                }
                else
                {
                    oddSum += item;
                }
            }

            int diff = evenSum - oddSum;

            Console.WriteLine(diff);
        }
    }
}
