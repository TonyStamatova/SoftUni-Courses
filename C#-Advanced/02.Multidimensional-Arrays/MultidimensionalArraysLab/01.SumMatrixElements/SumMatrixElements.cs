namespace _01.SumMatrixElements
{
    using System;
    using System.Linq;

    public class SumMatrixElements
    {
        public static void Main()
        {
            int[] matrixInfo = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = matrixInfo[0];
            int columns = matrixInfo[1];

            int[,] matrix = new int[rows,columns];

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

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));

            int sum = default(int);

            foreach (var element in matrix)
            {
                sum += element;
            }

            Console.WriteLine(sum);
        }
    }
}
