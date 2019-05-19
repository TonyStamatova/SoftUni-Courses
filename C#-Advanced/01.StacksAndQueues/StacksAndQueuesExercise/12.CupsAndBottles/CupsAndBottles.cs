namespace _12.CupsAndBottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CupsAndBottles
    {
        public static void Main()
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            Stack<int> bottles = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            int wastedWater = default(int);

            while (cups.Count > 0)
            {
                int currentCup = cups.Peek();
                int currentBottle = default(int);

                while (currentCup > 0)
                {
                    if (bottles.Count == 0)
                    {
                        Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                        PrintWastedWater(wastedWater);
                        return;
                    }

                    currentBottle = bottles.Pop();

                    if (currentBottle >= currentCup)
                    {
                        currentBottle -= currentCup;
                        currentCup = 0;
                    }
                    else
                    {
                        currentCup -= currentBottle;
                    }
                }

                cups.Dequeue();
                wastedWater += currentBottle;
            }

            Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            PrintWastedWater(wastedWater);
        }

        private static void PrintWastedWater(int wastedWater)
        {
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
