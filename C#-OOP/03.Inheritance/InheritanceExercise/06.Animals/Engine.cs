namespace Animals
{
    using System;
    using System.Collections.Generic;

    public static class Engine
    {
        public static void Start()
        {
            List<Animal> animals = new List<Animal>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                Animal newAnimal = AnimalFactory.Create(input);

                if (newAnimal != null)
                {
                    animals.Add(newAnimal);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
