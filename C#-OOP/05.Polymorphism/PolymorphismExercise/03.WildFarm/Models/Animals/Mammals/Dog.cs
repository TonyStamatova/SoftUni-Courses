using _03.WildFarm.Models.Food;

namespace _03.WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.WeightIncreaseByPiece = 0.4;
            this.AppropriateFoods = new string[] { "Meat" };
        }

        protected override double WeightIncreaseByPiece { get; set; }
        protected override string[] AppropriateFoods { get; set; }

        public override string AskForFood()
        {
            return "Woof!";
        }
    }
}
