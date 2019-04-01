using System;
using System.Collections.Generic;
using System.Numerics;

namespace _02.seizeTheFire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("#");
            int water = int.Parse(Console.ReadLine());

            decimal effort = default(decimal);
            List<int> putOutCells = new List<int>();
            BigInteger totalFire = default(BigInteger); 

            int waterNeeded = default(int);
            bool valid = false;

            for (int i = 0; i < input.Length; i++)
            {
                string[] cell = input[i].Split(" = ");
                string type = cell[0];
                waterNeeded = int.Parse(cell[1]);

                valid = CheckIfCellIsValid(type, waterNeeded);

                if (water < waterNeeded)
                {
                    continue;
                }

                if (valid)
                {
                    water -= waterNeeded;
                    effort += 0.25m * (decimal)waterNeeded;
                    putOutCells.Add(waterNeeded);
                    totalFire += (BigInteger)waterNeeded;
                }
            }

            if (putOutCells.Count == 0)
            {
                Console.WriteLine("Cells:");
                Console.WriteLine($"Effort: {effort:f2}");
                Console.WriteLine($"Total Fire: {totalFire}");
                return;
            }

            Console.WriteLine("Cells:" + Environment.NewLine + " - " 
                + string.Join(Environment.NewLine + " - ", putOutCells));

            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }

        private static bool CheckIfCellIsValid(string type, int waterNeeded)
        {
            switch (type)
            {
                case "High":
                    if (waterNeeded >= 81 && waterNeeded <= 125)
                    {
                        return true;
                    }
                    break;
                case "Medium":
                    if (waterNeeded >= 51 && waterNeeded <= 80)
                    {
                        return true;
                    }
                    break;
                case "Low":
                    if (waterNeeded >= 1 && waterNeeded <= 50)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}
