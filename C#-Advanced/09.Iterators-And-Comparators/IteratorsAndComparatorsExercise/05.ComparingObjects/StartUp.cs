namespace _05.ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                Person newPerson = new Person(input.Split());
                people.Add(newPerson);
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            Person personOfInterest = people[index];

            int matches = people.Where(p => p.CompareTo(personOfInterest) == 0).Count();
            int countOfNonEquals = people.Where(p => p.CompareTo(personOfInterest) != 0).Count();
            int totCount = people.Count;

            if (matches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {countOfNonEquals} {totCount}");
            }
        }
    }
}
