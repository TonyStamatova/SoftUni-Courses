namespace _07.TrafficJam
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int passingCars = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            Queue<string> carsOnRedLigth = new Queue<string>();
            int totalCount = default(int);

            while (input != "end")
            {
                if (input == "green")
                {
                    passingCars = Math.Min(passingCars, carsOnRedLigth.Count);
                    for (int i = 0; i < passingCars; i++)
                    {
                        Console.WriteLine($"{carsOnRedLigth.Dequeue()} passed!");
                        totalCount++;
                    }
                }
                else
                {
                    carsOnRedLigth.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{totalCount} cars passed the crossroads.");
        }
    }
}
