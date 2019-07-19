namespace _01.Vehicles.Models
{
    public class Bus : Vehicle
    {
        public Bus(double quantity, double consumtion, double tankCapacity) 
            : base(quantity, consumtion, tankCapacity)
        {
        }

        public string Drive(double distance, bool isFull)
        {
            if (!isFull)
            {
                return base.Drive(distance);
            }
                        
            this.FuelConsumption += 1.4;
            string result = base.Drive(distance);
            this.FuelConsumption -= 1.4;
            return result;
        }
    }
}
