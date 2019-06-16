namespace HealthyHeaven
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Restaurant
    {
        private string name;
        private Dictionary<string, Salad> data;

        public Restaurant(string name)
        {
            this.Name = name;

            this.Data = new Dictionary<string, Salad>();
        }

        public string Name { get => name; set => name = value; }

        private Dictionary<string, Salad> Data { get => data; set => data = value; }

        public void Add(Salad salad)
        {
            if (!this.Data.ContainsKey(salad.Name))
            {
                this.Data.Add(salad.Name, salad);
            }
        }

        public bool Buy(string name)
        {
            return this.Data.Remove(name);
        }

        public Salad GetHealthiestSalad()
        {
            return this.Data
                .OrderBy(kvp => kvp.Value.GetTotalCalories())
                .Select(kvp => kvp.Value)
                .FirstOrDefault();
        }

        public string GenerateMenu()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{this.Name} have {this.Data.Count} salads:");

            foreach (var (saladName, salad) in this.Data)
            {
                builder.AppendLine(salad.ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
