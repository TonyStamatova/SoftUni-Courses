namespace _02.SumNumbers
{
    using System;
    using System.Collections;
    using System.Linq;

    public class SumNumbers
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> findCount = FindCount;
            Result(numbers, findCount);

            Func<int[], int> findSum = FindSum;
            Result(numbers, findSum);
        }

        private static int FindSum(IEnumerable collection)
        {
            int sum = default(int);

            foreach (var item in collection)
            {
                sum += int.Parse(item.ToString());
            }

            return sum;
        }

        public static int FindCount(IEnumerable collection)
        {
            int count = default(int);

            foreach (var item in collection)
            {
                count++;
            }

            return count;
        }
        public static void Result(int[] input, Func<int[], int> traversal)
        {
            Console.WriteLine(traversal(input));
        }
    }
}
