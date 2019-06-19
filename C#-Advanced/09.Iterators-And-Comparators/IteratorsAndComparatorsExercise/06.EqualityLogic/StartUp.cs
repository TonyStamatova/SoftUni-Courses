namespace _06.EqualityLogic
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            HashSet<Person> people = new HashSet<Person>();

            int numberOFLines = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < numberOFLines; i++)
            {
                string input = Console.ReadLine();

                Person newPerson = new Person(input.Split());
                sortedPeople.Add(newPerson);
                people.Add(newPerson);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(people.Count);
        }
    }
}
