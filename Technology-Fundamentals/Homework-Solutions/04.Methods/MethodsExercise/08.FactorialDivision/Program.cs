using System;
using System.Numerics;

namespace _08.factorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            BigInteger firstFactorial = GetFactorial(firstNum);
            BigInteger secondFactorial = GetFactorial(secondNum);
            decimal divisionResult = (decimal)firstFactorial / (decimal)secondFactorial;
            Console.WriteLine($"{divisionResult:f2}");
        }

        private static BigInteger GetFactorial(int number)
        {
            BigInteger result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
