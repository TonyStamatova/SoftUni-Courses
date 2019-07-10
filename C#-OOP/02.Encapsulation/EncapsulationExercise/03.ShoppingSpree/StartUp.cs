namespace _03.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        public static void Main()
        {
            List<KeyValuePair<string, decimal>> peopleData = CreateDataCollection();
            Dictionary<string, Person> people
                = CreateDictionaryOFEntities<Person>(peopleData, "_03.ShoppingSpree.Person");

            List<KeyValuePair<string, decimal>> productData = CreateDataCollection();
            Dictionary<string, Product> products
                = CreateDictionaryOFEntities<Product>(productData, "_03.ShoppingSpree.Product");

            if (people.Count == 0 || products.Count == 0)
            {
                return;
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] purchase = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = purchase[0];
                string productName = purchase[1];

                if (!people.ContainsKey(personName) || !products.ContainsKey(productName))
                {
                    continue;
                }

                if (people[personName].Purchase(products[productName]))
                {
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.Value.GetPurchasedProducts());
            }
        }

        private static Dictionary<string, T> CreateDictionaryOFEntities<T>(
            List<KeyValuePair<string, decimal>> peopleData,
            string fullTypeName)
        {
            Type objectType = Type.GetType(fullTypeName);

            Dictionary<string, T> elements = new Dictionary<string, T>();

            bool exceptionIsThrown = false;

            foreach (var item in peopleData)
            {
                try
                {
                    string name = item.Key;
                    decimal money = item.Value;

                    T newElement = (T)Activator.CreateInstance(objectType, new object[] { name, money });
                    elements.Add(name, newElement);
                }
                catch (TargetInvocationException ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    exceptionIsThrown = true;
                    break;
                }
            }

            if (exceptionIsThrown)
            {
                return new Dictionary<string, T>();
            }

            return elements;
        }

        private static List<KeyValuePair<string, decimal>> CreateDataCollection()
        {
            string[] input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<KeyValuePair<string, decimal>> items = new List<KeyValuePair<string, decimal>>();

            foreach (var element in input)
            {
                string[] parts = element.Split("=");

                string name = parts[0];
                decimal money = decimal.Parse(parts[1]);

                items.Add(new KeyValuePair<string, decimal>(name, money));
            }

            return items;
        }
    }
}
