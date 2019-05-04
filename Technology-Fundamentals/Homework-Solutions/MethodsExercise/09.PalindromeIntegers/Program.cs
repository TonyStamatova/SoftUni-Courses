using System;

namespace _09.palindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                Console.WriteLine(IsPalindrome(input).ToString().ToLower());
            }
        }

        private static bool IsPalindrome(string inputString)
        {
            for (int i = 0; i < inputString.Length / 2; i++)
            {
                if (!Char.IsDigit(inputString[i]))
                {
                    return false;
                }

                if (inputString[i] != inputString[inputString.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
