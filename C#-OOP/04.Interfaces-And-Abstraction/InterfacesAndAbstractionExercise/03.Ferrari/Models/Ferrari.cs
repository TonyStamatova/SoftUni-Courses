namespace _03.Ferrari.Models
{
    using _03.Ferrari.Contracts;

    public class Ferrari : ICar
    {
        private const string MODEL = "488-Spider";

        public Ferrari(string driver)
        {
            this.Model = MODEL;

            this.Driver = driver;
        }

        public string Model { get; private set; }

        public string Driver { get; private set; }

        public string PushGas()
        {
            return "Gas!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.UseBrakes()}/{this.PushGas()}/{this.Driver}";
        }
    }
}
