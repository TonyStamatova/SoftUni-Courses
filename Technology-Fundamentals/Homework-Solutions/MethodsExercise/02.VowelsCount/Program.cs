using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            int result = GetVowelsCount(input);
            Console.WriteLine(result);
        }

        private static int GetVowelsCount(string input)
        {
            int result = default(int);

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'y':
                        result++;
                        break;
                }
            }

            return result;
        }
    }
}
