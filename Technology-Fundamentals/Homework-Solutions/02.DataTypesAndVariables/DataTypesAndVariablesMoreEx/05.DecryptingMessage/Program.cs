using System;

namespace _05.DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberOfChars = int.Parse(Console.ReadLine());

            string result = string.Empty;

            for (int i = 0; i < numberOfChars; i++)
            {
                char current = char.Parse(Console.ReadLine());

                for (int j = 0; j < key; j++)
                {

                    current++;

                }

                result += current;
            }

            Console.WriteLine(result);
        }
    }
}
