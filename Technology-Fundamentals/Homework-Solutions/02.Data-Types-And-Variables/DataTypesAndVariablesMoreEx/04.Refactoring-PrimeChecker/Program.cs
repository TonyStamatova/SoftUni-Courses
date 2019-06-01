using System;

namespace _04.Refactoring_PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastNumToCheck = int.Parse(Console.ReadLine());
            for (int currentNumber = 2; currentNumber <= lastNumToCheck; currentNumber++)
            {
                bool isPrime = true;
                for (int divisor = 2; divisor < currentNumber; divisor++)
                {
                    if (currentNumber % divisor == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine("{0} -> {1}", currentNumber, isPrime.ToString().ToLower());
            }
        }
    }
}
