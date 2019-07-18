namespace _10.ExplicitInterfaces.Core
{
    using System;
    using _10.ExplicitInterfaces.Contracts;
    using _10.ExplicitInterfaces.Models;

    public static class Engine
    {
        public static void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] citizenInfo = input.Split();
                string name = citizenInfo[0];
                string country = citizenInfo[1];
                int age = int.Parse(citizenInfo[2]);

                Citizen citizen = new Citizen(name, country, age);

                IPerson person = (IPerson)citizen;
                Console.WriteLine(person.GetName());

                IResident resident = (IResident)citizen;
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
