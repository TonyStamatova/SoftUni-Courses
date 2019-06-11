namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Tire[]> tireSets = CollectTireInfo();
            List<Engine> engines = CollectEngineInfo();

            List<Car> cars = CollectCarInfo(engines, tireSets);

            cars = cars
                .Where(x => x.Year >= 2017
                && x.Engine.HorsePower > 330
                && x.Tires.Select(y => y.Pressure).Sum() > 9
                && x.Tires.Select(y => y.Pressure).Sum() < 10)
                .ToList();

            cars.ForEach(x => x.Drive(20));

            cars.ForEach(x => Console.WriteLine(x.WhoAmI()));
        }

        private static List<Car> CollectCarInfo(List<Engine> engines, List<Tire[]> tireSets)
        {
            List<Car> cars = new List<Car>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = input.Split();

                Car newCar = new Car(
                    carInfo[0],
                    carInfo[1],
                    int.Parse(carInfo[2]),
                    double.Parse(carInfo[3]),
                    double.Parse(carInfo[4]),
                    engines.ElementAt(int.Parse(carInfo[5])),
                    tireSets.ElementAt(int.Parse(carInfo[6]))
                    );

                cars.Add(newCar);
            }

            return cars;
        }

        public static List<Engine> CollectEngineInfo()
        {
            List<Engine> engines = new List<Engine>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = input.Split();

                Engine newEngine = new Engine(int.Parse(engineInfo[0]), double.Parse(engineInfo[1]));

                engines.Add(newEngine);
            }

            return engines;
        }

        public static List<Tire[]> CollectTireInfo()
        {
            List<Tire[]> tireSets = new List<Tire[]>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "No more tires")
            {
                Queue<string> tiresInfo = new Queue<string>(input.Split());
                Tire[] newTireSet = new Tire[4];

                for (int i = 0; i < newTireSet.Length; i++)
                {
                    Tire newTire = new Tire(int.Parse(tiresInfo.Dequeue()), double.Parse(tiresInfo.Dequeue()));
                    newTireSet[i] = newTire;
                }

                tireSets.Add(newTireSet);
            }

            return tireSets;
        }
    }
}
