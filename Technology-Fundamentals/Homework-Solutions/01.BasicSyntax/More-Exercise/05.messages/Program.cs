using System;

namespace _05.messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            string result = string.Empty;
            int key = default(int);
            int letterIndex = default(int);
            char letter = default(char);

            for (int i = 0; i < numberOfInputs; i++)
            {
                string digits = Console.ReadLine();
                key = int.Parse(digits) % 10;

                if (key == 0)
                {
                    result += " ";
                    continue;
                }

                letterIndex = (key - 2) * 3 + digits.Length - 1;

                if (key == 8 || key == 9)
                {
                    letterIndex += 1;
                }

                letterIndex += 97;
                letter = (char)letterIndex;
                result += letter;
            }

            Console.WriteLine(result);
        }
    }
}
