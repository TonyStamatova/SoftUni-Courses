namespace P01_RawData
{
    using System.Collections.Generic;

    public class Car
    {
        public Car(params string[] parameters)
        {
            string model = parameters[0];
            this.Model = model;

            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            this.Engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];       
            this.Cargo = new Cargo(cargoWeight, cargoType);

            this.Tires = new List<Tire>(4);

            for (int i = 5; i < parameters.Length; i += 2)
            {
                double pressure = double.Parse(parameters[i]);
                int age = int.Parse(parameters[i + 1]);
                Tire newTire = new Tire(pressure, age);
                this.Tires.Add(newTire);
            }    
        }

        public string Model { get; private set; }

        public Engine Engine { get; private set; }

        public Cargo Cargo { get; private set; }

        public List<Tire> Tires { get; private set; }
    }
}
