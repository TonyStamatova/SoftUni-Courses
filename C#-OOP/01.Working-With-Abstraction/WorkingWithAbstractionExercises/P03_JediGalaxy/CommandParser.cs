namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public static class CommandParser
    {
        public static int[] Parse(string command)
        {            
            return command
                 .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
        }
    }
}
