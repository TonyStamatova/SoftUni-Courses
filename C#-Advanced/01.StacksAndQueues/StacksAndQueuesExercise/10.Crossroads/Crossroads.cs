namespace _10.Crossroads
{
    using System;
    using System.Collections.Generic;

    public class Crossroads
    {
        public static void Main()
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int totalPassedCars = default(int);

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input == "green")
                {
                    int greenTimeLeft = greenLight;
                    int freeWindowLeft = freeWindow;

                    Queue<char> carLetters = new Queue<char>();
                    string passingCar = string.Empty;

                    while (greenTimeLeft > 0 && cars.Count > 0)
                    {
                        passingCar = cars.Dequeue();
                        totalPassedCars++;
                        carLetters = new Queue<char>(passingCar.ToCharArray());

                        while (greenTimeLeft > 0 && carLetters.Count > 0)
                        {
                            greenTimeLeft--;
                            carLetters.Dequeue();
                        }
                    }

                    while (freeWindowLeft > 0 && carLetters.Count > 0)
                    {
                        freeWindowLeft--;
                        carLetters.Dequeue();
                    }

                    if (carLetters.Count > 0)
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{passingCar} was hit at {carLetters.Peek()}.");
                        return;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalPassedCars} total cars passed the crossroads.");
        }
    }
}
