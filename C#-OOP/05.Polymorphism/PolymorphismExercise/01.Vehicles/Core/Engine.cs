namespace _01.Vehicles.Core
{
    using System;

    using _01.Vehicles.Models;

    public static class Engine
    {
        public static void Run()
        {
            Car car = (Car)CreateVehicle("Car");

            Truck truck = (Truck)CreateVehicle("Truck");

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandLine = Console.ReadLine().Split();
                string command = commandLine[0];
                string vehicle = commandLine[1];
                double distance = double.Parse(commandLine[2]);

                switch (command)
                {
                    case "Drive":
                        switch (vehicle)
                        {
                            case "Car":
                                Console.WriteLine(car.Drive(distance));
                                break;
                            case "Truck":
                                Console.WriteLine(truck.Drive(distance));
                                break;
                        }
                        break;

                    case "Refuel":
                        double liters = distance;
                        switch (vehicle)
                        {
                            case "Car":
                                car.Refuel(distance);
                                break;
                            case "Truck":
                                truck.Refuel(distance);
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static Vehicle CreateVehicle(string type)
        {
            string[] vehicleInfo = Console.ReadLine().Split();
            double quantity = double.Parse(vehicleInfo[1]);
            double consumtion = double.Parse(vehicleInfo[2]);

            if (type == "Car")
            {
                return new Car(quantity, consumtion);
            }
            else
            {
                return new Truck(quantity, consumtion);
            }
        }
    }
}
