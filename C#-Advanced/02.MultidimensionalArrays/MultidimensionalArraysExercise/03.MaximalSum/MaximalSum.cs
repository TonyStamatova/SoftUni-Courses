namespace _03.MaximalSum
{
    using System;
    using System.Linq;

    public class MaximalSum
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int biggestSum = int.MinValue;
            int startRow = -1;
            int startCol = -1;

            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols - 2; j++)
                {
                    int currentSum = SumSubmtrix(i, j, matrix);

                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        startRow = i;
                        startCol = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {biggestSum}");

            if (startRow < 0 && startCol < 0)
            {
                return;
            }

            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int SumSubmtrix(int i, int j, int[,] matrix)
        {
            int sum = default(int);

            for (int r = i; r < i + 3; r++)
            {
                for (int c = j; c < j + 3; c++)
                {
                    sum += matrix[r, c];
                }
            }

            return sum;
        }
    }
}
