namespace HealthyHeaven
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Salad
    {
        private string name;
        private HashSet<Vegetable> products;

        public Salad(string name)
        {
            this.Name = name;

            this.products = new HashSet<Vegetable>();
        }

        public string Name { get => this.name; set => this.name = value; }

        public int GetTotalCalories()
        {
            return this.products
                .Select(p => p.Calories)
                .Sum();
        }

        public int GetProductCount()
        {
            return this.products.Count();
        }

        public void Add(Vegetable product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            return $"* Salad {this.Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:"
                + Environment.NewLine + string.Join(Environment.NewLine, this.products);
        }
    }
}
