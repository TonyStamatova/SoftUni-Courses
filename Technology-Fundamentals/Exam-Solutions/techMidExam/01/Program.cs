using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            // •	On the 1st line, you are going to receive the days of the adventure – 
            //an integer in the range[1…100]
            //•	On the 2nd line – the count of players – an integer in the range[0 – 1000]
            //•	On the 3rd line -the group’s energy – a real number in the range[1 - 50000]
            //•	On the 4th line – water per day for one person – a real number[0.00 – 1000.00]
            //•	On the 5th line – food per day for one person – a real number[0.00 – 1000.00]
            //•	On the next n lines – one for each of the days – the amount of energy loss– 
            //a real number in the range[0.00 - 1000]
            //•	You will always have enough food and water.

            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double waterPerPersonPerDay = double.Parse(Console.ReadLine());
            double foodPerPersonPerDay = double.Parse(Console.ReadLine());

            double totWater = days * players * waterPerPersonPerDay;
            double totFood = days * players * foodPerPersonPerDay;

            for (int i = 1; i <= days; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());
                energy -= energyLoss;

                if (energy <= 0)
                {
                    break;
                }

                if (i % 2 == 0)
                {
                    energy *= 1.05;
                    totWater -= 0.30 * totWater;
                }                

                if (i % 3 == 0)
                {
                    totFood -= totFood / players;
                    energy *= 1.10;
                }
            }

            if (energy > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energy:f2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totFood:f2} food and {totWater:f2} water.");
            }
            
        }
    }
}
