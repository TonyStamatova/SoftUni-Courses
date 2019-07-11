namespace _04.PizzaCalories.Models
{
    using System;
    using System.Globalization;
    using System.Text;

    using _04.PizzaCalories.Exceptions;

    public class Dough
    {
        private const double WHITE_FLOUR_MODIFIER = 1.5;
        private const double WHOLEGRAIN_FLOUR_MODIFIER = 1.0;

        private const double CRISPY_BAKED_MODIFIER = 0.9;
        private const double CHEWY_BAKED_MODIFIER = 1.1;
        private const double HOMEMADE_BAKED_MODIFIER = 1.0;

        private string flourType;
        private string bakingTechnique;

        private int weight;
        private double caloriesPerGram = 2;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.flourType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(flourType.ToLower());
            this.bakingTechnique = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(bakingTechnique.ToLower());
            this.Weight = weight;

            this.CaloriesPerGram = this.caloriesPerGram;
        }

        private int Weight
        {
            get => this.weight;

            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(Exceptions.INVALID_DOUGH_WEIGHT_EXCEPTION_MESSAGE);
                }

                this.weight = value;
            }
        }

        private double CaloriesPerGram
        {
            get => this.caloriesPerGram;

            set
            {
                switch (this.flourType)
                {
                    case "White":
                        this.caloriesPerGram *= WHITE_FLOUR_MODIFIER;
                        break;
                    case "Wholegrain":
                        this.caloriesPerGram *= WHOLEGRAIN_FLOUR_MODIFIER;
                        break;
                    default:
                        throw new ArgumentException(Exceptions.INVALID_DOUGH_TYPE_EXCEPTION_MESSAGE);
                }

                switch (this.bakingTechnique)
                {
                    case "Crispy":
                        this.caloriesPerGram *= CRISPY_BAKED_MODIFIER;
                        break;
                    case "Chewy":
                        this.caloriesPerGram *= CHEWY_BAKED_MODIFIER;
                        break;
                    case "Homemade":
                        this.caloriesPerGram *= HOMEMADE_BAKED_MODIFIER;
                        break;
                    default:
                        throw new ArgumentException(Exceptions.INVALID_DOUGH_TYPE_EXCEPTION_MESSAGE);
                }
            }
        }

        public double TotalCalories =>  this.CaloriesPerGram * this.Weight;        
    }
}
