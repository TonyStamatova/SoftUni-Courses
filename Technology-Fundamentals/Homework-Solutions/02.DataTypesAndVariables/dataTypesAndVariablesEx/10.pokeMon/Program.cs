using System;

namespace _10.pokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int originalPokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int pokePower = originalPokePower;
            int targetsReached = default(int);

            while (pokePower >= distance)
            {
                pokePower -= distance;
                targetsReached++;

                if ((double)pokePower == 0.5 * (double)originalPokePower && exhaustionFactor > 0)
                {
                    pokePower /= exhaustionFactor;
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(targetsReached);
        }
    }
}
