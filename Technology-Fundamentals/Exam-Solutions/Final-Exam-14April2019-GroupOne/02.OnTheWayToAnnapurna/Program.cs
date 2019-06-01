using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OnTheWayToAnnapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> stores = new Dictionary<string, List<string>>();

            while (input != "END")
            {
                string[] data = input.Split("->");
                string command = data[0];
                string store = data[1];

                switch (command)
                {
                    case "Add":

                        if (!stores.ContainsKey(store))
                        {
                            stores.Add(store, new List<string>());
                        }

                        string[] newItems = data[2].Split(",");

                        for (int i = 0; i < newItems.Length; i++)
                        {
                            stores[store].Add(newItems[i]);
                        }

                        break;

                    case "Remove":
                        stores.Remove(store);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Stores list:");

            foreach (var store in stores.OrderByDescending(x => x.Value.Count)
                .ThenByDescending(x => x.Key))
            {
                Console.WriteLine(store.Key);

                foreach (var item in store.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }
    }
}
