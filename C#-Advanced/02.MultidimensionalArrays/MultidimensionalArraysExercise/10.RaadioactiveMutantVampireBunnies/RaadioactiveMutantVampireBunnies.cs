namespace _10.RaadioactiveMutantVampireBunnies
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class RaadioactiveMutantVampireBunnies
    {
        public static void Main()
        {
            int[] layerDimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = layerDimensions[0];
            int cols = layerDimensions[1];

            char[,] layer = new char[rows, cols];
            List<KeyValuePair<int, int>> bunnies = new List<KeyValuePair<int, int>>();

            int[] initialGameData = RenderInitialLayerState(layer, bunnies);
            int playerRow = initialGameData[0];
            int playerCol = initialGameData[1];

            char[] moves = Console.ReadLine().ToCharArray();

            int nextRow = playerRow;
            int nextCol = playerCol;

            bool playerDies = false;

            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'R':
                        nextCol = playerCol + 1;
                        break;
                    case 'L':
                        nextCol = playerCol - 1;
                        break;
                    case 'U':
                        nextRow = playerRow - 1;
                        break;
                    case 'D':
                        nextRow = playerRow + 1;
                        break;
                }

                layer[playerRow, playerCol] = '.';

                if (PositionIsValid(nextRow, nextCol, layer))
                {
                    playerRow = nextRow;
                    playerCol = nextCol;

                    BunniesMultiply(layer, bunnies);

                    if (layer[playerRow, playerCol] == 'B')
                    {
                        playerDies = true;
                        break;
                    }
                    else if (layer[playerRow, playerCol] == '.')
                    {
                        layer[playerRow, playerCol] = 'P';
                    }
                }
                else
                {
                    playerDies = false;
                    BunniesMultiply(layer, bunnies);
                    break;
                }
            }

            PrintLayer(layer);

            if (playerDies)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
        }

        private static void PrintLayer(char[,] layer)
        {
            for (int i = 0; i < layer.GetLength(0); i++)
            {
                for (int j = 0; j < layer.GetLength(1); j++)
                {
                    Console.Write(layer[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void BunniesMultiply(char[,] layer, List<KeyValuePair<int, int>> bunnies)
        {
            int count = bunnies.Count;
            for (int i = 0; i < count; i++)
            {
                KeyValuePair<int, int> bunny = bunnies[i];
                PositionNewBunny(layer, bunnies, bunny.Key - 1, bunny.Value);
                PositionNewBunny(layer, bunnies, bunny.Key, bunny.Value + 1);
                PositionNewBunny(layer, bunnies, bunny.Key + 1, bunny.Value);
                PositionNewBunny(layer, bunnies, bunny.Key, bunny.Value - 1);
            }
        }

        private static void PositionNewBunny(
            char[,] layer,
            List<KeyValuePair<int, int>> bunnies,
            int newBunnyRow,
            int newBunnyCol)
        {
            if (PositionIsValid(newBunnyRow, newBunnyCol, layer) && layer[newBunnyRow, newBunnyCol] != 'B')
            {
                layer[newBunnyRow, newBunnyCol] = 'B';
                bunnies.Add(new KeyValuePair<int, int>(newBunnyRow, newBunnyCol));
            }
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

        private static int[] RenderInitialLayerState(char[,] matrix, List<KeyValuePair<int, int>> bunnies)
        {
            int playerRow = default(int);
            int playerCol = default(int);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                    if (row[j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                    else if (row[j] == 'B')
                    {
                        bunnies.Add(new KeyValuePair<int, int>(i, j));
                    }
                }
            }

            return new int[] { playerRow, playerCol };
        }
    }
}
