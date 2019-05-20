namespace _02.SquaresInMatrix
{
    using System;
    using System.Linq;

    public class SquaresInMatrix
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
                char[] row = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int counter = default(int);

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    if (matrix[i,j] == matrix[i + 1, j]
                        && matrix[i, j] == matrix[i, j + 1]
                        && matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
