using System;

namespace _07.mathPower
{
    class Program
    {
        public static void Main()
        {
            double num = double.Parse(Console.ReadLine());
            double pow = double.Parse(Console.ReadLine());

            Console.WriteLine(CalculatePower(num, pow));
        }

        private static double CalculatePower(double number, double power)
        {
            return Math.Pow(number, power);
        }
    }
}
