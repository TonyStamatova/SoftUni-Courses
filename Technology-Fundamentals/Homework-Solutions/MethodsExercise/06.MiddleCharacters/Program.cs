using System;

namespace _06.middleCharacter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintMiddleChars(input);
        }

        private static void PrintMiddleChars(string input)
        {
            int middle = input.Length / 2;
            if (input.Length % 2 == 0)
            {
                Console.WriteLine($"{input[middle - 1]}{input[middle]}");
            }
            else
            {
                Console.WriteLine(input[middle]);
            }
        }
    }
}
