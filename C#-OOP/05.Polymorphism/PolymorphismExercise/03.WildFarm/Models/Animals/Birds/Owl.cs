namespace _03.WildFarm.Models.Animals.Birds
{
    using System;

    using _03.WildFarm.Models.Food;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.WeightIncreaseByPiece = 0.25;
            this.AppropriateFoods = new Type[] { typeof(Meat) };
        }

        protected override double WeightIncreaseByPiece { get; set; }

        protected override Type[] AppropriateFoods { get; set; }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }
    }
}
