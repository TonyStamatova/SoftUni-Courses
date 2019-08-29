namespace _04.SumWithUnlimitedCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] coinValues = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int sum = int.Parse(Console.ReadLine());

            if (sum == 0)
            {
                Console.WriteLine(1);
                return;
            }

            List<int> possibleSums = new List<int>();

            Console.WriteLine(FindAllPossibleSums(coinValues, sum, possibleSums));
        }

        private static int FindAllPossibleSums(int[] coinValues, int sum, List<int> possibleSums)
        {
            int counter = default(int);

            possibleSums.Add(0);

            foreach (var value in coinValues)
            {
                int maxCountOfCurrentCoin = sum / value;

                List<int> possibleSoFar = possibleSums.ToList();

                for (int i = 1; i <= maxCountOfCurrentCoin; i++)
                {
                    int valueTimesCount = i * value;

                    foreach (var possibleSum in possibleSoFar)
                    {
                        int newSum = possibleSum + valueTimesCount;

                        if (newSum <= sum)
                        {
                            possibleSums.Add(newSum);

                            if (newSum == sum)
                            {
                                counter++;
                            }
                        }
                    }
                }
            }

            return counter;
        }
    }
}
