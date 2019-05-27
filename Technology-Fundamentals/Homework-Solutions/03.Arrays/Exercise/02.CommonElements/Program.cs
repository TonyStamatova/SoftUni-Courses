using System;
using System.Linq;

namespace _02.commonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split().ToArray();
            string[] secondArray = Console.ReadLine().Split().ToArray();

            string[] resultArr = new string[Math.Min(firstArray.Length, secondArray.Length)];
            int indexOfResultArray = default(int);

            for (int j = 0; j < secondArray.Length; j++)
            {
                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (firstArray[i] == secondArray[j])
                    {
                        resultArr[indexOfResultArray] = firstArray[i];
                        indexOfResultArray++;
                    }
                }
            }

            string result = string.Join(" ", resultArr);
            Console.WriteLine(result);
        }
    }
}
