namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class AnimalFactory
    {
        public static Animal Create(string typeAsString)
        {
            Type animalType = Type.GetType("Animals.AnimalTypes." + typeAsString);

            string[] animalInfo = Console.ReadLine()
                .Split();

            string name = animalInfo[0];

            int age = int.Parse(animalInfo[1]);

            string gender = animalInfo[2];

            try
            {
                var animal = (Animal)Activator.CreateInstance(animalType, new object[] { name, age, gender });

                return animal;
            }
            catch 
            {
                Console.WriteLine("Invalid input!");
                return null;
            }
        }
    }
}
