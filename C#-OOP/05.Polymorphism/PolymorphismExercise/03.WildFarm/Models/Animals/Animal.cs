namespace _03.WildFarm.Models.Animals
{
    using _03.WildFarm.Contracts;
    using _03.WildFarm.Models.Food;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract double WeightIncreaseByPiece { get; set; }

        protected abstract string[] AppropriateFoods { get; set; }

        public abstract string AskForFood();

        public void Eat(IFood food)
        {
            ValidateFood(food);
            IncreaseWeight(food);
            IncreaseFoodEaten(food);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

        protected void ValidateFood(IFood food)
        {
            string foodType = food.GetType().Name;

            if (!this.AppropriateFoods.Any(f => f == foodType))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {foodType}!");
            }
        }
        
        private void IncreaseWeight(IFood food)
        {
            this.Weight += food.Quantity * this.WeightIncreaseByPiece;
        }

        private void IncreaseFoodEaten(IFood food)
        {
            this.FoodEaten += food.Quantity;
        }
    }
}
