namespace SpaceStationRecruitment
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class SpaceStation
    {
        private List<Astronaut> astronauts;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.astronauts = new List<Astronaut>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.astronauts.Count;

        public void Add(Astronaut astronaut)
        {
            if (this.Count < this.Capacity)
            {
                this.astronauts.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            Astronaut astronaut = this.astronauts.Find(a => a.Name == name);

            return this.astronauts.Remove(astronaut);
        }

        public Astronaut GetOldestAstronaut()
        {
            return this.astronauts
                .OrderByDescending(a => a.Age)
                .FirstOrDefault();
        }
        
        public Astronaut GetAstronaut(string name)
        {
            return this.astronauts.Find(a => a.Name == name);
        }

        public string Report()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astr in this.astronauts)
            {
                builder.AppendLine(astr.ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
