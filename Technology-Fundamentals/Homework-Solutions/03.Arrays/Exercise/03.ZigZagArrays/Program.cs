using System;
using System.Linq;

namespace _03.zigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstArr = new int[n];
            int[] secondArr = new int[n];
            int[] inputArr = new int[2];

            for (int i = 0; i < n; i++)
            {
                inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    firstArr[i] = inputArr[0];
                    secondArr[i] = inputArr[1];
                    continue;
                }

                firstArr[i] = inputArr[1];
                secondArr[i] = inputArr[0];
            }

            string firstArrToString = string.Join(" ", firstArr);
            string secondArrToString = string.Join(" ", secondArr);
            Console.WriteLine(firstArrToString + Environment.NewLine + secondArrToString);
        }
    }
}
