using _03.WildFarm.Models.Food;

namespace _03.WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.WeightIncreaseByPiece = 0.25;
            this.AppropriateFoods = new string[] { "Meat" };
        }

        protected override double WeightIncreaseByPiece { get; set; }

        protected override string[] AppropriateFoods { get; set; }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }
    }
}
