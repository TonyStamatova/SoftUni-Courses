﻿namespace CarManufacturer
{
    using System;

    public class Car
    {        
        private double fuelConsumption;
        private double fuelQuantity;
        private string make;
        private string model;
        private int year;
        

        public Car()
        {
            this.FuelConsumption = 10;
            this.FuelQuantity = 200;
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
        }

        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsuption) 
            : this(make, model, year)
        {
            this.FuelConsumption = fuelConsuption;
            this.FuelQuantity = fuelQuantity;
        }

        public double FuelConsumption
        {
            get => this.fuelConsumption;
            set => this.fuelConsumption = value;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            set => this.fuelQuantity = value;
        }

        public string Make
        {
            get => this.make;
            set => this.make = value;
        }

        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public int Year
        {
            get => this.year;
            set => this.year = value;
        }
        
        public void Drive(double distance)
        {
            double fuelNeededForTrip = distance * this.FuelConsumption / 100;
            double fuelLeft = this.FuelQuantity - fuelNeededForTrip;

            if (fuelLeft > 0)
            {
                this.FuelQuantity -= fuelNeededForTrip;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return
                $"Make: {this.Make}"
                + Environment.NewLine + $"Model: {this.Model}"
                + Environment.NewLine + $"Year: {this.Year}"
                + Environment.NewLine + $"Fuel: {this.FuelQuantity:F2}L";
        }
    }
}
