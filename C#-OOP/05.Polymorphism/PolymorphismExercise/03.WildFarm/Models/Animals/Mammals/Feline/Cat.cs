using _03.WildFarm.Models.Food;

namespace _03.WildFarm.Models.Animals.Mammals.Feline
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.WeightIncreaseByPiece = 0.3;
            this.AppropriateFoods = new string[] { "Vegetable", "Meat" };
        }

        protected override double WeightIncreaseByPiece { get; set; }

        protected override string[] AppropriateFoods { get; set; }

        public override string AskForFood()
        {
            return "Meow";
        }
    }
}
