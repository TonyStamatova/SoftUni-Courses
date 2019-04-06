using System;

namespace _06.triplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int firstLetterNum = (int)'a';
            int lastLetterNum = firstLetterNum + num - 1;

            for (int i = firstLetterNum; i <= lastLetterNum; i++)
            {
                for (int j = firstLetterNum; j <= lastLetterNum; j++)
                {
                    for (int k = firstLetterNum; k <= lastLetterNum; k++)
                    {
                        Console.WriteLine($"{(char)i}{(char)j}{(char)k}");
                    }
                }
            }
        }
    }
}
