namespace _01.Vehicles.Models
{
    using _01.Vehicles.Contracts;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        protected double fuelConsumption;

        public Vehicle(double quantity, double consumtion)
        {
            this.FuelQuantity = quantity;
            this.FuelConsumption = consumtion;
        }

        public double FuelQuantity { get; private set; }

        public abstract double FuelConsumption { get; protected set; }

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
            this.FuelQuantity += fuelAmount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
