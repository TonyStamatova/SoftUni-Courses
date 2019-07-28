namespace P02RecursiveFactorial
{
    using System;
    using System.Numerics;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFactorial(number));
        }

        public static BigInteger GetFactorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * GetFactorial(number - 1);
        }
    }
}
