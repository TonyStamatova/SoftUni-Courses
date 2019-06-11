namespace CarManufacturer
{
    using System;

    public class Car
    {
        private Engine engine;
        private double fuelConsumption;
        private double fuelQuantity;
        private string make;
        private string model;
        private Tire[] tires;
        private int year;
        

        public Car()
        {
            this.FuelConsumption = 10;
            this.FuelQuantity = 200;
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
        }

        public Car(
            string make, 
            string model, 
            int year) 
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(
            string make, 
            string model, 
            int year, 
            double fuelQuantity, 
            double fuelConsuption) 
            : this(make, model, year)
        {
            this.FuelConsumption = fuelConsuption;
            this.FuelQuantity = fuelQuantity;
        }

        public Car(
            string make, 
            string model, 
            int year, 
            double fuelQuantity, 
            double fuelConsuption,
            Engine engine,
            Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsuption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public Engine Engine { get; set; }

        public double FuelConsumption { get; set; }

        public double FuelQuantity { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public Tire[] Tires { get; set; }

        public int Year { get; set; }   
        
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
                + Environment.NewLine + $"HorsePowers: {this.Engine.HorsePower}"
                + Environment.NewLine + $"FuelQuantity: {this.FuelQuantity}";
        }
    }
}
