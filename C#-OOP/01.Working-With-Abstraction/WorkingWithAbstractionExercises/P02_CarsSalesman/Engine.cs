namespace P02_CarsSalesman
{
    using System.Text;

    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;

            this.Displacement = null;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, int? displacement)
            : this(model, power)
        {
            this.Displacement = displacement;

            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.Displacement = null;

            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
            : this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }

        public string Model { get; private set; }
        public int Power { get; private set; }
        public int? Displacement { get; private set; }
        public string Efficiency { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"  {this.Model}:");

            sb.AppendLine($"    Power: {this.Power}");

            string displacement = this.Displacement.ToString() != string.Empty ? this.Displacement.ToString() : "n/a";
            sb.AppendLine($"    Displacement: {displacement}");

            sb.AppendLine($"    Efficiency: {this.Efficiency}");

            return sb.ToString();
        }
    }
}
