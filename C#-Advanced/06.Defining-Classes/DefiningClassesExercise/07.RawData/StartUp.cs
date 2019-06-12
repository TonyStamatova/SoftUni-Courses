namespace _07.RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                Car newCar = new Car(
                    new Queue<string>(
                        Console.ReadLine()
                        .Split()));

                cars.Add(newCar);
            }

            string typeOfCargo = Console.ReadLine();

            switch (typeOfCargo)
            {
                case "fragile":
                    cars = cars.Where(c => c.Cargo.Type == typeOfCargo && c.Tires.Any(t => t.Pressure < 1)).ToList();
                    break;
                case "flamable":
                    cars = cars.Where(c => c.Cargo.Type == typeOfCargo && c.Engine.Power > 250).ToList();
                    break;
            }

            cars.ForEach(c => Console.WriteLine(c.Model));
        }
    }
}
