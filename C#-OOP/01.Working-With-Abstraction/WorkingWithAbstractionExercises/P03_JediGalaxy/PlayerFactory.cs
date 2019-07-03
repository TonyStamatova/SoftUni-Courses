namespace P03_JediGalaxy
{
    public static class PlayerFactory
    {
        public static Player Create(string command)
        {
            int[] coordinates = CommandParser.Parse(command);
            Player newPlayer = new Player(coordinates[0], coordinates[1]);
            return newPlayer;
        }
    }
}
