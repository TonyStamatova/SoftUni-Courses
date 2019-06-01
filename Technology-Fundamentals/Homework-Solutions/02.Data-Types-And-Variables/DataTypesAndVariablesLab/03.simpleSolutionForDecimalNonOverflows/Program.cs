using System;
using System.Numerics;

namespace _03.exactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numsCount = int.Parse(Console.ReadLine());

            decimal sum = default(decimal);

            for (int i = 0; i < numsCount; i++)
            {
                decimal input = decimal.Parse(Console.ReadLine());
                sum += input;
            }

            Console.WriteLine(sum);
        }
    }
}
