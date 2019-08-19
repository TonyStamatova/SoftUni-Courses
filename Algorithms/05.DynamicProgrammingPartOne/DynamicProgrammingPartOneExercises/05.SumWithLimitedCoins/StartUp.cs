namespace _05.SumWithLimitedCoins
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

            Dictionary<int, int> coinsWithCount = CountAvailableCoins(coinValues);
            int count = FindAllPossibleSums(sum, coinsWithCount);
            Console.WriteLine(count);
        }

        private static Dictionary<int, int> CountAvailableCoins(int[] coinValues)
        {
            Dictionary<int, int> coinsWithCount = new Dictionary<int, int>();

            foreach (var coin in coinValues)
            {
                if (!coinsWithCount.ContainsKey(coin))
                {
                    coinsWithCount.Add(coin, 0);
                }

                coinsWithCount[coin]++;
            }

            return coinsWithCount;
        }

        private static int FindAllPossibleSums(int sum, Dictionary<int, int> coinsWithCount)
        {
            int counter = default(int);

            List<int> possibleSums = new List<int>();

            possibleSums.Add(0);

            foreach (var kvp in coinsWithCount)
            {
                int maxCountOfCurrentCoin = kvp.Value;

                List<int> possibleSoFar = possibleSums.ToList();

                for (int i = 1; i <= maxCountOfCurrentCoin; i++)
                {
                    int valueTimesCount = i * kvp.Key;

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
