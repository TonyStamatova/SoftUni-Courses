namespace _03.ShoppingSpree.Models
{
    using System;

    using _03.ShoppingSpree.Exceptions;

    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
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

        public decimal Cost
        {
            get => this.cost;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.negativeMoneyException);
                }

                this.cost = value;
            }
        }
    }
}
