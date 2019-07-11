namespace _03.ShoppingSpree.Models
{
    using System;
    using System.Collections.Generic;

    using _03.ShoppingSpree.Exceptions;

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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.nullOrEmptyNameException);
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
                    throw new ArgumentException(ExceptionMessages.negativeMoneyException);
                }

                this.money = value;
            }
        }

        public bool Purchase(Product product)
        {
            if (this.Money >= product.Cost)
            {
                AddProductToBag(product);
                this.money -= product.Cost;
                return true;
            }

            return false;
        }

        public IReadOnlyList<Product> Products
        {
            get => this.products.AsReadOnly();            
        }

        public void AddProductToBag(Product product)
        {
            this.products.Add(product);
        }
    }
}
