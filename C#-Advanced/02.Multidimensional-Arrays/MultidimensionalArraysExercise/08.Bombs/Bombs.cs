namespace _08.Bombs
{
    using System;
    using System.Linq;

    public class Bombs
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            FillInMatrixValues(matrix);

            string[] bombs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var bomb in bombs)
            {
                int[] coordinates = bomb.Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int bombRow = coordinates[0];
                int bombCol = coordinates[1];

                if (matrix[bombRow, bombCol] > 0)
                {
                    DoDamage(matrix, bombRow, bombCol);
                }
            }

            int aliveCells = default(int);
            int sum = default(int);

            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCells++;
                    sum += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            PrintMatrix(matrix);
        }
        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void DoDamage(int[,] matrix, int row, int col)
        {
            int damage = matrix[row, col];

            for (int i = row - 1; i <= row + 1; i++)
            {
                if (!IndexIsValid(i, matrix, 0))
                {
                    continue;
                }


                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (!IndexIsValid(j, matrix, 1) || matrix[i, j] <= 0)
                    {
                        continue;
                    }

                    matrix[i, j] -= damage;
                }
            }

            matrix[row, col] = 0;
        }

        private static bool IndexIsValid(int index, int[,] matrix, int dimension)
        {
            if (index >= 0 && index < matrix.GetLength(dimension))
            {
                return true;
            }

            return false;
        }

        private static void FillInMatrixValues(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
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
