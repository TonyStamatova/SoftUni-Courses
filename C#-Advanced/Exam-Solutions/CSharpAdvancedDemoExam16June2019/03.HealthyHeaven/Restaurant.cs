namespace HealthyHeaven
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Restaurant
    {
        private string name;
        private List<Salad> data;

        public Restaurant(string name)
        {
            this.Name = name;

            this.data = new List<Salad>();
        }

        public string Name { get => this.name; set => this.name = value; }

        public void Add(Salad salad)
        {
            this.data.Add(salad);
        }

        public bool Buy(string name)
        {
            return this.data.Remove(
                data
                .Where(s => s.Name == name)
                .FirstOrDefault());
        }

        public Salad GetHealthiestSalad()
        {
            return this.data
                .OrderByDescending(s => s.GetTotalCalories())
                .LastOrDefault();
        }

        public string GenerateMenu()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{this.Name} have {this.data.Count} salads:");

            foreach (var salad in this.data)
            {
                builder.AppendLine(salad.ToString());
            }

            return builder
                .ToString()
                .TrimEnd();
        }
    }
}
