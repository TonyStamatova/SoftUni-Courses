using System;

namespace _10.topNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                if (CheckForOddDigit(i) && CheckSumOfDigits(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool CheckSumOfDigits(int number)
        {
            int digit = default(int);
            int sum = default(int);

            while (number > 0)
            {
                digit = number % 10;
                sum += digit;
                number /= 10;
            }

            if (sum % 8 == 0)
            {
                return true;
            }

            return false;
        }

        private static bool CheckForOddDigit(int number)
        {
            int digit = default(int);

            while (number > 0)
            {
                digit = number % 10;

                if (digit % 2 != 0)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}
