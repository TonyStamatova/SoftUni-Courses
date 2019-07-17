namespace _05.BorderControl.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using _05.BorderControl.Contracts;
    using _05.BorderControl.Models;

    public static class Engine
    {
        private static Dictionary<string, IIdentifiable> borderPassersById = new Dictionary<string, IIdentifiable>();

        private static List<IBirthable> creaturesByBirthdate = new List<IBirthable>();

        private static Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

        public static void Run()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (personInfo.Length == 4)
                {
                    Citizen citizen = CreateCitizen(personInfo);
                    RegisterWithName(citizen);
                }
                else
                {
                    Rebel rebel = CreateRebel(personInfo);
                    RegisterWithName(rebel);
                }
            }

            int foodPurchased = default(int);
            string buyerName = string.Empty;

            while ((buyerName = Console.ReadLine()) != "End")
            {
                if (buyers.ContainsKey(buyerName))
                {
                    int oldFoodQuantity = buyers[buyerName].Food;

                    buyers[buyerName].BuyFood();

                    foodPurchased += buyers[buyerName].Food - oldFoodQuantity;
                }
            }

            Console.WriteLine(foodPurchased);
        }

        private static void RegisterWithName(IBuyer buyer)
        {
            buyers.Add(buyer.Name, buyer);
        }

        private static void RegisterWithBirthdate(IBirthable creature)
        {
            creaturesByBirthdate.Add(creature);
        }

        private static void RegisterWithId(IIdentifiable passer)
        {
            borderPassersById.Add(passer.Id, passer);
        }

        private static Rebel CreateRebel(string[] personInfo)
        {
            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);
            string group = personInfo[2];
            return new Rebel(name, age, group);
        }

        private static Pet CreatePet(string[] petInfo)
        {
            string model = petInfo[0];
            string birthdate = petInfo[1];
            return new Pet(model, birthdate);
        }

        private static Robot CreateRobot(string[] robotInfo)
        {
            string model = robotInfo[0];
            string id = robotInfo[1];
            return new Robot(model, id);
        }

        private static Citizen CreateCitizen(string[] personInfo)
        {
            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);
            string id = personInfo[2];
            string birthdate = personInfo[3];
            return new Citizen(name, age, id, birthdate);
        }
    }
}
