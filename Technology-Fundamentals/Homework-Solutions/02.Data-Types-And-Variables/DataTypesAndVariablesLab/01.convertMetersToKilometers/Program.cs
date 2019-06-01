using System;

namespace _01.convertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            double distance = double.Parse(Console.ReadLine());

            distance /= 1000;
            Console.WriteLine($"{distance:f2}");
        }
    }
}
