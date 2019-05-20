namespace _05.SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class SquareWithMaximumSum
    {
        public static void Main()
        {
            int[] matrixInfo = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = matrixInfo[0];
            int columns = matrixInfo[1];

            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int biggestSum = default(int);
            int startRow = default(int);
            int startCol = default(int);
            
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < columns - 1; j++)
                {
                    int currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        startRow = i;
                        startCol = j;
                    }
                }
            }

            for (int i = startRow; i <= startRow + 1; i++)
            {
                for (int j = startCol; j <= startCol + 1; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(biggestSum);
        }
    }
}
