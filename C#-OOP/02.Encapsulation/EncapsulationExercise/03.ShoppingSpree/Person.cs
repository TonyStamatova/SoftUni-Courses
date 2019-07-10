namespace _03.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;

            this.products = new List<Product>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public bool Purchase(Product product)
        {
            if (this.Money >= product.Cost)
            {
                AddProductToBag(product);
                this.Money -= product.Cost;
                return true;
            }

            return false;
        }
        
        public void AddProductToBag(Product product)
        {
            this.products.Add(product);
        }

        public string GetPurchasedProducts()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"{this.Name} - {string.Join(", ", this.products.Select(p => p.Name))}");

            if (this.products.Count == 0)
            {
                builder.Append("Nothing bought");
            }

            return builder.ToString().TrimEnd();
        }
    }
}
