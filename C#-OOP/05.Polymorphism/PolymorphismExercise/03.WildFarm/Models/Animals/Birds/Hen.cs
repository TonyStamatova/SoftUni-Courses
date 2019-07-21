namespace _03.WildFarm.Models.Animals.Birds
{
    using System;

    using _03.WildFarm.Models.Food;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.WeightIncreaseByPiece = 0.35;
            this.AppropriateFoods = new Type[] { typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable) };
        }

        protected override double WeightIncreaseByPiece { get; set; }
        protected override Type[] AppropriateFoods { get; set; }

        public override string AskForFood()
        {
            return "Cluck";
        }
    }
}
