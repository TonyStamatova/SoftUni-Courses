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

            Bus bus = (Bus)CreateVehicle("Bus");

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandLine = Console.ReadLine().Split();
                string command = commandLine[0];
                string vehicle = commandLine[1];
                double distance = double.Parse(commandLine[2]);

                try
                {
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
                                case "Bus":
                                    Console.WriteLine(bus.Drive(distance, true));
                                    break;
                            }
                            break;

                        case "DriveEmpty":
                            Console.WriteLine(bus.Drive(distance, false));
                            break;

                        case "Refuel":
                            double liters = distance;
                            switch (vehicle)
                            {
                                case "Car":
                                    car.Refuel(liters);
                                    break;
                                case "Truck":
                                    truck.Refuel(liters);
                                    break;
                                case "Bus":
                                    bus.Refuel(liters);
                                    break;
                            }
                            break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }                
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static Vehicle CreateVehicle(string type)
        {
            string[] vehicleInfo = Console.ReadLine().Split();
            double quantity = double.Parse(vehicleInfo[1]);
            double consumtion = double.Parse(vehicleInfo[2]);
            double capacity = double.Parse(vehicleInfo[3]);

            if (type == "Car")
            {
                return new Car(quantity, consumtion, capacity);
            }
            else if (type == "Truck")
            {
                return new Truck(quantity, consumtion, capacity);
            }
            else
            {
                return new Bus(quantity, consumtion, capacity);
            }
        }
    }
}
