using System;

namespace _09.multiplyEvensByOdds
{
    class Program
    {
        public static void Main()
        {
            string inputNum = Math.Abs(int.Parse(Console.ReadLine())).ToString();

            Console.WriteLine(GetMultipleOfEvenAndOdds(inputNum));
        }

        private static int GetSumOfEvenDigits(string input)
        {
            int evenSum = default(int);
            for (int i = 0; i < input.Length; i++)
            {
                char digit = input[i];
                string digitStr = digit.ToString();
                int num = int.Parse(digitStr);

                if (num % 2 == 0)
                {
                    evenSum += num;
                }

            }
            return evenSum;
        }

        private static int GetSumOfOddDigits(string input)
        {
            int oddSum = default(int);
            for (int i = 0; i < input.Length; i++)
            {
                char digit = input[i];
                string digitStr = digit.ToString();
                int num = int.Parse(digitStr);

                if (num % 2 != 0)
                {
                    oddSum += num;
                }

            }
            return oddSum;
        }

        private static int GetMultipleOfEvenAndOdds(string inputNumber)
        {
            int even = GetSumOfEvenDigits(inputNumber);

            int odd = GetSumOfOddDigits(inputNumber);

            return even * odd;
        }
    }
}
