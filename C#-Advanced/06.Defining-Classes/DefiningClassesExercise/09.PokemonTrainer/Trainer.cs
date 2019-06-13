namespace _09.PokemonTrainer
{
    using System.Collections.Generic;

    public class Trainer
    {
        private string name;
        private int badges;
        private Dictionary<string, List<Pokemon>> pokemons;

        public Trainer(string name)
        {
            this.Name = name;

            this.Badges = 0;
            this.Pokemons = new Dictionary<string, List<Pokemon>>()
            {
                { "Fire", new List<Pokemon>()},
                { "Water", new List<Pokemon>()},
                { "Electricity", new List<Pokemon>()}
            };
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int Badges
        {
            get => this.badges;
            set => this.badges = value;
        }

        public Dictionary<string, List<Pokemon>> Pokemons
        {
            get => this.pokemons;
            set => this.pokemons = value;
        }
    }
}
