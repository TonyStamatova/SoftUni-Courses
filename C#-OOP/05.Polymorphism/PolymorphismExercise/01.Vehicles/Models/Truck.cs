namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double quantity, double consumtion)
            : base(quantity, consumtion)
        {
        }

        public override double FuelConsumption
        {
            get => this.fuelConsumption;

            protected set => this.fuelConsumption = value + 1.6;
        }

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount * 0.95);
        }
    }
}
