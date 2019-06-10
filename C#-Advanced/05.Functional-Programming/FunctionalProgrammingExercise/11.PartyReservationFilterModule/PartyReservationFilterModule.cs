namespace _11.PartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PartyReservationFilterModule
    {
        public static void Main()
        {
            List<string> people = Console.ReadLine()
                .Split()
                .ToList();

            HashSet<string> filters = new HashSet<string>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] inputParts = input.Split(";");
                string command = inputParts[0];
                string filterName = $"{inputParts[1]} : {inputParts[2]}";

                switch (command)
                {
                    case "Add filter":
                        filters.Add(filterName);
                        break;
                    case "Remove filter":
                        filters.Remove(filterName);
                        break;
                }
            }

            Func<string, string, bool> filter = default(Func<string, string, bool>);

            Func<string, string, bool> startsWith = (n, p)
                    => n.Contains(p)
                    && n.IndexOf(p) == 0;

            Func<string, string, bool> endsWith = (n, p)
                    => n.Contains(p)
                    && n.LastIndexOf(p[p.Length - 1]) == n.Length - 1;

            Func<string, string, bool> length = (n, p)
                    => n.Length == int.Parse(p);

            Func<string, string, bool> contains = (n, p)
                    => n.Contains(p);

            foreach (var element in filters)
            {
                string[] filterData = element.Split(" : ");
                string filterType = filterData[0];
                string parameter = filterData[1];

                switch (filterType)
                {
                    case "Starts with":
                        filter = startsWith;
                        break;

                    case "Ends with":
                        filter = endsWith;
                        break;

                    case "Length":
                        filter = length;
                        break;

                    case "Contains":
                        filter = contains;
                        break;
                }

                people = people.Where(x => !filter(x, parameter)).ToList();
            }
            
            Console.WriteLine(string.Join(" ", people));
        }
    }
}
