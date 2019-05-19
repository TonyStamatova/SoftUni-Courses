namespace _02.SumMatrixColumns
{
    using System;
    using System.Linq;

    public class SumMatrixColumns
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
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            for (int i = 0; i < columns; i++)
            {
                int sum = default(int);

                for (int j = 0; j < rows; j++)
                {
                    sum += matrix[j, i];
                }

                Console.WriteLine(sum);
            }
        }
    }
}
