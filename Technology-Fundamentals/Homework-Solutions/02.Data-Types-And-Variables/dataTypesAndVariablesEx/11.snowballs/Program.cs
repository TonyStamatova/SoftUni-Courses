using System;
using System.Numerics;

namespace _11.snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            double snowballCount = double.Parse(Console.ReadLine());

            double snow = default(double);
            double time = default(double);
            int quality = default(int);

            BigInteger snowDividedByTime = default(BigInteger);
            BigInteger currentValue = default(BigInteger);
            BigInteger bestValue = default(BigInteger);
            double bestSnow = default(double);
            double bestTime = default(double);
            double bestQuality = default(double);

            for (double i = 0; i < snowballCount; i++)
            {
                snow = double.Parse(Console.ReadLine());
                time = double.Parse(Console.ReadLine());
                quality = int.Parse(Console.ReadLine());

                snowDividedByTime = (BigInteger)(snow / time);
                currentValue = BigInteger.Pow(snowDividedByTime, quality);

                if (currentValue > bestValue)
                {
                    bestValue = currentValue;

                    bestSnow = snow;
                    bestTime = time;
                    bestQuality = quality;
                }
            }

            Console.WriteLine($"{bestSnow} : {bestTime} = {bestValue} ({bestQuality})");
        }
    }
}
