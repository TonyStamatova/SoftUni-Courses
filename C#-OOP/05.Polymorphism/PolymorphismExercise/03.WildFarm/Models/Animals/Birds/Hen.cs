using _03.WildFarm.Models.Food;

namespace _03.WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.WeightIncreaseByPiece = 0.35;
            this.AppropriateFoods = new string[] { "Fruit", "Meat", "Seeds", "Vegetable" };
        }

        protected override double WeightIncreaseByPiece { get; set; }
        protected override string[] AppropriateFoods { get; set; }

        public override string AskForFood()
        {
            return "Cluck";
        }
    }
}
