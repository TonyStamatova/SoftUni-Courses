namespace _08.CarSalesman
{
    using System;

    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine, int weight = default(int), string color = "n/a")
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public Engine Engine
        {
            get => this.engine;
            set => this.engine = value;
        }

        public int Weight
        {
            get => this.weight;
            set => this.weight = value;
        }

        public string Color
        {
            get => this.color;
            set => this.color = value;
        }

        public override string ToString()
        {
            string engineDisplacement = (this.Engine.Displacement == 0) ? "n/a" : this.Engine.Displacement.ToString();
            string carWeight = (this.Weight == 0) ? "n/a" : this.Weight.ToString();

            return $"{this.Model}:"
                + Environment.NewLine + "  " + $"{this.Engine.Model}:"
                + Environment.NewLine + "   Power:" + $" {this.Engine.Power}"
                + Environment.NewLine + "   Displacement:" + $" {engineDisplacement}"
                + Environment.NewLine + "   Efficiency:" + $" {this.Engine.Efficiency}"
                + Environment.NewLine + "  Weight:" + $" {carWeight}"
                + Environment.NewLine + "  Color:" + $" {this.Color}";
        }

    }
}
