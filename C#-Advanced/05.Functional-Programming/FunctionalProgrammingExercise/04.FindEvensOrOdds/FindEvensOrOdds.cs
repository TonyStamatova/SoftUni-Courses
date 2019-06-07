namespace _04.FindEvensOrOdds
{
    using System;
    using System.Linq;

    public class FindEvensOrOdds
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int lowerBound = input[0];
            int upperBound = input[1];
            string evenOrOdd = Console.ReadLine();

            Predicate<int> condition = x => false;
            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 != 0;

            switch (evenOrOdd)
            {
                case "even":
                    condition = isEven;
                    break;
                case "odd":
                    condition = isOdd;
                    break;
            }

            Action<int> print = x => Console.Write(x + " ");

            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (condition(i))
                {
                    print(i);
                }
            }
        }
    }
}
