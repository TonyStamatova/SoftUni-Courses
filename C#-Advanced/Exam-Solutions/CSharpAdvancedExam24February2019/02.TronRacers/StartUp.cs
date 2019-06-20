namespace _02.TronRacers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int[] playersData = RenderInitialFieldState(matrix);

            int fRow = playersData[0];
            int fCol = playersData[1];
            int sRow = playersData[2];
            int sCol = playersData[3];

            while (true)
            {
                string[] commandLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string fDirection = commandLine[0];
                string sDirection = commandLine[1];

                int[] nextPositionInfo = MovePlayer(fRow, fCol, matrix, fDirection);
                fRow = nextPositionInfo[0];
                fCol = nextPositionInfo[1];

                if (PlayerDies(matrix, fRow, fCol, 's'))
                {
                    matrix[fRow, fCol] = 'x';
                    break;
                }

                matrix[fRow, fCol] = 'f';

                nextPositionInfo = MovePlayer(sRow, sCol, matrix, sDirection);
                sRow = nextPositionInfo[0];
                sCol = nextPositionInfo[1];

                if (PlayerDies(matrix, sRow, sCol, 'f'))
                {
                    matrix[sRow, sCol] = 'x';
                    break;
                }

                matrix[sRow, sCol] = 's';
            }

            PrintFinalState(matrix);
        }

        private static void PrintFinalState(char[,] matrix)
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

        private static bool PlayerDies(char[,] matrix, int row, int col, char trail)
        {
            if (matrix[row, col] == trail)
            {
                return true;
            }

            return false;
        }

        private static int[] MovePlayer(int row, int col, char[,] matrix, string direction)
        {
            switch (direction.ToLower())
            {
                case "up":
                    row--;
                    break;
                case "down":
                    row++;
                    break;
                case "left":
                    col--;
                    break;
                case "right":
                    col++;
                    break;
            }

            row = CorrectIndex(row, matrix, 0);
            col = CorrectIndex(col, matrix, 1);

            int[] position = new int[] { row, col };

            return position;
        }

        private static int CorrectIndex(int index, char[,] matrix, int dimension)
        {
            if (index < 0)
            {
                index = matrix.GetLength(dimension) - 1;
            }
            else if (index >= matrix.GetLength(dimension))
            {
                index = 0;
            }

            return index;
        }

        private static int[] RenderInitialFieldState(char[,] matrix)
        {
            int fRow = default(int);
            int fCol = default(int);
            int sRow = default(int);
            int sCol = default(int);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine().ToLower()
                    .ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];

                    if (row[j] == 'f')
                    {
                        fRow = i;
                        fCol = j;
                    }
                    else if (row[j] == 's')
                    {
                        sRow = i;
                        sCol = j;
                    }
                }
            }

            return new int[] { fRow, fCol, sRow, sCol };
        }
    }
}
