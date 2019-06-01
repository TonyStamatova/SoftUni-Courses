namespace _07.PascalTriangle
{
    using System;

    public class PascalTriangle
    {
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] triangle = new long[rows][];
            long[] previousRow = new long[0];

            for (int i = 0; i < rows; i++)
            {
                long[] currentRow = new long[i + 1];
                currentRow[0] = 1;

                for (int j = 1; j < currentRow.Length - 1; j++)
                {
                    currentRow[j] = CalculateElement(j, triangle[i - 1]);
                }

                currentRow[currentRow.Length - 1] = 1;
                triangle[i] = currentRow;
            }

            foreach (var row in triangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        public static long CalculateElement(int position, long[] previousRow)
        {
            long result = previousRow[position - 1] + previousRow[position];
            return result;
        }
    }
}
