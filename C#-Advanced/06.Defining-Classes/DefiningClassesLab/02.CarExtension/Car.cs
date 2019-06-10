namespace CarManufacturer
{
    using System;

    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

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
