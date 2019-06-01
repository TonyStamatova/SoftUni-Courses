using System;

namespace _08.beerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string model = string.Empty;
            double radius = default(double);
            int height = default(int);

            string biggestKeg = string.Empty;
            double newVolume = default(double);
            double lastVolume = default(double);

            for (int i = 0; i < n; i++)
            {
                model = Console.ReadLine();
                radius = double.Parse(Console.ReadLine());
                height = int.Parse(Console.ReadLine());

                newVolume = Math.PI * radius * radius * height;

                if (newVolume > lastVolume)
                {
                    biggestKeg = model;
                    lastVolume = newVolume;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}
