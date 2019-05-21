namespace _07.KnightGame
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class KnightGame
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            FillInMatrixValues(board);

            int sumOfRemovedKnights = default(int);

            while (true)
            {
                bool attackingKnightsExist = false;
                int bestAttackCount = default(int);
                int biggestThreatRow = default(int);
                int biggestThreatCol = default(int);

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] != 'K')
                        {
                            continue;
                        }

                        KeyValuePair<int, int>[] attackedSquares = GetAttackedSquares(i, j, size);

                        if (attackedSquares.Length == 0)
                        {
                            continue;
                            
                        }

                        int attackedKnights = default(int);

                        foreach (var square in attackedSquares)
                        {
                            int row = square.Key;
                            int col = square.Value;

                            if (board[row, col] == 'K')
                            {
                                attackingKnightsExist = true;
                                attackedKnights++;
                            }
                        }

                        if (attackedKnights > bestAttackCount)
                        {
                            bestAttackCount = attackedKnights;
                            biggestThreatRow = i;
                            biggestThreatCol = j;
                        }
                    }
                }

                if (!attackingKnightsExist)
                {
                    break;
                }
                else
                {
                    board[biggestThreatRow, biggestThreatCol] = '0';
                    sumOfRemovedKnights++;
                }
            }

            Console.WriteLine(sumOfRemovedKnights);
        }

        private static void FillInMatrixValues(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
        }
        
        private static KeyValuePair<int, int>[] GetAttackedSquares(int knightRow, int knightCol, int size)
        {
            KeyValuePair<int, int>[] result = new KeyValuePair<int, int>[]
            {
                 new KeyValuePair<int, int>(knightRow - 2, knightCol - 1 ),
                 new KeyValuePair<int, int>(knightRow - 2, knightCol + 1 ),
                 new KeyValuePair<int, int>(knightRow - 1, knightCol - 2 ),
                 new KeyValuePair<int, int>(knightRow - 1, knightCol + 2 ),
                 new KeyValuePair<int, int>(knightRow + 1, knightCol - 2 ),
                 new KeyValuePair<int, int>(knightRow + 1, knightCol + 2 ),
                 new KeyValuePair<int, int>(knightRow + 2, knightCol - 1 ),
                 new KeyValuePair<int, int>(knightRow + 2, knightCol + 1 )
            };

            result = result.Where(x => x.Key >= 0 && x.Key < size
                && x.Value >= 0 && x.Value < size)
                .ToArray();

            return result;
        }
    }
}
