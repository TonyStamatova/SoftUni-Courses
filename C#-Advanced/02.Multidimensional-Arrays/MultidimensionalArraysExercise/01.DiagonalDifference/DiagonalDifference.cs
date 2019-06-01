namespace _01.DiagonalDifference
{
    using System;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            int primarySum = default(int);
            int secondarySum = default(int);

            for (int i = 0; i < size; i++)
            {
                int[] row = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = row[j];

                    if (i == j)
                    {
                        primarySum += matrix[i, j];
                    }

                    if ((i + j) == (size - 1))
                    {
                        secondarySum += matrix[i, j];
                    }
                }
            }

            int diff = Math.Abs(primarySum - secondarySum);

            Console.WriteLine(diff);
        }
    }
}
