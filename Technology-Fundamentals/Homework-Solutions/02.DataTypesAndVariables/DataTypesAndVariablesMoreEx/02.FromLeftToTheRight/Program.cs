using System;

namespace _02.FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string input = Console.ReadLine();

                int counter = 0;
                string firstNumAsString = string.Empty;

                while (input[counter] != ' ')
                {
                    firstNumAsString += input[counter];
                    counter++;
                }

                counter++;

                string secondNumAsString = string.Empty;

                while (counter < input.Length)
                {
                    secondNumAsString += input[counter];
                    counter++;
                }

                long firstNum = long.Parse(firstNumAsString);
                long secondNum = long.Parse(secondNumAsString);
                long maxNum = Math.Abs(Math.Max(firstNum, secondNum));                
                int sum = default(int);

                while (maxNum != 0)
                {
                    int digit = (int)(maxNum % 10);
                    sum += digit;
                    maxNum /= 10;
                }

                Console.WriteLine(sum);
            }
        }
    }
}
