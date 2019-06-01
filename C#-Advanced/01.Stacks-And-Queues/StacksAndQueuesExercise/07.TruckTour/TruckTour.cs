namespace _07.TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TruckTour
    {
        public static void Main()
        {
            int numberOfPumps = int.Parse(Console.ReadLine());

            Queue<Pump> pumpsByInsertion = new Queue<Pump>();

            for (int i = 0; i < numberOfPumps; i++)
            {
                int[] pumpData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                Pump newPump = new Pump(pumpData[0], pumpData[1]);
                pumpsByInsertion.Enqueue(newPump);
            }

            for (int i = 0; i < numberOfPumps; i++)
            {
                Queue<Pump> tempQueue = new Queue<Pump>(pumpsByInsertion.ToArray());
                int petrolInTank = 0;

                while (tempQueue.Count > 0)
                {
                    Pump current = tempQueue.Dequeue();
                    petrolInTank += current.PetrolAmount;

                    if (current.DistanceTillNextPump > petrolInTank)
                    {
                        break;
                    }

                    petrolInTank -= current.DistanceTillNextPump;
                }

                if (tempQueue.Count == 0)
                {
                    Console.WriteLine(i);
                    break;
                }
                else
                {
                    pumpsByInsertion.Enqueue(pumpsByInsertion.Dequeue());
                }
            }

        }
    }

    public class Pump
    {
        public Pump(int petrol, int distance)
        {
            this.PetrolAmount = petrol;
            this.DistanceTillNextPump = distance;
        }

        public int PetrolAmount { get; set; }

        public int DistanceTillNextPump { get; set; }
    }
}
