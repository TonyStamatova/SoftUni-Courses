using _03.WildFarm.Models.Food;

namespace _03.WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.WeightIncreaseByPiece = 0.1;
            this.AppropriateFoods = new string[] { "Vegetable", "Fruit" };
        }

        protected override double WeightIncreaseByPiece { get; set; }
        protected override string[] AppropriateFoods { get; set; }

        public override string AskForFood()
        {
            return "Squeak";
        }
    }
}
