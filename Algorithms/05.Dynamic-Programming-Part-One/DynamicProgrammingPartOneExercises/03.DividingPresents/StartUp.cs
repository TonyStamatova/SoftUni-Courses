namespace _03.DividingPresents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int halfValue;

        private static int[,] biggestValue;
        private static bool[,] isItemTaken;

        public static void Main()
        {
            int[] presents = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sumValue = presents.Sum();

            halfValue = sumValue / 2;

            biggestValue = new int[presents.Length + 1, halfValue + 1];
            isItemTaken = new bool[presents.Length + 1, halfValue + 1];

            DesideWhichPresentsToTake(presents);

            List<int> alansItems = ReconstructSolution(presents);

            PrintResult(alansItems, sumValue);
        }

        private static void PrintResult(List<int> alansItems, int sumValue)
        {
            int alansSum = alansItems.Sum();
            int bobsSum = sumValue - alansSum;

            Console.WriteLine($"Difference: {bobsSum - alansSum}");
            Console.WriteLine($"Alan:{alansSum} Bob:{bobsSum}");
            Console.WriteLine($"Alan takes: {string.Join(" ", alansItems)}");
            Console.WriteLine("Bob takes the rest.");

        }

        private static List<int> ReconstructSolution(int[] presents)
        {
            List<int> result = new List<int>();

            int currentRow = isItemTaken.GetLength(0) - 1;
            int currentCol = isItemTaken.GetLength(1) - 1;

            for (int presentIndex = currentRow - 1; presentIndex >= 0; presentIndex--)
            {
                int presentValue = presents[presentIndex];

                if (isItemTaken[currentRow, currentCol])
                {
                    result.Add(presentValue);

                    currentCol -= presentValue;
                }

                currentRow--;
            }

            return result;
        }

        private static void DesideWhichPresentsToTake(int[] presents)
        {
            for (int row = 1; row <= presents.Length; row++)
            {
                int presentIndex = row - 1;
                int presentValue = presents[presentIndex];

                for (int currentCapacity = 0; currentCapacity <= halfValue; currentCapacity++)
                {
                    int valueIfNotTaken = biggestValue[row - 1, currentCapacity];

                    int valueIfTaken = 0;

                    if (currentCapacity >= presentValue)
                    {
                        valueIfTaken = presentValue + biggestValue[row - 1, currentCapacity - presentValue];
                    }

                    int maxValue = valueIfNotTaken;

                    if (valueIfTaken > valueIfNotTaken)
                    {
                        isItemTaken[row, currentCapacity] = true;
                        maxValue = valueIfTaken;
                    }

                    biggestValue[row, currentCapacity] = maxValue;
                }
            }
        }
    }
}
