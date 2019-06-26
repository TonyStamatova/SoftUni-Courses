namespace _03.SpaceStationEstablishment
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char[,] galaxy = new char[size, size];

            int[] initialData = RenderInitialFieldState(galaxy);

            int stevenRow = initialData[0];
            int stevenCol = initialData[1];

            int firstBlackHoleRow = initialData[2];
            int firstBlackHoleCol = initialData[3];
            int secondBlackHoleRow = initialData[4];
            int secondBlackHoleCol = initialData[5];

            int starPower = default(int);

            while (true)
            {
                string command = Console.ReadLine();

                galaxy[stevenRow, stevenCol] = '-';

                int nextRow = stevenRow;
                int nextCol = stevenCol;

                switch (command)
                {
                    case "up":
                        nextRow--;
                        break;
                    case "down":
                        nextRow++;
                        break;
                    case "left":
                        nextCol--;
                        break;
                    case "right":
                        nextCol++;
                        break;
                }

                if (PositionIsValid(nextRow, nextCol, galaxy))
                {
                    if (char.IsDigit(galaxy[nextRow, nextCol]))
                    {
                        int star = int.Parse(galaxy[nextRow, nextCol].ToString());
                        starPower += star;
                        galaxy[nextRow, nextCol] = '-';

                        stevenRow = nextRow;
                        stevenCol = nextCol;

                        if (starPower >= 50)
                        {
                            galaxy[nextRow, nextCol] = 'S';
                            Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                            break;
                        }
                    }
                    else if (galaxy[nextRow, nextCol] == 'O')
                    {
                        if (nextRow == firstBlackHoleRow && nextCol == firstBlackHoleCol)
                        {
                            stevenRow = secondBlackHoleRow;
                            stevenCol = secondBlackHoleCol;
                        }
                        else
                        {
                            stevenRow = firstBlackHoleRow;
                            stevenCol = firstBlackHoleCol;
                        }

                        galaxy[firstBlackHoleRow, firstBlackHoleCol] = '-';
                        galaxy[secondBlackHoleRow, secondBlackHoleCol] = '-';
                    }
                    else
                    {
                        stevenRow = nextRow;
                        stevenCol = nextCol;
                    }
                }
                else
                {
                    Console.WriteLine("Bad news, the spaceship went to the void.");
                    break;
                }
            }

            Console.WriteLine($"Star power collected: {starPower}");

            PrintFinalState(galaxy);
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

        private static bool PositionIsValid(int row, int col, char[,] matrix)
        {
            if (IndexIsValid(row, matrix, 0) && IndexIsValid(col, matrix, 1))
            {
                return true;
            }

            return false;
        }

        private static bool IndexIsValid(int index, char[,] matrix, int dimension)
        {
            if (index >= 0 && index < matrix.GetLength(dimension))
            {
                return true;
            }

            return false;
        }

        private static int[] RenderInitialFieldState(char[,] matrix)
        {
            int stavenRow = default(int);
            int stevenCol = default(int);
            int firstBlackHoleRow = -1;
            int firstBlackHoleCol = -1;
            int secondBlackHoleRow = -1;
            int secondBlackHoleCol = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine()
                    .ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];

                    if (row[j] == 'S')
                    {
                        stavenRow = i;
                        stevenCol = j;
                    }
                    else if (row[j] == 'O')
                    {
                        if (firstBlackHoleRow != -1)
                        {
                            secondBlackHoleRow = i;
                            secondBlackHoleCol = j;
                        }
                        else
                        {
                            firstBlackHoleRow = i;
                            firstBlackHoleCol = j;
                        }
                    }
                }
            }

            return new int[] {
                stavenRow,
                stevenCol,
                firstBlackHoleRow,
                firstBlackHoleCol,
                secondBlackHoleRow,
                secondBlackHoleCol
            };
        }
    }
}
