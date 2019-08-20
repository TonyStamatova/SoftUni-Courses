namespace DynamicProgrammingPartTwoExercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] unorderedSide = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] orderedSide = unorderedSide
                .OrderBy(x => x)
                .ToArray();

            Dictionary<int, int> indexedByNumber = new Dictionary<int, int>();

            for (int i = 1; i <= orderedSide.Length; i++)
            {
                indexedByNumber.Add(orderedSide[i - 1], i);
            }

            int[,] bestCountMatrix = new int[unorderedSide.Length + 1, unorderedSide.Length + 1];

            CalculateBestCounts(orderedSide, unorderedSide, indexedByNumber, bestCountMatrix);

            Console.WriteLine(
                "Maximum pairs connected: "
                 + $"{bestCountMatrix[bestCountMatrix.GetLength(0) - 1, bestCountMatrix.GetLength(1) - 1]}");
        }

        private static void CalculateBestCounts(
            int[] orderedSide,
            int[] unorderedSide,
            Dictionary<int, int> indexedByNumber,
            int[,] bestCountMatrix)
        {
            for (int row = 1; row < bestCountMatrix.GetLength(0); row++)
            {
                int unorderedIdex = row - 1;
                int cable = unorderedSide[unorderedIdex];

                for (int col = 1; col < bestCountMatrix.GetLength(1); col++)
                {
                    int bestCountSoFar = Math.Max(bestCountMatrix[row - 1, col], bestCountMatrix[row, col - 1]);

                    int bestCountIfConnected = bestCountMatrix[row - 1, indexedByNumber[cable]] + 1;

                    if (bestCountIfConnected >= bestCountSoFar && orderedSide[col - 1] == cable)
                    {
                        bestCountSoFar = bestCountIfConnected;
                    }

                    bestCountMatrix[row, col] = bestCountSoFar;
                }
            }
        }
    }
}
