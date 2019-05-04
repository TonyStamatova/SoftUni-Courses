using System;
using System.Linq;

namespace condenseArrayToNumber
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (input.Length > 1)
            {
                int[] condensedArray = new int[input.Length - 1];
                for (int i = 0; i < input.Length - 1; i++)
                {
                    condensedArray[i] = input[i] + input[i + 1];
                }

                input = condensedArray;
            }
            
            Console.WriteLine(input[0]);
        }
    }
}
