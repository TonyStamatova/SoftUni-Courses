namespace P03_JediGalaxy
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            int[] dimensions = CommandParser.Parse(Console.ReadLine());

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            FillInMatrixValues(matrix);

            string command = Console.ReadLine();
            long sum = default(long);

            while (command != "Let the Force be with you")
            {
                Player ivo = PlayerFactory.Create(command);
                Player evil = PlayerFactory.Create(Console.ReadLine());

                while (evil.IsStillPlaying(0, x => x >= 0))
                {
                    if (evil.IsInBounds(matrix.GetLength(0), matrix.GetLength(1)))
                    {
                        matrix[evil.Row, evil.Col] = 0;
                    }

                    evil.Move(-1, -1);
                }

                while (ivo.IsStillPlaying(0, x => x < matrix.GetLength(1)))
                {
                    if (ivo.IsInBounds(matrix.GetLength(0), matrix.GetLength(1)))
                    {
                        sum += matrix[ivo.Row, ivo.Col];
                    }

                    ivo.Move(-1, +1);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        private static void FillInMatrixValues(int[,] matrix)
        {
            int value = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }
    }
}
