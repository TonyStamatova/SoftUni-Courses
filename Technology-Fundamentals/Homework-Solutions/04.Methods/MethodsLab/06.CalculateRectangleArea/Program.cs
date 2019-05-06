using System;

namespace _06.calculateRectangleArea
{
    class Program
    {
        public static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double area = CalculateRectArea(width, height);

            Console.WriteLine(area);
        }

        private static double CalculateRectArea(double a, double b)
        {
            return a * b;
        }
    }
}
