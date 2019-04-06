using System;

namespace _04.sumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            char letter = '\0';
            int sum = default(int);

            for (int i = 0; i < numberOfLines; i++)
            {
                letter = char.Parse(Console.ReadLine());
                sum += letter;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
