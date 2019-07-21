namespace _03.WildFarm.Models.Animals.Mammals.Feline
{
    using System;

    using _03.WildFarm.Models.Food;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.WeightIncreaseByPiece = 0.3;
            this.AppropriateFoods = new Type[] { typeof(Vegetable), typeof(Meat) };
        }

        protected override double WeightIncreaseByPiece { get; set; }

        protected override Type[] AppropriateFoods { get; set; }

        public override string AskForFood()
        {
            return "Meow";
        }
    }
}
