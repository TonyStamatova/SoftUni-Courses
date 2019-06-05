namespace _05.FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterByAge
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            List<KeyValuePair<string, int>> people = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string name = input[0];
                int age = int.Parse(input[1]);

                people.Add(new KeyValuePair<string, int>(name, age));
            }

            string condition = Console.ReadLine();
            int ageLine = int.Parse(Console.ReadLine());

            Func<KeyValuePair<string, int>, bool> younger = person => person.Value < ageLine;

            switch (condition)
            {
                case "younger":
                    people = people
                        .Where(younger)
                        .ToList();
                    break;
                case "older":
                    people = people
                        .Except(people.Where(younger))
                        .ToList();
                    break;
            }

            string format = Console.ReadLine();
            Action<KeyValuePair<string, int>> printName = x => Console.WriteLine(x.Key);
            Action<KeyValuePair<string, int>> printAge = x => Console.WriteLine(x.Value);
            Action<KeyValuePair<string, int>> printNameAndAge = x => Console.WriteLine($"{x.Key} - {x.Value}");

            switch (format)
            {
                case "name":
                    people.ForEach(printName);
                    break;
                case "age":
                    people.ForEach(printAge);
                    break;
                case "name age":
                    people.ForEach(printNameAndAge);
                    break;
            }
        }
    }
}
