using System;
using System.Linq;

namespace _08.magicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputArr.Length; i++)
            {
                for (int j = i; j < inputArr.Length; j++)
                {
                    if (inputArr[i] + inputArr[j] == sum && i != j)
                    {
                        Console.WriteLine(inputArr[i] + " " + inputArr[j]);
                    }
                }
            }
        }
    }
}
