using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.vehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Vehicle> vehicles = new List<Vehicle>();

            while (input != "End")
            {
                string[] toCatalogue = input.Split();
                string type = toCatalogue[0];
                string model = toCatalogue[1];
                string color = toCatalogue[2];
                int horsepower = int.Parse(toCatalogue[3]);
                Vehicle newVehicle = new Vehicle(type, model, color, horsepower);
                vehicles.Add(newVehicle);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Close the Catalogue")
            {
                Vehicle vehicle = vehicles.Find(x => x.Model == input);
                Console.WriteLine(vehicle);

                input = Console.ReadLine();
            }

            List<Vehicle> cars = vehicles.Where(x => x.Type == "Car").ToList();
            List<Vehicle> trucks = vehicles.Where(x => x.Type == "Truck").ToList();

            Console.WriteLine($"Cars have average horsepower of: {GetAverageHorsepower(cars):f2}."
            + Environment.NewLine + $"Trucks have average horsepower of: {GetAverageHorsepower(trucks):f2}.");
        }

        private static double GetAverageHorsepower(List<Vehicle> vehicles)
        {
            if (vehicles.Count == 0)
            {
                return 0;
            }

            return vehicles.Select(x => x.Horsepower).Sum() / (double)vehicles.Count;
        }
    }

    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

        public Vehicle(string type, string model, string color, int horsepower)
        {
            if (type == "car")
            {
                this.Type = "Car";
            }
            else
            {
                this.Type = "Truck";
            }
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsepower;
        }

        public override string ToString()
        {
            return $"Type: {this.Type}"
                + Environment.NewLine + $"Model: {this.Model}"
                + Environment.NewLine + $"Color: {this.Color}"
                + Environment.NewLine + $"Horsepower: {this.Horsepower}";
        }
    }
}
