using System;
using System.Linq;

namespace _07.maxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int biggestCount = default(int);
            int result = default(int);

            for (int i = 1; i < inputArr.Length; i++)
            {
                int counter = 1;

                while (inputArr[i - 1] == inputArr[i])
                {
                    counter++;

                    if (i == inputArr.Length - 1)
                    {
                        break;
                    }

                    i++;
                }

                if (biggestCount < counter)
                {
                    biggestCount = counter;
                    result = inputArr[i - 1];
                }
            }

            int[] resultArr = new int[biggestCount];

            for (int i = 0; i < resultArr.Length; i++)
            {
                resultArr[i] = result;
            }

            string resultStr = string.Join(" ", resultArr);
            Console.WriteLine(resultStr);
        }
    }
}
