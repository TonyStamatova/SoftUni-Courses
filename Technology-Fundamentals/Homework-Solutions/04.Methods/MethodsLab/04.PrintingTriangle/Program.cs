using System;

namespace printingTriangles
{
    class Program
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            PrintTriangle(num);
        }

        private static void PrintTriangle(int n)
        {
            for (int i = 1; i < 2 * n; i++)
            {
                if (i <= n)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write(j + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    for (int j = 1; j <= 2 * n - i; j++)
                    {
                        Console.Write(j + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
