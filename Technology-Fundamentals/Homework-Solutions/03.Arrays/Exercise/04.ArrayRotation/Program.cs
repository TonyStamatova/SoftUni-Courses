using System;
using System.Linq;

namespace _04.arrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numberOfRotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRotations; i++)
            {
                int[] newArr = new int[arr.Length];

                for (int j = 0; j < newArr.Length - 1; j++)
                {
                    newArr[j] = arr[j + 1];
                }

                newArr[newArr.Length - 1] = arr[0];
                arr = newArr;
            }

            string result = string.Join(" ", arr);
            Console.WriteLine(result);
        }
    }
}
