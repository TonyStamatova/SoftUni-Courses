using System;

namespace signOfIntNumbers
{
    class Program
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            PrintNumSign(num);
        }

        private static void PrintNumSign(int number)
        {
            string result = string.Empty;

            if (number < 0)
            {
                result = $"The number {number} is negative.";
            }
            else if (number == 0)
            {
                result = $"The number {number} is zero.";
            }
            else
            {
                result = $"The number {number} is positive.";
            }

            Console.WriteLine(result);
        }
    }
}
