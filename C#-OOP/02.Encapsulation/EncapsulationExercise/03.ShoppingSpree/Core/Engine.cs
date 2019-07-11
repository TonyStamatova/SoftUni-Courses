namespace _03.ShoppingSpree.Core
{
    using _03.ShoppingSpree.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Engine
    {
        private static List<Person> people = new List<Person>();
        private static List<Product> products = new List<Product>();

        public static void Start()
        {
            try
            {
                FillPersonCollection();
                FillProductCollection();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            MakePurchases();

            foreach (var person in people)
            {
                PrintPurchases(person);
            }
        }

        private static void PrintPurchases(Person person)
        {
            if (person.Products.Count == 0)
            {
                Console.Write($"{person.Name} - Nothing bought");
                return;
            }

            Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Select(p => p.Name))}");
        }

        private static void MakePurchases()
        {
            string purchaseInput = string.Empty;

            while ((purchaseInput = Console.ReadLine()) != "END")
            {
                string[] purchase = purchaseInput
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = purchase[0];
                string productName = purchase[1];

                if (people
                    .First(p => p.Name == personName)
                    .Purchase(products.First(p => p.Name == productName)))
                {
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
            }
        }

        private static void FillProductCollection()
        {
            string[] productInput = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in productInput)
            {
                string[] productInfo = item.Split("=");
                string name = productInfo[0];
                decimal money = decimal.Parse(productInfo[1]);

                try
                {
                    products.Add(new Product(name, money));
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        private static void FillPersonCollection()
        {
            string[] personInput = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in personInput)
            {
                string[] personInfo = item.Split("=");
                string name = personInfo[0];
                decimal money = decimal.Parse(personInfo[1]);

                try
                {
                    people.Add(new Person(name, money));
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }
    }
}
