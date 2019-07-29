namespace P06EightQueensPuzzle
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static char[,] chessboard = new char[8, 8];

        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        public static void Main()
        {
            MarkEmptyCells();

            TryToPlaceAQueen(0);
        }

        private static void MarkEmptyCells()
        {
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    chessboard[i, j] = '-';
                }
            }
        }

        private static void TryToPlaceAQueen(int row)
        {

            if (row == 8)
            {
                PrintSolutionChessboard();
                Console.WriteLine();
                return;
            }

            for (int i = 0; i < 8; i++)
            {
                int col = i;
                int leftDiagonal = i - row;
                int rightDiagonal = i + row;

                if (PositionIsSafe(col, leftDiagonal, rightDiagonal))
                {
                    MarkPosition(row, i, col, leftDiagonal, rightDiagonal);

                    TryToPlaceAQueen(row + 1);

                    UnmarkPosition(row, i, col, leftDiagonal, rightDiagonal);
                }
            }
        }

        private static void PrintSolutionChessboard()
        {
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    Console.Write(chessboard[i,j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void UnmarkPosition(int row, int i, int col, int leftDiagonal, int rightDiagonal)
        {
            chessboard[row, i] = '-';
            attackedCols.Remove(col);
            attackedLeftDiagonals.Remove(leftDiagonal);
            attackedRightDiagonals.Remove(rightDiagonal);
        }

        private static bool PositionIsSafe(int col, int leftDiagonal, int rightDiagonal)
        {
            if (attackedCols.Contains(col)
                || attackedLeftDiagonals.Contains(leftDiagonal)
                || attackedRightDiagonals.Contains(rightDiagonal))
            {
                return false;
            }

            return true;
        }

        private static void MarkPosition(int row, int i, int col, int leftDiagonal, int rightDiagonal)
        {
            chessboard[row, i] = '*';
            attackedCols.Add(col);
            attackedLeftDiagonals.Add(leftDiagonal);
            attackedRightDiagonals.Add(rightDiagonal);
        }
    }
}
