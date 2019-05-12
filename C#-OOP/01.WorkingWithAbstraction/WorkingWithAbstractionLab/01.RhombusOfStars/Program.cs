using System;

namespace _01.RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            PrintUpperPart(size);
            PrintLowerPart(size - 1);
        }
        
        private static void PrintUpperPart(int rows)
        {
            for (int i = 1; i <= rows; i++)
            {
                PrintWhitespace(rows - i);
                PrintStars(i);
                Console.WriteLine();
            }
        }

        private static void PrintLowerPart(int rows)
        {
            for (int i = rows; i >= 1; i--)
            {
                PrintWhitespace(rows - i + 1);
                PrintStars(i);
                Console.WriteLine();
            }
        }

        private static void PrintStars(int rowNumber)
        {
            char[] stars = new char[rowNumber];

            for (int j = 0; j < stars.Length; j++)
            {
                stars[j] = '*';
            }

            string line = string.Join(' ', stars);
            Console.Write(line);
        }

        private static void PrintWhitespace(int count)
        {
            string whitespace = new string(' ', count);
            Console.Write(whitespace);
        }
    }
}
