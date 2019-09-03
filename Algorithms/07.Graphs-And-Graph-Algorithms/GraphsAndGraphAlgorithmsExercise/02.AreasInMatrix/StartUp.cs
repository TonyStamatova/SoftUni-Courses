namespace _02.AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private static char[,] matrix;
        private static bool[,] visited;

        private static Dictionary<char, int> areasCount;

        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            FillMatrix(rows);

            visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            areasCount = new Dictionary<char, int>();

            FindAreas();

            PrintResult();
        }

        private static void PrintResult()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Areas: {areasCount.Values.Sum()}");

            foreach (var areaType in areasCount.OrderBy(kvp => kvp.Key))
            {
                sb.AppendLine($"Letter '{areaType.Key}' -> {areaType.Value}");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static void FindAreas()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (visited[i, j] == true)
                    {
                        continue;
                    }

                    char currentChar = matrix[i, j];
                    TraverseConnectedArea(currentChar, i, j);
                    
                    if (!areasCount.ContainsKey(currentChar))
                    {
                        areasCount.Add(currentChar, 0);
                    }

                    areasCount[currentChar]++;
                }
            }
        }

        private static void TraverseConnectedArea(char areaChar, int row, int col)
        {
            if (!PositionIsValid(row, col, matrix) || areaChar != matrix[row, col] || visited[row, col])
            {
                return;
            }

            visited[row, col] = true;

            TraverseConnectedArea(areaChar, row, col + 1);
            TraverseConnectedArea(areaChar, row + 1, col);
            TraverseConnectedArea(areaChar, row, col - 1);
            TraverseConnectedArea(areaChar, row - 1, col);
        }

        private static bool PositionIsValid(int row, int col, char[,] matrix)
        {
            if (IndexIsValid(row, matrix, 0)
                && IndexIsValid(col, matrix, 1))
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

        private static void FillMatrix(int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                char[] row = Console.ReadLine()
                    .ToCharArray();

                if (i == 0)
                {
                    matrix = new char[rows, row.Length];
                }

                for (int j = 0; j < row.Length; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
        }
    }
}
