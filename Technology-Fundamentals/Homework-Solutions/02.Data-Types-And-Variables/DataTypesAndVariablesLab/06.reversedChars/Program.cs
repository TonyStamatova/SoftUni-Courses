using System;

namespace _06.reversedChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialString = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                char current = char.Parse(Console.ReadLine());
                initialString += current;
            }

            string result = string.Empty;

            for (int i = initialString.Length - 1; i >= 0; i--)
            {
                result += initialString[i] + " ";
            }

            Console.WriteLine(result);
        }
    }
}
