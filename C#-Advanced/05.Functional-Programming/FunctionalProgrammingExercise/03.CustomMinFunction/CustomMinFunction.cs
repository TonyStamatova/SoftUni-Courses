namespace _03.CustomMinFunction
{
    using System;
    using System.Linq;

    public class CustomMinFunction
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> findMin = (x, y) => x < y ? x : y;

            int minNumber = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                minNumber = findMin(minNumber, numbers[i]);
            }

            Action<string> print = x => Console.WriteLine(x);

            print(minNumber.ToString());
        }
    }
}
