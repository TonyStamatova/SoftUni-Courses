using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.vaporWinterSale
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            Dictionary<string, Game> gamesByName = new Dictionary<string, Game>();

            foreach (var item in input)
            {
                if (item.Contains('-'))
                {
                    string[] gameData = item.Split("-");
                    string name = gameData[0];
                    decimal price = decimal.Parse(gameData[1]);
                    Game newGame = new Game(name, price);

                    if (!gamesByName.ContainsKey(name))
                    {
                        gamesByName.Add(name, newGame);
                    }
                }
                else
                {
                    string[] update = item.Split(":");
                    string name = update[0];
                    string dlc = update[1];

                    if (gamesByName.ContainsKey(name))
                    {
                        gamesByName[name].DLC = dlc;
                        gamesByName[name].IncreasePrice();
                    }
                }
            }

            foreach (var game in gamesByName.Values)
            {
                if (game.DLC == null)
                {
                    game.Price -= 0.2m * game.Price;
                }
                else
                {
                    game.Price -= 0.5m * game.Price;
                }
            }

            foreach (var game in gamesByName.Values
                .Where(x => x.DLC != null)
                .OrderBy(x => x.Price))
            {
                Console.WriteLine($"{game.Name} - {game.DLC} - {game.Price:f2}");
            }

            foreach (var game in gamesByName.Values
                .Where(x => x.DLC == null)
                .OrderByDescending(x => x.Price))
            {
                Console.WriteLine($"{game.Name} - {game.Price:f2}");
            }
        }
    }

    class Game
    {
        public Game(string name, decimal Price)
        {
            this.Name = name;
            this.Price = Price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string DLC { get; set; }

        public void IncreasePrice()
        {
            this.Price *= 1.2m;
        }
    }
}
