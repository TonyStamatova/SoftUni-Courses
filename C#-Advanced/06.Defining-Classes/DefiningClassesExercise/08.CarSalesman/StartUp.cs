namespace _08.CarSalesman
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfEngines = int.Parse(Console.ReadLine());

            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                Queue<string> engineParams = new Queue<string>(
                    Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries));

                string model = next(engineParams);
                int power = int.Parse(next(engineParams));

                Engine newEngine = new Engine(model, power);

                while (engineParams.Count > 0)
                {
                    int displacement = default(int);
                    string parameter = next(engineParams);

                    if (int.TryParse(parameter, out displacement))
                    {
                        newEngine.Displacement = displacement;
                    }
                    else
                    {
                        newEngine.Efficiency = parameter;                        
                    }
                }

                engines.Add(newEngine.Model, newEngine);
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                Queue<string> carParams = new Queue<string>(
                    Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries));

                string model = next(carParams);
                Engine engine = engines[next(carParams)];

                Car newCar = new Car(model, engine);

                while (carParams.Count > 0)
                {
                    int weight = default(int);
                    string parameter = next(carParams);

                    if (int.TryParse(parameter, out weight))
                    {
                        newCar.Weight = weight;
                    }
                    else
                    {
                        newCar.Color = parameter;
                    }
                }

                Console.WriteLine(newCar);
            }
        }
                
        static Func<Queue<string>, string> next = q => q.Dequeue();
    }
}
