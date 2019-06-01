using System;

namespace _02.englishNameOfTheLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int digit = number % 10;
            Console.WriteLine(DigitEnglishName(digit));
        }

        private static string DigitEnglishName(int digit)
        {
            if (digit == 0)
            {
                return "zero";
            }
            else if (digit == 1)
            {
                return "one";
            }
            else if (digit == 2)
            {
                return "two";
            }
            else if (digit == 3)
            {
                return "three";
            }
            else if (digit == 4)
            {
                return "four";
            }
            else if (digit == 5)
            {
                return "five";
            }
            else if (digit == 6)
            {
                return "six";
            }
            else if (digit == 7)
            {
                return "seven";
            }
            else if (digit == 8)
            {
                return "eight";
            }
            else
            {
                return "nine";
            }
        }
    }
}
