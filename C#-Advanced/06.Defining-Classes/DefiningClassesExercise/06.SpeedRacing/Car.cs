namespace _06.SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.fuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public double FuelAmount
        {
            get => this.fuelAmount;
            set => this.fuelAmount = value;
        }

        public double FuelConsumptionPerKilometer
        {
            get => this.fuelConsumptionPerKilometer;
            set => this.fuelConsumptionPerKilometer = value;
        }

        public double TravelledDistance
        {
            get => this.travelledDistance;
            set => this.travelledDistance = value;
        }

        public void Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumptionPerKilometer;

            if (fuelNeeded <= this.fuelAmount)
            {
                this.FuelAmount -= fuelNeeded;
                this.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }            
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
        }
    }
}
