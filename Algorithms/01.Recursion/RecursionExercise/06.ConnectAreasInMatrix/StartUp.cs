namespace _06.ConnectAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Area
    {
        public Area(int startRow, int startCol)
        {
            this.StartRow = startRow;
            this.StartCol = startCol;
        }

        public int Size { get; set; }

        public int StartRow { get; private set; }
                                 
        public int StartCol { get; private set; }
    }

    public class StartUp
    {
        private static char[,] matrix;

        private static List<Area> areas = new List<Area>();

        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            FillInMatrixValues();

            TraverseMatrix();

            PrintResult();
        }

        private static void FillInMatrixValues()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine()
                    .ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
        }

        private static void TraverseMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == '-')
                    {
                        TraverseArea(i, j, new Area(i, j));
                    }
                }
            }
        }
        
        private static void TraverseArea(int row, int col, Area area)
        {
            if (!PositionIsValid(row, col) 
                || matrix[row, col] == '*' 
                || matrix[row,col] == 'x')
            {
                return;
            }

            if (matrix[row, col] == '-')
            {
                area.Size++;
                matrix[row, col] = 'x';
            }

            TraverseArea(row - 1, col, area);
            TraverseArea(row, col + 1, area);
            TraverseArea(row + 1, col, area);
            TraverseArea(row, col - 1, area);

            if (matrix[row, col] == 'x' && row == area.StartRow && col == area.StartCol)
            {
                areas.Add(area);
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine($"Total areas found: {areas.Count}");

            int index = 1;

            foreach (var area in areas.OrderByDescending(a => a.Size))
            {
                Console.WriteLine(
                    $"Area #{index} at ({area.StartRow}, {area.StartCol}), size: {area.Size}");
                index++;
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
            if (index >= 0 && index < matrix.GetLength(dimension))
            {
                return true;
            }

            return false;
        }
    }
}
