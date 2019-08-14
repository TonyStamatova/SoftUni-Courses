namespace _03.MoveDownRight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] numbers = new int[rows, cols];

            FillInMatrixValues(numbers);

            int[,] sums = new int[rows, cols];
            FillSumMatrix(numbers, sums);

            List<string> result = FindPath(rows, cols, sums);

            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
        }

        private static List<string> FindPath(int rows, int cols, int[,] sums)
        {
            List<string> result = new List<string>();

            result.Add($"[{rows - 1}, {cols - 1}]");

            int currentRow = rows - 1;
            int currentCol = cols - 1;

            while (currentRow != 0 || currentCol != 0)
            {
                int top = -1;
                int left = -1;

                if (currentRow - 1 >= 0)
                {
                    top = sums[currentRow - 1, currentCol];
                }

                if (currentCol - 1 >= 0)
                {
                    left = sums[currentRow, currentCol - 1];
                }

                if (top > left)
                {
                    result.Add($"[{currentRow - 1}, {currentCol}]");
                    currentRow--;
                }
                else
                {
                    result.Add($"[{currentRow}, {currentCol - 1}]");
                    currentCol--;
                }
            }

            return result;
        }

        private static void FillSumMatrix(int[,] numbers, int[,] sums)
        {
            sums[0, 0] = numbers[0, 0];

            for (int row = 1; row < numbers.GetLength(0); row++)
            {
                sums[row, 0] = numbers[row, 0] + sums[row - 1, 0];
            }

            for (int col = 1; col < numbers.GetLength(1); col++)
            {
                sums[0, col] = numbers[0, col] + sums[0, col - 1];
            }

            for (int row = 1; row < numbers.GetLength(0); row++)
            {
                for (int col = 1; col < numbers.GetLength(1); col++)
                {
                    sums[row, col] = Math.Max(sums[row - 1, col], sums[row, col - 1]) + numbers[row, col];
                }
            }
        }

        private static void FillInMatrixValues(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
        }
    }
}
