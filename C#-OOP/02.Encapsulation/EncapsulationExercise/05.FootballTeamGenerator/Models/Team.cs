namespace _05.FootballTeamGenerator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using _05.FootballTeamGenerator.Validation;

    public class Team
    {
        private string name;
        private Dictionary<string, Player> players;

        public Team(string name)
        {
            this.Name = name;

            this.players = new Dictionary<string, Player>();
        }

        public string Name
        {
            get => this.name;

            set
            {
                Validator.ValidateName(value);
                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return  (int)Math.Round(
                        this.players
                        .Select(kvp => kvp.Value.SkillLevel)
                        .Sum());
                }
            }
        }

        public void AddPlayer(Player player)
        {
            if (!this.players.ContainsKey(player.Name))
            {
                this.players.Add(player.Name, player);
            }
        }

        public void RemovePlayer(string playerName)
        {
            if (!this.players.ContainsKey(playerName))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.PlayerNotInTeamException, playerName, this.Name));
            }

            this.players.Remove(playerName);
        }
    }
}
