namespace _03.WildFarm.Models.Animals.Mammals
{
    using System;

    using _03.WildFarm.Models.Food;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.WeightIncreaseByPiece = 0.1;
            this.AppropriateFoods = new Type[] { typeof(Vegetable), typeof(Fruit) };
        }

        protected override double WeightIncreaseByPiece { get; set; }

        protected override Type[] AppropriateFoods { get; set; }

        public override string AskForFood()
        {
            return "Squeak";
        }
    }
}
