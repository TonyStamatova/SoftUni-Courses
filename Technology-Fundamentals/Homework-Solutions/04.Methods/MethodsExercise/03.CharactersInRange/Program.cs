using System;
using System.Text;

namespace _03.charsInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            string result = string.Empty;

            if ((int)firstChar > (int)secondChar)
            {
                result = GetCharsInBetween(secondChar, firstChar);
            }
            else
            {
                result = GetCharsInBetween(firstChar, secondChar);
            }

            Console.WriteLine(result);
        }

        private static string GetCharsInBetween(char firstChar, char secondChar)
        {
            StringBuilder builder = new StringBuilder();

            for (char i = firstChar; i < secondChar; i++)
            {
                if (i == firstChar)
                {
                    continue;
                }

                builder.Append(i + " ");
            }

            string result = builder.ToString();
            return result;
        }
    }
}
