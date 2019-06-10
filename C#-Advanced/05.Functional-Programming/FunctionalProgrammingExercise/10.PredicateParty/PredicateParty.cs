namespace _10.PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateParty
    {
        public static void Main()
        {
            List<string> people = Console.ReadLine()
                .Split()
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] commandData = command.Split();
                string operation = commandData[0];
                string condition = commandData[1];
                string details = commandData[2];

                List<string> names = FindNames(people, condition, details);

                Action<string, List<string>> doubleName = (name, list) => list.Insert(list.IndexOf(name), name);
                Action<string, List<string>> removeName = (name, list) => list.Remove(name);

                switch (operation)
                {
                    case "Double":
                        names.ForEach(n => doubleName(n, people));
                        break;
                    case "Remove":
                        names.ForEach(n => removeName(n, people));
                        break;
                }
            }


            if (people.Count > 0)
            {
                Console.WriteLine(string.Join(", ", people) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static List<string> FindNames(List<string> list, string condition, string details)
        {
            List<string> names = new List<string>();
            
            switch (condition)
            {
                case "StartsWith":
                    Func<string, string, bool> startsWith = (x, y) 
                        => x.Contains(y) && x.IndexOf(y) == 0;
                    names = list
                        .Where(n => startsWith(n, details))
                        .ToList();
                    break;

                case "EndsWith":
                    Func<string, string, bool> endsWith = (x, y) 
                        => x.Contains(y) && x.LastIndexOf(y[y.Length - 1]) == x.Length - 1;
                    names = list
                        .Where(n => endsWith(n, details))
                        .ToList();
                    break;

                case "Length":
                    Func<string, int, bool> lengthMatches = (x, y) 
                        => x.Length == y;
                    int length = int.Parse(details);
                    names = list
                        .Where(n => lengthMatches(n, length))
                        .ToList();
                    break;
            }
            
            return names;
        }
    }
}
