using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.softUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> users = new Dictionary<string, int>();
            Dictionary<string, int> languages = new Dictionary<string, int>();

            while (input != "exam finished")
            {
                string[] data = input.Split("-");
                string username = data[0];

                if (data.Length == 3)
                {
                    string language = data[1];
                    int points = int.Parse(data[2]);

                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, points);
                    }
                    else
                    {
                        users[username] = Math.Max(users[username], points);
                    }

                    if (!languages.ContainsKey(language))
                    {
                        languages.Add(language, 1);
                    }
                    else
                    {
                        languages[language]++;
                    }
                }
                else
                {
                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                }

                input = Console.ReadLine();
            }

            users = users.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine("Results:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            languages = languages.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine("Submissions:");
            foreach (var language in languages)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
