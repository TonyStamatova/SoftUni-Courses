namespace _05.SnakeMoves
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SnakeMoves
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] isle = new char[rows, cols];

            Queue<char> snake = new Queue<char>(Console.ReadLine().ToCharArray());

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    char current = snake.Dequeue();
                    isle[i, j] = current;
                    snake.Enqueue(current);
                }
            }

            PrintMatrix(isle);
        }

        private static void PrintMatrix(char[,] matrix)
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
