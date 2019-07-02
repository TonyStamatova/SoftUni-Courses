namespace P02_CarsSalesman
{
    using System.Text;

    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;

            this.Weight = null;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;

            this.Color = "n/a";
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Weight = null;

            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            :this(model, engine, weight)
        {
            this.Color = color;
        }

        public string Model { get; private set; }
        public Engine Engine { get; private set; }
        public int? Weight { get; private set; }
        public string Color { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:");

            sb.Append(this.Engine.ToString());

            string weightAsString = this.Weight.ToString() != string.Empty ? this.Weight.ToString() : "n/a";
            sb.AppendLine($"  Weight: {weightAsString}");

            sb.Append($"  Color: {this.Color}");

            return sb.ToString();
        }
    }
}
