using System;
using System.Linq;

namespace _06.equalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int leftSum = default(int);
            int rightSum = default(int);
            bool thereIsSuchIndex = false;

            for (int i = 0; i < inputArr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    leftSum += inputArr[j];
                }

                for (int j = i + 1; j < inputArr.Length; j++)
                {
                    rightSum += inputArr[j];
                }

                if (leftSum == rightSum)
                {
                    thereIsSuchIndex = true;
                    Console.Write(i + " ");
                }

                leftSum = 0;
                rightSum = 0;
            }

            if (!thereIsSuchIndex)
            {
                Console.WriteLine("no");
            }
        }
    }
}
