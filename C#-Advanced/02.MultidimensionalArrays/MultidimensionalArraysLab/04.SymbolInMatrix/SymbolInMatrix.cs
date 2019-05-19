namespace _04.SymbolInMatrix
{
    using System;
    using System.Linq;

    public class SymbolInMatrix
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
