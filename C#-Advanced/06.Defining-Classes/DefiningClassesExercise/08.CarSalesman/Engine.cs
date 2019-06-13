namespace _08.CarSalesman
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power, int dispalacement = default(int), string efficiency = "n/a")
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = dispalacement;
            this.Efficiency = efficiency;
        }

        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public int Power
        {
            get => this.power;
            set => this.power = value;
        }

        public int Displacement
        {
            get => this.displacement;
            set => this.displacement = value;
        }

        public string Efficiency
        {
            get => this.efficiency;
            set => this.efficiency = value;
        }
    }
}
