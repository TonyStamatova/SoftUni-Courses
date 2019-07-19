namespace _03.WildFarm.Models.Animals.Birds
{
    using _03.WildFarm.Contracts;

    public abstract class Bird : Animal, IBird
    {
        public Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
