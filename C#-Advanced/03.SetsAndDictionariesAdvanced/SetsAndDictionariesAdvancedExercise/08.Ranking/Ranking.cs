namespace _08.Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Ranking
    {
        public static void Main()
        {
            var contests = new Dictionary<string, string>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                var contestData = input.Split(":");
                var contest = contestData[0];
                var password = contestData[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
            }

            var users = new SortedDictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                var submission = input.Split("=>");
                var contest = submission[0];
                var password = submission[1];
                var username = submission[2];
                var points = int.Parse(submission[3]);

                if (!contests.ContainsKey(contest) || contests[contest] != password)
                {
                    continue;
                }

                if (!users.ContainsKey(username))
                {
                    users.Add(username, new Dictionary<string, int>());
                }

                if (!users[username].ContainsKey(contest))
                {
                    users[username].Add(contest, points);
                    continue;
                }

                users[username][contest] = Math.Max(users[username][contest], points);
            }

            var firstRanked = users.OrderByDescending(x => x.Value.Values.Sum()).FirstOrDefault();
            var mostPointsCount = firstRanked.Value.Values.Sum();

            Console.WriteLine($"Best candidate is {firstRanked.Key} with total {mostPointsCount} points.");

            Console.WriteLine("Ranking:");

            foreach (var student in users)
            {
                Console.WriteLine(student.Key);

                foreach (var contest in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
