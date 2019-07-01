namespace Cars
{
    using System.Text;

    class Seat : Car
    {  
        public Seat(string model, string color)
            : base(model, color)
        {            
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{this.Color} {nameof(Seat)} {this.Model}");
            builder.Append(base.ToString());

            return builder.ToString();
        }
    }
}
