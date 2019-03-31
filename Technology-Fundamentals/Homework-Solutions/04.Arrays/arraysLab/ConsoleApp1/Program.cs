using System;
using System.Linq;

namespace equalArrays
{
    class Program
    {
        static void Main()
        {
            int[] firstArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] secondArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bool areEqual = true;
            string result = string.Empty;
            int sum = default(int);

            for (int i = 0; i < firstArray.Length; i++)
            {
                sum += firstArray[i];
                if (firstArray[i] != secondArray[i])
                {
                    result = $"Arrays are not identical. Found difference at {i} index";
                    areEqual = false;
                    break;
                }
            }

            if (areEqual)
            {                
                result = $"Arrays are identical. Sum: {sum}";
            }

            Console.WriteLine(result);
        }
    }
}
