namespace _05.FootballTeamGenerator.Core
{
    using _05.FootballTeamGenerator.Models;
    using _05.FootballTeamGenerator.Validation;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Engine
    {
        public static Dictionary<string, Team> allTeams = new Dictionary<string, Team>();

        public static void Start()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()).ToUpper() != "END")
            {
                try
                {
                    string[] commandData = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                    string command = commandData[0];
                    string teamName = commandData[1];

                    switch (command.ToLower())
                    {
                        case "team":
                            CreateNewTeam(teamName);
                            break;

                        case "add":
                            Player newPlayer = CreateNewPlayer(commandData.Skip(2).ToArray());
                            AddPlayerToTeam(teamName, newPlayer);
                            break;

                        case "remove":
                            string playerName = commandData[2];
                            RemovePlayerFromTeam(teamName, playerName);
                            break;

                        case "rating":
                            Validator.ValidateTeam(allTeams, teamName);
                            Console.WriteLine($"{teamName} - {allTeams[teamName].Rating}");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private static void CreateNewTeam(string name)
        {
            if (!allTeams.ContainsKey(name))
            {
                Team newTeam = new Team(name);
                allTeams.Add(name, newTeam);
            }
        }
        private static Player CreateNewPlayer(string[] playerInfo)
        {
            Player newPlayer = new Player(
                             playerInfo[0],
                             int.Parse(playerInfo[1]),
                             int.Parse(playerInfo[2]),
                             int.Parse(playerInfo[3]),
                             int.Parse(playerInfo[4]),
                             int.Parse(playerInfo[5]));

            return newPlayer;
        }

        private static void AddPlayerToTeam(string teamName, Player newPlayer)
        {
            Validator.ValidateTeam(allTeams, teamName);
            allTeams[teamName].AddPlayer(newPlayer);
        }

        private static void RemovePlayerFromTeam(string teamName, string player)
        {
            Validator.ValidateTeam(allTeams, teamName);
            allTeams[teamName].RemovePlayer(player);
        }
    }
}
