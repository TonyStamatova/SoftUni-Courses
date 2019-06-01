namespace _06.AutoRepairAndService
{
    using System;
    using System.Collections.Generic;

    public class AutoRepairAndService
    {
        public static void Main(string[] args)
        {
            Queue<string> waitingVehicles = new Queue<string>(Console.ReadLine()
                .Split());

            string command = Console.ReadLine();

            Stack<string> served = new Stack<string>();

            while (command != "End")
            {
                switch (command)
                {
                    case "Service":

                        if (waitingVehicles.Count > 0)
                        {
                            string car = waitingVehicles.Dequeue();
                            served.Push(car);
                            Console.WriteLine($"Vehicle {car} got served.");
                        }          
                        
                        break;

                    case "History":
                        Console.WriteLine($"{string.Join(", ", served)}");
                        break;

                    default:
                        string[] request = command.Split("-");
                        string carName = request[1];

                        if (waitingVehicles.Contains(carName))
                        {
                            Console.WriteLine("Still waiting for service.");
                        }
                        else
                        {
                            Console.WriteLine("Served.");
                        }

                        break;
                }

                command = Console.ReadLine();
            }

            if (waitingVehicles.Count > 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", waitingVehicles)}");
            }

            Console.WriteLine($"Served vehicles: {string.Join(", ", served)}");
        }
    }
}
