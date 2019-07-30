namespace P07PathsInALabyrinth
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static char[,] labyrinth;
        private static List<string> paths = new List<string>();

        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            labyrinth = new char[rows, cols];

            RenderInitialFieldState();

            Move(0, 0, string.Empty);

            Console.WriteLine(string.Join(Environment.NewLine, paths));
        }

        private static void Move(int currentRow, int currentCol, string currentPath)
        {
            if (!PositionIsValid(currentRow, currentCol))
            {
                return;
            }

            if (labyrinth[currentRow, currentCol] == 'e')
            {
                paths.Add(currentPath);
                return;
            }

            if (labyrinth[currentRow, currentCol] == '-')
            {
                labyrinth[currentRow, currentCol] = 'x';
                Move(currentRow - 1, currentCol, currentPath + 'U');
                Move(currentRow, currentCol + 1, currentPath + 'R');
                Move(currentRow + 1, currentCol, currentPath + 'D');
                Move(currentRow, currentCol - 1, currentPath + 'L');
                labyrinth[currentRow, currentCol] = '-';
            }
        }

        private static bool PositionIsValid(int row, int col)
        {
            if (IndexIsValid(row, 0)
                && IndexIsValid(col, 1))
            {
                return true;
            }

            return false;
        }

        private static bool IndexIsValid(int index, int dimension)
        {
            if (index >= 0 && index < labyrinth.GetLength(dimension))
            {
                return true;
            }

            return false;
        }

        private static void RenderInitialFieldState()
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                char[] row = Console.ReadLine()
                    .ToCharArray();

                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    labyrinth[i, j] = row[j];
                }
            }
        }
    }
}
