namespace _04.PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;

    using _04.PizzaCalories.Exceptions;

    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;

            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException(Exceptions.INVALID_PIZZA_NAME_EXCEPTION_MESSAGE);
                }

                this.name = value;
            }
        }

        public int NumberOfToppings
        {
            get
            {
                if (this.toppings.Count < 1 || this.toppings.Count > 10)
                {
                    throw new ArgumentException(Exceptions.INVALID_TOPPING_COUNT_EXCEPTION_MESSAGE);
                }

                return this.toppings.Count;
            }
        }

        public double TotalCalories
        {
            get
            {
                double totCalories = default(double);

                foreach (var topping in this.toppings)
                {
                    totCalories += topping.TotalCalories;
                }

                totCalories += this.Dough.TotalCalories;

                return totCalories;
            }
        }

        public Dough Dough
        {
            private get => this.dough;
            set => this.dough = value;
        }

        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);
        }
    }
}
