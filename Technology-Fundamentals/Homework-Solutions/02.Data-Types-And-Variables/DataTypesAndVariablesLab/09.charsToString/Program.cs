using System;

namespace _09.charsToString
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                result += Console.ReadLine();
            }

            Console.WriteLine(result);
        }
    }
}
