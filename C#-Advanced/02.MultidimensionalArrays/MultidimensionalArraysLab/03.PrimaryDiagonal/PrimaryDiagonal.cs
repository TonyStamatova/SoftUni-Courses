namespace _03.PrimaryDiagonal
{
    using System;
    using System.Linq;
    
    public class PrimaryDiagonal
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int sum = default(int);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        sum += matrix[i, j];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
