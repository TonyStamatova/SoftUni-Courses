namespace _06.BombTheBasement
{
    using System;
    using System.Linq;

    public class BombTheBasement
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] basement = new int[rows, cols];

            int[] bombParameters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int targetRow = bombParameters[0];
            int targetCol = bombParameters[1];
            int radius = bombParameters[2];

            for (int i = 0; i < basement.GetLength(0); i++)
            {
                for (int j = 0; j < basement.GetLength(1); j++)
                {
                    if (IsInsideRadius(i, j, targetRow, targetCol, radius))
                    {
                        basement[i, j] = 1;
                    }
                }
            }

            MoveDamagedItems(basement);

            PrintMatrix(basement);
        }

        private static void MoveDamagedItems(int[,] basement)
        {
            for (int c = 0; c < basement.GetLength(1); c++)
            {
                int sumOfOnes = default(int);

                for (int r = 0; r < basement.GetLength(0); r++)
                {
                    sumOfOnes += basement[r, c];
                }

                for (int r = 0; r < sumOfOnes; r++)
                {
                    basement[r, c] = 1;
                }

                for (int r = sumOfOnes; r < basement.GetLength(0); r++)
                {
                    basement[r, c] = 0;
                }
            }
        }

        private static bool IsInsideRadius(int i, int j, int targetRow, int targetCol, int radius)
        {
            int horizontalSide = Math.Abs(targetRow - i);
            int verticalSide = Math.Abs(targetCol - j);
            int location = horizontalSide * horizontalSide + verticalSide * verticalSide;
            int blastPerimeter = radius * radius;

            if (location <= blastPerimeter)
            {
                return true;
            }

            return false;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
