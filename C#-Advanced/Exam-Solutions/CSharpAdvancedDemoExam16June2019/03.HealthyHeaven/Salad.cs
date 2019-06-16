namespace HealthyHeaven
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Salad
    {
        private string name;
        private List<Vegetable> products;

        public Salad(string name)
        {
            this.Name = name;

            this.Products = new List<Vegetable>();
        }

        public string Name { get => name; set => name = value; }

        private List<Vegetable> Products { get => products; set => products = value; }

        public int GetTotalCalories()
        {
            return this.Products.Select(p => p.Calories).Sum();
        }

        public int GetProductCount()
        {
            return this.Products.Count();
        }

        public void Add(Vegetable product)
        {
            this.Products.Add(product);
        }

        public override string ToString()
        {
            return $"* Salad {this.Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:"
                + Environment.NewLine + string.Join(Environment.NewLine, this.Products);
        }
    }
}
