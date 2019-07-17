namespace _05.BorderControl.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using _05.BorderControl.Contracts;
    using _05.BorderControl.Models;

    public static class Engine
    {
        private static List<IIdentifiable> borderPassersById = new List<IIdentifiable>();
        private static List<IBirthable> creaturesByBirthdate = new List<IBirthable>();
        
        public static void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] passerInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = passerInfo[0];

                try
                {
                    switch (type)
                    {
                        case "Citizen":
                            Citizen citizen = CreateCitizen(passerInfo.Skip(1).ToArray());
                            RegisterWithId(citizen);
                            RegisterWithBirthdate(citizen);
                            break;
                        case "Robot":
                            Robot robot = CreateRobot(passerInfo.Skip(1).ToArray());
                            RegisterWithId(robot);
                            break;
                        case "Pet":
                            Pet pet = CreatePet(passerInfo.Skip(1).ToArray());
                            RegisterWithBirthdate(pet);
                            break;
                    }
                }
                catch (Exception)
                {
                    continue;
                }                  
            }

            string yearOfBirth = Console.ReadLine();

            Console.WriteLine(
                string.Join(
                Environment.NewLine,
                creaturesByBirthdate
                    .Select(c => c.Birthdate)
                    .Where(p => p.EndsWith(yearOfBirth))));
        }

        private static void RegisterWithBirthdate(IBirthable creature)
        {
            creaturesByBirthdate.Add(creature);
        }

        private static void RegisterWithId(IIdentifiable passer)
        {
            borderPassersById.Add(passer);
        }

        private static Pet CreatePet(string[] passerInfo)
        {
            string model = passerInfo[0];
            string birthdate = passerInfo[1];
            return new Pet(model, birthdate);
        }

        private static Robot CreateRobot(string[] passerInfo)
        {
            string model = passerInfo[0];
            string id = passerInfo[1];
            return new Robot(model, id);
        }

        private static Citizen CreateCitizen(string[] passerInfo)
        {
            string name = passerInfo[0];
            int age = int.Parse(passerInfo[1]);
            string id = passerInfo[2];
            string birthdate = passerInfo[3];
            return new Citizen(name, age, id, birthdate);
        }
    }
}
