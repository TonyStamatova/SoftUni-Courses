using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.teamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teamsList = new List<Team>();

            for (int i = 0; i < teamsCount; i++)
            {
                string[] registry = Console.ReadLine().Split("-");
                string teamName = registry[1];
                string teamCreator = registry[0];
                Team newTeam = new Team(teamName, teamCreator);

                if (teamsList.Select(x => x.Name).Contains(teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teamsList.Any(x => x.Creator == teamCreator))
                {
                    Console.WriteLine($"{teamCreator} cannot create another team!");
                }
                else
                {
                    teamsList.Add(newTeam);
                    Console.WriteLine($"Team {teamName} has been created by {teamCreator}!");
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of assignment")
                {
                    break;
                }

                string[] joiningTeam = input.Split("->");
                string teamToJoin = joiningTeam[1];
                string newTeammate = joiningTeam[0];

                if (!teamsList.Any(x => x.Name == teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else if (teamsList.Any(x => x.Members.Contains(newTeammate))
                    || teamsList.Where(x => x.Name == teamToJoin).Any(x => x.Creator == newTeammate))
                {
                    Console.WriteLine($"Member {newTeammate} cannot join team {teamToJoin}!");
                }
                else
                {
                    teamsList.Find(x => x.Name == teamToJoin).Members.Add(newTeammate);
                }
            }

            List<Team> teamsToDisband = teamsList.Where(x => x.Members.Count == 0).OrderBy(x => x.Name).ToList();
            teamsList = teamsList.Where(x => x.Members.Count != 0)
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.Name)
                .ToList();

            if (teamsList.Count != 0)
            {
                foreach (var team in teamsList)
                {
                    Console.WriteLine(team);
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in teamsToDisband)
            {
                Console.WriteLine(team.Name);
            }

        }
    }

    class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        public Team(string name, string creator)
        {
            this.Name = name;
            this.Creator = creator;
            this.Members = new List<string>();
        }

        public override string ToString()
        {
            this.Members.Sort();
            return $"{this.Name}"
                + Environment.NewLine + $"- {this.Creator}"
                + Environment.NewLine + "-- " + string.Join(Environment.NewLine + "-- ", this.Members);
        }
    }
}
