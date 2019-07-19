using _03.WildFarm.Models.Food;

namespace _03.WildFarm.Models.Animals.Mammals.Feline
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.WeightIncreaseByPiece = 1.0;
            this.AppropriateFoods = new string[] { "Meat" };
        }

        protected override double WeightIncreaseByPiece { get; set; }

        protected override string[] AppropriateFoods { get; set; }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }
    }
}
