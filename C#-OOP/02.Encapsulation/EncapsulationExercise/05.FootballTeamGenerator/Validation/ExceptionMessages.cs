namespace _05.FootballTeamGenerator.Validation
{
    public static class ExceptionMessages
    {
        public static string InvalidStatException = "{0} should be between 0 and 100.";
        public static string InvalidNameException = "A name should not be empty.";
        public static string PlayerNotInTeamException = "Player {0} is not in {1} team.";
        public static string NonExistentTeamException = "Team {0} does not exist.";
    }
}
