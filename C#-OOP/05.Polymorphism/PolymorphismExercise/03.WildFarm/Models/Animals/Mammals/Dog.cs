namespace _03.WildFarm.Models.Animals.Mammals
{
    using System;

    using _03.WildFarm.Models.Food;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.WeightIncreaseByPiece = 0.4;
            this.AppropriateFoods = new Type[] { typeof(Meat) };
        }

        protected override double WeightIncreaseByPiece { get; set; }
        protected override Type[] AppropriateFoods { get; set; }

        public override string AskForFood()
        {
            return "Woof!";
        }
    }
}
