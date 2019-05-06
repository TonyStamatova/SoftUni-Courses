using System;

namespace repeatString
{
    class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int countOfRepetitions = int.Parse(Console.ReadLine());

            Console.WriteLine(PrintString(input, countOfRepetitions));
        }

        private static string PrintString(string inputStr, int repetitions)
        {
            string result = string.Empty;
            for (int i = 0; i < repetitions; i++)
            {
                result += inputStr;
            }

            return result;
        }
    }
}
