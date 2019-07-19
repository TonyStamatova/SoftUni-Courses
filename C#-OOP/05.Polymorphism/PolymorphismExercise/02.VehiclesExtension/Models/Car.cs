namespace _01.Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double quantity, double consumtion,double capacity) 
            : base(quantity, consumtion, capacity)
        {
        }

        public override double FuelConsumption
        {
            get => this.fuelConsumption;

            protected set => this.fuelConsumption = value + 0.9;
        }
    }
}
