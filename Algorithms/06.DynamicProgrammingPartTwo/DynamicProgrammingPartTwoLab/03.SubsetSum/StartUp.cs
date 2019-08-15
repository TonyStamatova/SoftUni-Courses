namespace _03.SubsetSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int[] numbers;
        private static int desiredSum;

        public static void Main()
        {
            numbers = Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            desiredSum = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbersAddedBySum = CalculateSums();

            List<int> result = FindTheFirstSubset(numbersAddedBySum);

            Console.WriteLine("{" + string.Join(", ", result) + "}");
        }

        private static List<int> FindTheFirstSubset(Dictionary<int, int> sums)
        {
            List<int> result = new List<int>();

            int currentSum = desiredSum;
            int number = sums[desiredSum];

            while (true)
            {
                result.Add(number);
                currentSum -= number;

                if (currentSum == 0)
                {
                    break;
                }

                number = sums[currentSum];
            }

            result.Reverse();

            return result;
        }

        private static Dictionary<int, int> CalculateSums()
        {
            Dictionary<int, int> sums = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                HashSet<int> newSums = new HashSet<int>();
                newSums.Add(numbers[i]);

                foreach (var sum in sums)
                {
                    int currentSum = sum.Key + numbers[i];
                    newSums.Add(currentSum);

                    if (currentSum == desiredSum)
                    {
                        break;
                    }
                }

                foreach (var sum in newSums)
                {
                    if (!sums.ContainsKey(sum))
                    {
                        sums.Add(sum, numbers[i]);
                    }
                }
            }

            return sums;
        }
    }
}
