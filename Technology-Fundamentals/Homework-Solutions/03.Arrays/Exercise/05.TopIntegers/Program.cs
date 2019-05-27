using System;
using System.Linq;

namespace _05.topIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool isTopInt = true;

            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[i] <= inputArray[j])
                    {
                        isTopInt = false;
                    }
                }

                if (isTopInt)
                {
                    Console.Write(inputArray[i] + " ");
                }

                isTopInt = true;
            }

            Console.WriteLine();
        }
    }
}
