namespace _05.FootballTeamGenerator.Validation
{
    using _05.FootballTeamGenerator.Models;
    using System;
    using System.Collections.Generic;

    public static class Validator
    {
        public static void ValidateStat(string stat, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatException, stat));
            }
        }

        public static void ValidateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.InvalidNameException);
            }
        }

        public static void ValidateTeam(Dictionary<string, Team> teams, string teamName)
        {
            if (!teams.ContainsKey(teamName))
            {
                throw new ArgumentException(
                    string.Format(
                        ExceptionMessages.NonExistentTeamException, teamName));
            }
        }
    }
}
