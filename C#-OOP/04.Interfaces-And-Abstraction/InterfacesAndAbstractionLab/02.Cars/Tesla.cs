namespace Cars
{
    using System.Text;

    class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int battery)
            : base(model, color)
        {
            this.Battery = battery;
        }

        public int Battery { get; private set; }
        
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{this.Color} {nameof(Tesla)} {this.Model} with {this.Battery} Batteries");
            builder.Append(base.ToString());

            return builder.ToString();
        }
    }
}
