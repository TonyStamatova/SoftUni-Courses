namespace _06.SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split();
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumption = double.Parse(carInfo[2]);

                cars.Add(model, new Car(model, fuelAmount, fuelConsumption));
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] drivingInfo = input.Split();
                string model = drivingInfo[1];
                double distance = double.Parse(drivingInfo[2]);

                Car carToDrive = cars[model];

                carToDrive.Drive(distance);
            }

            List<Car> result = cars
                .Select(c => c.Value)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
