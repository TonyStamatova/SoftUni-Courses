namespace _03.Bombs
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];
            RenderInitialFieldState(matrix);

            string[] bombCells = Console.ReadLine()
                .Split();

            foreach (var cell in bombCells)
            {
                int[] coordinates = cell
                    .Split(",")
                    .Select(int.Parse)
                    .ToArray();

                int row = coordinates[0];
                int col = coordinates[1];

                if (matrix[row, col] <= 0)
                {
                    continue;
                }

                DoDamage(matrix, row, col);
            }

            int[] finalInfo = CollectResultData(matrix);
            int aliveCells = finalInfo[0];
            int sumOfCells = finalInfo[1];

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfCells}");

            PrintFinalState(matrix);
        }

        private static int[] CollectResultData(int[,] matrix)
        {
            int aliveCells = default(int);
            int sum = default(int);
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        aliveCells++;
                        sum += matrix[i, j];
                    }                   
                }
            }

            return new int[] { aliveCells, sum };
        }

        private static void PrintFinalState(int[,] layer)
        {
            for (int i = 0; i < layer.GetLength(0); i++)
            {
                for (int j = 0; j < layer.GetLength(1); j++)
                {
                    Console.Write(layer[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void DoDamage(int[,] matrix, int row, int col)
        {
            int bombPower = matrix[row, col];

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (PositionIsValid(i, j, matrix) && matrix[i,j] > 0)
                    {
                        matrix[i, j] -= bombPower;
                    }
                }
            }

            matrix[row, col] = 0;
        }

        private static bool PositionIsValid(int row, int col, int[,] matrix)
        {
            if (IndexIsValid(row, matrix, 0)
                && IndexIsValid(col, matrix, 1))
            {
                return true;
            }

            return false;
        }

        private static bool IndexIsValid(int index, int[,] matrix, int dimension)
        {
            if (index >= 0 && index < matrix.GetLength(dimension))
            {
                return true;
            }

            return false;
        }

        private static void RenderInitialFieldState(int[,] matrix)
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
