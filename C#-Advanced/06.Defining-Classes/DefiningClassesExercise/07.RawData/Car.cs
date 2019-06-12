using System;
using System.Collections.Generic;

namespace _07.RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car(Queue<string> parameters)
        {
            this.Model = next(parameters);
            this.Engine = new Engine(int.Parse(next(parameters)), int.Parse(next(parameters)));
            this.Cargo = new Cargo(int.Parse(next(parameters)), next(parameters));

            this.Tires = new Tire[4];

            for (int i = 0; i < tires.Length; i++)
            {
                tires[i] = new Tire(double.Parse(next(parameters)), int.Parse(next(parameters)));
            }
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

        public Cargo Cargo
        {
            get => this.cargo;
            set => this.cargo = value;
        }

        public Tire[] Tires
        {
            get => this.tires;
            set => this.tires = value;
        }

        Func<Queue<string>, string> next = q => q.Dequeue();
    }
}
