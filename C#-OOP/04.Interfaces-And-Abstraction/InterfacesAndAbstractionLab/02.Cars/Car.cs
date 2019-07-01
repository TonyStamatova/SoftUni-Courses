using System.Text;

namespace Cars
{
    public abstract class Car : ICar
    {
        public Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; protected set; }

        public string Color { get; protected set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(this.Start());
            builder.Append(this.Stop());

            return builder.ToString();
        }        
    }
}
