namespace _09.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string input = string.Empty;

            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] caughtPokemonInfo = input.Split();
                string trainerName = caughtPokemonInfo[0];
                string pokemonName = caughtPokemonInfo[1];
                string pokemonElement = caughtPokemonInfo[2];
                int pokemonHealth = int.Parse(caughtPokemonInfo[3]);

                Pokemon caughtPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer newTrainer = new Trainer(trainerName);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, newTrainer);
                }

                if (!trainers[trainerName].Pokemons.ContainsKey(pokemonElement))
                {
                    trainers[trainerName].Pokemons.Add(pokemonElement, new List<Pokemon>());
                }

                trainers[trainerName].Pokemons[pokemonElement].Add(caughtPokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var (name, trainer) in trainers.Where(kvp => kvp.Value.Pokemons[input].Count > 0))
                {
                    trainer.Badges++;
                }

                foreach (var (pokemonElement, listOfAllPokemons) in trainers
                    .Where(kvp => kvp.Value.Pokemons[input].Count == 0)
                    .SelectMany(kvp => kvp.Value.Pokemons)
                    .ToList())
                {                    
                        listOfAllPokemons.ForEach(p => p.Health -= 10);
                        listOfAllPokemons.RemoveAll(p => p.Health <= 0);                    
                }
            }

            foreach (var trainer in trainers.Values.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Values.Sum(l => l.Count)}");
            }
        }
    }
}
