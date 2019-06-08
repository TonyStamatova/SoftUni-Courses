namespace _08.CustomComparator
{
    using System;
    using System.Linq;

    public class CustomComparator
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> compare = (x, y)
                => (x % 2 == 0 && y % 2 != 0)
                ? -1
                : (x % 2 != 0 && y % 2 == 0)
                ? 1
                : (x < y)
                ? -1
                : (x > y)
                ? 1
                : 0;

            Array.Sort(numbers, (x, y) => compare(x, y));

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
