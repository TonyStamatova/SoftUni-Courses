﻿namespace _01.Vehicles.Models
{
    using _01.Vehicles.Contracts;
    using _01.Vehicles.Validation;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        protected double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double quantity, double consumtion, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;

            this.FuelQuantity = quantity;
            this.FuelConsumption = consumtion;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;

            private set
            {
                if (value <= this.TankCapacity)
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption { get; protected set; }

        public double TankCapacity { get; protected set; }

        public string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (fuelNeeded <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double fuelAmount)
        {
            Validator.ValidateFuelQuantity(fuelAmount, this.TankCapacity, this.FuelQuantity);
            this.FuelQuantity += fuelAmount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
