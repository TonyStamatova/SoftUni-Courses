using System;

namespace _01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int intType;
            float floatType;
            char charType;
            bool boolType;

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (int.TryParse(input, out intType))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (float.TryParse(input, out floatType))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (char.TryParse(input, out charType))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (bool.TryParse(input, out boolType))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }

                input = Console.ReadLine();
            }
        }
    }
}
