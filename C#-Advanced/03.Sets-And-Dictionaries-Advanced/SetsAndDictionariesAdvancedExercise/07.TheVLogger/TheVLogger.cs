namespace _07.TheVLogger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TheVLogger
    {
        public static void Main()
        {
            HashSet<Vlogger> vloggers = new HashSet<Vlogger>();

            string input;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] commandData = input.Split();
                string command = commandData[1];

                switch (command)
                {
                    case "joined":
                        string name = commandData[0];
                        AddNewVlogger(name, vloggers);
                        break;

                    case "followed":
                        string followerName = commandData[0];
                        string followedName = commandData[2];
                        Follow(vloggers, followerName, followedName);
                        break;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            vloggers = new HashSet<Vlogger>(
                vloggers
                .OrderByDescending(x => x.Followers.Count)
                .ThenBy(x => x.FollowingCount));

            Vlogger mostFamous = vloggers.FirstOrDefault();
            PrintMostFamousStatistics(mostFamous);
            PrintOtherVloggersStatistics(vloggers);
        }

        private static void PrintOtherVloggersStatistics(HashSet<Vlogger> vloggers)
        {
            int number = 2;

            foreach (var vlogger in vloggers.Skip(1))
            {
                Console.WriteLine($"{number}. {vlogger.Name} : "
                    + $"{vlogger.Followers.Count} followers, {vlogger.FollowingCount} following");
                number++;
            }
        }

        private static void Follow(HashSet<Vlogger> vloggers, string followerName, string followedName)
        {
            if (vloggers.Any(x => x.Name == followerName)
                                        && vloggers.Any(x => x.Name == followedName)
                                        && followerName != followedName)
            {
                Vlogger followed = vloggers.First(x => x.Name == followedName);
                Vlogger follower = vloggers.First(x => x.Name == followerName);

                if (!followed.Followers.Contains(followerName))
                {
                    followed.Followers.Add(followerName);
                    follower.FollowingCount++;
                }
            }
        }

        private static void PrintMostFamousStatistics(Vlogger mostFamous)
        {
            Console.WriteLine($"1. {mostFamous.Name} : {mostFamous.Followers.Count} followers, " 
                + $"{mostFamous.FollowingCount} following");

            foreach (var follower in mostFamous.Followers)
            {
                Console.WriteLine($"*  {follower}");
            }
        }

        public static void AddNewVlogger(string name, HashSet<Vlogger> vloggers)
        {
            Vlogger currentVlogger = new Vlogger(name);

            if (!vloggers.Any(x => x.Name == name))
            {
                vloggers.Add(currentVlogger);
            }
        }
    }

    public class Vlogger
    {
        public Vlogger(string name)
        {
            this.Name = name;
            this.FollowingCount = 0;
            this.Followers = new SortedSet<string>();
        }

        public string Name { get; set; }

        public SortedSet<string> Followers { get; set; }

        public int FollowingCount { get; set; }
    }
}
