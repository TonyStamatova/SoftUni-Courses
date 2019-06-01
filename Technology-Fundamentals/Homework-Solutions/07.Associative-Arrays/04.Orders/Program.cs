using System;
using System.Collections.Generic;

namespace _04.orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            string input = Console.ReadLine();

            while (input != "buy")
            {
                string[] newInput = input.Split();
                string name = newInput[0];
                double price = double.Parse(newInput[1]);
                int quantity = int.Parse(newInput[2]);
                Product temp = new Product(name, price, quantity);

                if (!products.ContainsKey(name))
                {
                    products.Add(name, temp);
                }
                else
                {
                    products[name].Quantity += quantity;
                    products[name].Price = price;
                }

                input = Console.ReadLine();
            }

            foreach (var item in products)
            {
                double totPrice = item.Value.Price * item.Value.Quantity;
                Console.WriteLine($"{item.Value.Name} -> {totPrice:f2}");
            }
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
}
