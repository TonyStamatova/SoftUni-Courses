using System;
using System.Collections.Generic;
using System.Text;

namespace _04.replaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            StringBuilder builder = new StringBuilder();
            builder.Append(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != input[i-1])
                {
                    builder.Append(input[i]);
                }
            }

            Console.WriteLine(builder);
        }
    }
}
