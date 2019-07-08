namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public virtual double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;

        public double Fuel { get; private set; }

        public int HorsePower { get; private set; }

        public virtual void Drive(double kilometers)
        {
            double fuelNeeded = this.FuelConsumption * kilometers;

            if (fuelNeeded <= this.Fuel)
            {
                this.Fuel -= fuelNeeded;
            }
        }
    }
}
