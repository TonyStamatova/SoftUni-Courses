namespace _01.Vehicles.Models
{
    using _01.Vehicles.Validation;

    public class Truck : Vehicle
    {
        public Truck(double quantity, double consumtion, double capacity)
            : base(quantity, consumtion, capacity)
        {
        }

        public override double FuelConsumption
        {
            get => this.fuelConsumption;

            protected set => this.fuelConsumption = value + 1.6;
        }

        public override void Refuel(double fuelAmount)
        {
            Validator.ValidateFuelQuantity(fuelAmount, this.TankCapacity, this.FuelQuantity);
            base.Refuel(fuelAmount * 0.95);
        }
    }
}
