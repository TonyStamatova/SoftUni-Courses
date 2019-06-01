using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.forceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, List<string>> usersBySide = new Dictionary<string, List<string>>();

            while (true)
            {
                input = Console.ReadLine();

                if (input == "Lumpawaroo")
                {
                    break;
                }

                string[] data = null;
                string username = string.Empty;
                string side = string.Empty;

                if (input.Contains(" | "))
                {
                    data = input.Split(" | ");
                    side = data[0];
                    username = data[1];

                    if (usersBySide.Values.Any(x => x.Contains(username)))
                    {
                        continue;
                    }

                    CheckForUserAndAddNew(usersBySide, side, username);
                }
                else if (input.Contains(" -> "))
                {
                    data = input.Split(" -> ");
                    username = data[0];
                    side = data[1];

                    if (usersBySide.Values.Any(x => x.Contains(username)))
                    {
                        List<string> temp = usersBySide.Values.First(x => x.Contains(username));
                        temp.Remove(username);
                    }

                    CheckForUserAndAddNew(usersBySide, side, username);
                    Console.WriteLine($"{username} joins the {side} side!");
                }
            }

            usersBySide = usersBySide.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .Where(x => x.Value.Count != 0)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var side in usersBySide)
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                side.Value.Sort();

                foreach (var user in side.Value)
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }

        private static void CheckForUserAndAddNew(Dictionary<string, List<string>> dict, string side, string username)
        {
            if (!dict.ContainsKey(side))
            {
                dict.Add(side, new List<string>());
            }

            dict[side].Add(username);
        }
    }
}
