using System;
using System.Text;

namespace _04.caesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                builder.Append((char)(input[i] + 3));
            }

            Console.WriteLine(builder);
        }
    }
}
