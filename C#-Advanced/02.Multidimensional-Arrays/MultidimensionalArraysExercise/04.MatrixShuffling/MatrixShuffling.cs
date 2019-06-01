namespace _04.MatrixShuffling
{
    using System;
    using System.Linq;

    public class MatrixShuffling
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = new string[rows, cols];

            FillInMatrixValues(matrix);

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                input = Console.ReadLine();

                if (data[0] != "swap" || data.Length != 5)
                {
                    PrintExceptionMessage();
                    continue;
                }

                bool dataIsValid = true;

                for (int i = 1; i < data.Length; i++)
                {
                    bool isValidIndex = int.TryParse(data[i], out int result);

                    if (!isValidIndex)
                    {
                        dataIsValid = false;
                        break;
                    }
                }

                if (!dataIsValid)
                {
                    PrintExceptionMessage();
                    continue;
                }

                int row1 = int.Parse(data[1]);
                int col1 = int.Parse(data[2]);
                int row2 = int.Parse(data[3]);
                int col2 = int.Parse(data[4]);

                if (!IsInBounds(row1, matrix, 0) || !IsInBounds(row2, matrix, 0)
                    || !IsInBounds(col1, matrix, 1) || !IsInBounds(col2, matrix, 1))
                {
                    PrintExceptionMessage();
                    continue;
                }

                string tempValue = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = tempValue;

                PrintMatrix(matrix);
            }
        }       

        private static void FillInMatrixValues(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
        }

        private static void PrintExceptionMessage()
        {
            Console.WriteLine("Invalid input!");
        }

        private static bool IsInBounds(int index, string[,] matrix, int dimension)
        {
            if (index >= 0 && index < matrix.GetLength(dimension))
            {
                return true;
            }

            return false;
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
