namespace _03.WildFarm.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using _03.WildFarm.Contracts;
    using _03.WildFarm.Models.Animals.Birds;
    using _03.WildFarm.Models.Animals.Mammals;
    using _03.WildFarm.Models.Animals.Mammals.Feline;
    using _03.WildFarm.Models.Food;

    public static class Engine
    {
        private static List<IAnimal> animals = new List<IAnimal>();

        public static void Run()
        {
            ProcessEachAnimal();
            PrintAnimalsInfo();
        }

        private static void PrintAnimalsInfo()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static void ProcessEachAnimal()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                IAnimal animal = CreateNewAnimal(input.Split());

                animals.Add(animal);

                Console.WriteLine(animal.AskForFood());

                IFood food = CreateNewFood(Console.ReadLine().Split());

                try
                {
                    animal.Eat(food);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }

        private static IFood CreateNewFood(string[] foodInfo)
        {
            string type = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            Food newFood = null;

            switch (type)
            {
                case "Fruit":
                    newFood = new Fruit(quantity);
                    break;
                case "Meat":
                    newFood = new Meat(quantity);
                    break;
                case "Vegetable":
                    newFood = new Vegetable(quantity);
                    break;
                case "Seeds":
                    newFood = new Seeds(quantity);
                    break;
            }

            return newFood;
        }

        private static IAnimal CreateNewAnimal(string[] animalInfo)
        {
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            switch (type)
            {
                case "Hen":
                case "Owl":
                    double wingSize = double.Parse(animalInfo[3]);
                    return CreateBird(type, name, weight, wingSize);

                case "Dog":
                case "Mouse":
                case "Cat":
                case "Tiger":
                    string livingRegion = animalInfo[3];
                    return CreateMammal(type, name, weight, livingRegion, animalInfo.Skip(4).ToArray());
            }

            return null;
        }

        private static IMammal CreateMammal(
            string type,
            string name,
            double weight,
            string livingRegion,
            string[] remainingArgs)
        {
            switch (type)
            {
                case "Dog":
                    return new Dog(name, weight, livingRegion);
                case "Mouse":
                    return new Mouse(name, weight, livingRegion);

                case "Cat":
                case "Tiger":
                    string breed = remainingArgs[0];
                    return CreateFeline(type, name, weight, livingRegion, breed);
            }

            return null;
        }

        private static IFeline CreateFeline(string type, string name, double weight, string livingRegion, string breed)
        {
            switch (type)
            {
                case "Cat":
                    return new Cat(name, weight, livingRegion, breed);
                case "Tiger":
                    return new Tiger(name, weight, livingRegion, breed);
            }

            return null;
        }

        private static IBird CreateBird(string type, string name, double weight, double wingSize)
        {
            switch (type)
            {
                case "Hen":
                    return new Hen(name, weight, wingSize);
                case "Owl":
                    return new Owl(name, weight, wingSize);
            }

            return null;
        }
    }
}
