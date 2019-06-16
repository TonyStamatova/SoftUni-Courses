namespace HealthyHeaven
{
    public class Vegetable
    {
        private string name;
        private int calories;

        public Vegetable(string name, int calories)
        {
            this.Name = name;
            this.Calories = calories;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int Calories
        {
            get => this.calories;
            set => this.calories = value;
        }

        public override string ToString()
        {
            return $" - {this.Name} have {this.Calories} calories";
        }
    }
}
