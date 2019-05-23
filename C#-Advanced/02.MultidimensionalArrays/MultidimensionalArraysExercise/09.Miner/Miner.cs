namespace _09.Miner
{
    using System;
    using System.Linq;

    public class Miner
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();

            char[,] field = new char[size, size];
            int[] initialGameData = RenderInitialFieldState(field);
            int minerRow = initialGameData[0];
            int minerCol = initialGameData[1];
            int coalCount = initialGameData[2];

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];
                int nextRow = minerRow;
                int nextCol = minerCol;

                switch (command)
                {
                    case "left":
                        nextCol = minerCol - 1;
                        break;
                    case "right":
                        nextCol = minerCol + 1;
                        break;
                    case "up":
                        nextRow = minerRow - 1;
                        break;
                    case "down":
                        nextRow = minerRow + 1;
                        break;
                }

                if (PositionIsValid(nextRow, nextCol, field))
                {
                    minerRow = nextRow;
                    minerCol = nextCol;

                    switch (field[minerRow, minerCol])
                    {
                        case 'c':
                            coalCount--;
                            field[minerRow, minerCol] = '*';
                            break;
                        case 'e':
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                    }

                    if (coalCount == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{coalCount} coals left. ({minerRow}, {minerCol})");
        }

        private static bool PositionIsValid(int row, int col, char[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }

        private static int[] RenderInitialFieldState(char[,] matrix)
        {
            int minerRow = default(int);
            int minerCol = default(int);
            int coalCount = default(int);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                    if (row[j] == 's')
                    {
                        minerRow = i;
                        minerCol = j;
                    }
                    else if (row[j] == 'c')
                    {
                        coalCount++;
                    }
                }
            }

            return new int[] { minerRow, minerCol, coalCount };
        }
    }
}
