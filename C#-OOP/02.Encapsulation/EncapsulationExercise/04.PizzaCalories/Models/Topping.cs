namespace _04.PizzaCalories.Models
{
    using System;
    using System.Globalization;
    using _04.PizzaCalories.Exceptions;

    public class Topping
    {
        private const double MEAT_MODIFIER = 1.2;
        private const double VEGGIES_MODIFIER = 0.8;
        private const double CHEESE_MODIFIER = 1.1;
        private const double SAUCE_MODIFIER = 0.9;
        
        private string type;

        private int weight;
        private double caloriesPerGram = 2;

        public Topping(string type, int weight)
        {
            this.type = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(type.ToLower()); 
            this.CaloriesPerGram = this.caloriesPerGram;

            this.Weight = weight;
        }

        private int Weight
        {
            get => this.weight;

            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format(Exceptions.INVALID_TOPPING_WEIGHT_EXCEPTION_MESSAGE, this.type));
                }

                this.weight = value;
            }
        }

        private double CaloriesPerGram
        {
            get => this.caloriesPerGram;

            set
            {
                switch (this.type)
                {
                    case "Meat":
                        this.caloriesPerGram *= MEAT_MODIFIER;
                        break;
                    case "Veggies":
                        this.caloriesPerGram *= VEGGIES_MODIFIER;
                        break;
                    case "Cheese":
                        this.caloriesPerGram *= CHEESE_MODIFIER;
                        break;
                    case "Sauce":
                        this.caloriesPerGram *= SAUCE_MODIFIER;
                        break;
                    default:
                        throw new ArgumentException(string.Format(Exceptions.INVALID_TOPPING_TYPE_EXCEPTION_MESSAGE, this.type));
                }
            }
        }

        public double TotalCalories => this.CaloriesPerGram * this.Weight;
    }
}
