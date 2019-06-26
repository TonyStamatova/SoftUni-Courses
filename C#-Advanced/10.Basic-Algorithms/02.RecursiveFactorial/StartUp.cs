namespace _02.RecursiveFactorial
{
    using System;
    using System.Numerics;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(number));
        }

        private static BigInteger Factorial(BigInteger number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * Factorial(--number);
        }
    }
}
