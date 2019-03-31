using System;
using System.Numerics;

namespace _03.exactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numsCount = int.Parse(Console.ReadLine());

            BigInteger integerSum = default(BigInteger);
            BigInteger integerPart = default(BigInteger);
            decimal floatingSum = default(decimal);
            decimal floatingPart = default(decimal);

            for (int i = 0; i < numsCount; i++)
            {
                string input = Console.ReadLine();

                if (input.Contains("."))
                {
                    int floatingPointIndex = input.IndexOf('.');
                    integerPart = BigInteger.Parse(input.Substring(0, floatingPointIndex));
                    integerSum += integerPart;
                    string afterFloatingPoint = "0." + input.Substring(floatingPointIndex + 1);
                    floatingPart = decimal.Parse(afterFloatingPoint);
                    floatingSum += floatingPart;
                }
                else
                {
                    integerSum += BigInteger.Parse(input);
                }
            }

            if (floatingSum != 0)
            {
                Console.WriteLine($"{integerSum}.{floatingSum.ToString().Substring(2)}");
            }
            else
            {
                Console.WriteLine(integerSum);
            }
        }
    }
}
